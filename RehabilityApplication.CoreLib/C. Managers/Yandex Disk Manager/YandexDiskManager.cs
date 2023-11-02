using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public static class YandexDiskManager
    {
        #region Поля и свойства

        public static Dictionary<string, string> tokens = new Dictionary<string, string>();
        public static List<ITreeListItem> structure { get; set; } = new List<ITreeListItem>();

        public static bool IsInitializedTokes = false;

        #endregion

        #region Методы

        #region Инициализация

        public static void Init()
        {
            tokens["Василий"] = "y0_AgAAAAAMURj-AAq2RQAAAADwBU-_spqt7WMVTG-Oeq8dTlecBHjd6VU";
            tokens["Иван"] = "y0_AgAAAAACSRs_AAq2SgAAAADwBdiM2q9ldjDzQTSwlFPo2kgQOePkgHo";
            tokens["Евгений"] = "y0_AgAAAAA1p3oVAAq2QwAAAADwBTu4runulS2mQ02DLu0RNhoKn0kI6WQ";

            CoreGlobalCommandManager.CommandDataReceivingInitialized += (s, e) =>
            {
                if (e.Command is YandexDiskManagerCommandType.CreateFolder)
                {
                    CreateFolder(e.Data[0], e.Data[1], e.Data[2]);
                }
            };

            CoreGlobalCommandManager.CommandInitialized += (s, e) =>
            {
                if (e.Command is YandexDiskManagerCommandType.PleaseDownloadDatabase)
                {
                    string targetPath = "/25-10-2023/Database/db.xml";
                    string localPath = "clients_.xml";
                    DownloadFile(targetPath, localPath);
                    
                }
            };

            IsInitializedTokes = true;
        }

        #endregion

        #region Базовые методы

        /// <summary>
        /// Создание папки.
        /// </summary>
        /// <param name="TargetFolder">Целевая папка, куда будет производиться создание новой папки в виде [/folder/].</param>
        /// <param name="NewFolder">Имя новой папки.</param>
        /// <param name="name">Имя пользователя, чей токен будет использован в качестве хранилища.</param>
        /// <returns></returns>
        public static bool CreateFolder(string TargetFolder, string NewFolder, string name)
        {
            return Task<bool>.Run(async () =>
            {
                if (IsInitializedTokes == false)
                {
                    Init();
                    IsInitializedTokes = true;
                }

                string Target = $"{TargetFolder.Substring(1, TargetFolder.Length - 2)}/{NewFolder}".NormalizeToUrl();
                string baseLink = "https://cloud-api.yandex.net";
                string resourcLink = "v1/disk/resources";
                string parameters = $"path={Target}";
                string url = $"{baseLink}/{resourcLink}?{parameters}";
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "PUT";
                httpRequest.Headers.Add("Authorization", $"OAuth {tokens[name]}");
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                string result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    Console.WriteLine("RESULT:");
                    Console.WriteLine(result);
                    Console.WriteLine("");
                }
                return true;
            }).Result;
        }

        /// <summary>
        /// Загрузка файла с Яндекс диска.
        /// </summary>
        /// <param name="TargetFilename">Целевой файл в виде [/folder/file.ext].</param>
        /// <param name="LocalFileName">Локальный путь, куда будет сохраняться файл [D:\folder\savedfile.ext].</param>
        /// <returns></returns>
        public static bool DownloadFile(string TargetFilename, string LocalFileName)
        {
            if (IsInitializedTokes == false)
            {
                Init();
                IsInitializedTokes = true;
            }

            return Task<bool>.Run(async () =>
            {
                string url = $"https://webdav.yandex.ru/{TargetFilename}";
                WebClient wc = new WebClient();
                wc.Headers.Add("Authorization", $"OAuth {tokens["Евгений"]}");
                wc.DownloadFileCompleted += (ss, ee) =>
                {
                    // Событие завершения загрузки файла с диска
                    CoreGlobalCommandManager.StartCommand(YandexDiskManagerCommandType.DownloadDatabaseComplete);
                };
                wc.DownloadFileAsync(new Uri(url), LocalFileName);
                return true;
            }).Result;
        }

        /// <summary>
        /// Загрузка файла на Яндекс диск.
        /// </summary>
        /// <param name="TargetFilePath">Целевой файл [/folder/file.ext]</param>
        /// <param name="TargetLocalFileName">Целевой файл с компьютера [D:\folder\savedfile.ext].</param>
        /// <returns></returns>
        public static bool UploadFile(string TargetFilePath, string TargetLocalFileName)
        {
            if (IsInitializedTokes == false)
            {
                Init();
                IsInitializedTokes = true;
            }

            return Task<bool>.Run(async () =>
            {
                string url = $"https://webdav.yandex.ru/{TargetFilePath}";
                string myfile = TargetLocalFileName;
                WebClient wc = new WebClient();
                wc.Headers.Add("Authorization", $"OAuth {tokens["Евгений"]}");
                wc.UploadFileCompleted += (ss, ee) =>
                {
                    // Загрузка на диск завершена
                    CoreGlobalCommandManager.StartCommand(YandexDiskManagerCommandType.DatabaseUploaded);
                };
                wc.UploadFileAsync(new Uri(url), "PUT", myfile);
                return true;
            }).Result;
        }

        /// <summary>
        /// Получаем список файлов и папко для указанной папки на Яндекс диске.
        /// </summary>
        /// <param name="TargetFolder">Целевая папка для сканирования [/folder/].</param>
        /// <returns>Возращает признак - успешено ли выполнилось сканирование?</returns>
        public static bool GetFolderStructure(string TargetFolder = "/")
        {
            if (IsInitializedTokes == false)
            {
                Init();
                IsInitializedTokes = true;
            }

            return Task<bool>.Run(async ()=>
            {
                structure.Clear();
                GetFolderContent(TargetFolder);
                CoreGlobalCommandManager.StartReceiveDataCommand(YandexDiskManagerCommandType.FolderStructureWasReaded, structure);
                return true;
            }).Result;
        }

        /// <summary>
        /// Рекурсивное определение структуры папки и получение ответа от Яндекс диска об успешности сканирования.
        /// </summary>
        /// <param name="RootFolder">Папка сканирования [/folder/].</param>
        /// <param name="FolderId">Идентификатор текущей сканируемой папки.</param>
        /// <returns>Возвращает true - если успешно.</returns>
        static bool GetFolderContent(string RootFolder, string FolderId = "$")
        {
            return Task<bool>.Run(() =>
            {
                if (RootFolder == "") RootFolder = "/";
                string Target = $"{RootFolder}".NormalizeToUrl();
                int limit = 1000000;
                string baseLink = "https://cloud-api.yandex.net";
                string resourcLink = "v1/disk/resources";
                string parameters = $"path={RootFolder}&fields=_embedded.items.name%2C_embedded.items.path%2C_embedded.items.size%2C_embedded.items.md5%2C_embedded.items.type";
                string url = $"{baseLink}/{resourcLink}?{parameters}";
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = "GET";
                httpRequest.Headers.Add("Authorization", $"OAuth {tokens["Евгений"]}");
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                string result = "";
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                    Console.WriteLine("RESULT:");
                    Console.WriteLine(result);
                    List<ITreeListItem> folderStructure = result.GetMetaInformationFromResponse().ToList();
                    foreach (ITreeListItem itli in folderStructure)
                    {
                        itli.ParentId = FolderId;
                        if (itli is HostFolderItem)
                        {
                            GetFolderContent(itli.Path, itli.Id);
                        }
                        structure.Add(itli);
                    }
                    Console.WriteLine("");
                }
                return true;
            }).Result;

        }

        /// <summary>
        /// Получение метаданных списка файлов и папок.
        /// </summary>
        /// <param name="Response">Ответ от Яндекс диска.</param>
        /// <returns>Возвращает структуру файлов и папок.</returns>
        public static IEnumerable<ITreeListItem> GetMetaInformationFromResponse(this string Response)
        {
            // Поиск между квадратными скобками
            Regex r = new Regex($"\\[(.*?)\\]");
            MatchCollection matchesIds = r.Matches(Response);

            if (matchesIds.Count > 0)
            {
                foreach (Match match in matchesIds)
                {
                    string res = match.Value;
                    if (res == "[]") { continue; }
                    string resCorrect = res.Substring(2, res.Length - 4);
                    string resReplaced = resCorrect.Replace("},{", "•");
                    string[] resSplitted = resReplaced.Split('•');
                    foreach (string item in resSplitted)
                        yield return item.GetITreeListItem();
                }
            }
            else
            {
                Console.WriteLine($@"Совпадений по указанному запросу не найдено");
            }
        }

        /// <summary>
        /// Получение для указанного элемента ответа от Яндекс диска данных.
        /// </summary>
        /// <param name="ResponseItem">Текущий элемент ответа от сервера.</param>
        /// <returns>Данные по указанному элементу.</returns>
        public static ITreeListItem GetITreeListItem(this string ResponseItem)
        {
            string RI_Replaced = ResponseItem.Replace(",\"", "•");
            string RI_Trimmed = RI_Replaced.TrimStart('\"').TrimEnd('\"');
            string[] RI_Splitted = RI_Trimmed.Split('•');
            string path = "";
            string ftyp = "";
            string name = "";
            string md5 = "";
            string size = "";

            if (ResponseItem.Contains("md5"))
            {
                foreach (string itm in RI_Splitted)
                {
                    string item = itm.TrimStart('\"').TrimEnd('\"');
                    if (item.StartsWith("path")) { path = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("size")) { size = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("type")) { ftyp = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("name")) { name = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("md5")) { md5 = item.Substring(6, item.Length - 6); }
                }

                long sizeVal = 0;
                long.TryParse(size, out sizeVal);

                return new HostFileItem()
                {
                    Path = path,
                    Name = name,
                    Md5 = md5,
                    MimeType = ftyp,
                    Size = sizeVal,
                    Type = HostFileSystemItemType.File
                };
            }
            else
            {
                foreach (string itm in RI_Splitted)
                {
                    string item = itm.TrimStart('\"').TrimEnd('\"');

                    if (item.StartsWith("path")) { path = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("type")) { ftyp = item.Substring(7, item.Length - 7); }
                    if (item.StartsWith("name")) { name = item.Substring(7, item.Length - 7); }
                }
                
                return new HostFolderItem()
                {
                    Path = path,
                    Name = name,
                    Type = HostFileSystemItemType.Dir
                };
            }
        }

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Нормализация Url, чтобы сервис понимал ссылку.
        /// </summary>
        /// <param name="Data">Исходная ссылка.</param>
        /// <returns>Нормализованная ссылка для отправки по сети.</returns>
        public static string NormalizeToUrl(this string Data)
        {
            return Data.Replace("//", "/").Replace("/", "%2F").Replace(" ", "%20").Replace(":", "%3C");
        }

        #endregion

        #endregion
    }

    public interface ITreeListItem
    {
        string Name { get; set; }
        string Id { get; set; }
        [Browsable(false)]
        string Path { get; set; }
        string ParentId { get; set; }
        [Browsable(false)]
        HostFileSystemItemType Type { get; set; }
    }

    public enum HostFileSystemItemType
    {
        [Description("Dir")]
        Dir,
        [Description("File")]
        File
    }

    public class HostFolderItem : ITreeListItem
    {
        [Browsable(true)]
        public string Name { get; set; } = "";
        [Browsable(false)]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        [Browsable(false)]
        public string Path { get; set; } = "";
        [Browsable(false)]
        public string ParentId { get; set; } = "";
        [Browsable(false)]
        public long Size { get; set; } = 0;
        [Browsable(false)]
        public HostFileSystemItemType Type { get; set; } = HostFileSystemItemType.Dir;
    }

    public class HostFileItem : ITreeListItem
    {
        [Browsable(true)]
        public string Name { get; set; } = "";
        [Browsable(false)]
        public string Id { get; set; } = System.Guid.NewGuid().ToString();
        [Browsable(false)]
        public string Path { get; set; } = "";
        [Browsable(false)]
        public string ParentId { get; set; } = "";
        [Browsable(false)]
        public string MimeType { get; set; } = "";
        [Browsable(false)]
        public string Md5 { get; set; } = "";
        [Browsable(false)]
        public long Size { get; set; } = 0;
        [Browsable(false)]
        public HostFileSystemItemType Type { get; set; } = HostFileSystemItemType.File;
    }
}
