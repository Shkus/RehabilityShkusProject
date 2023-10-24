using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
    public static class YandexDiskManager
    {
        public static Dictionary<string, string> tokens = new Dictionary<string, string>();

        public static bool IsInitializedTokes = false;

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
        }

        public static bool CreateFolder(string TargetFolder, string NewFolder, string name)
        {
            return Task<bool>.Run(async () =>
            {
                if (IsInitializedTokes == false)
                {
                    Init();
                    IsInitializedTokes = true;
                }

                int age = 10;
                double height = 175;
                string str = "Ваш возраст: " + age + " лет," + height + " мм";
                string str2 = $"Ваш возраст: {age} лет, {height} мм";
                string str3 = string.Format("Ваш возраст: {0} лет, {1} мм", age, height);

                string Target = $"{TargetFolder.Substring(1, TargetFolder.Length - 2)}/{NewFolder}".NormalizeToUrl();
                string baseLink = "https://cloud-api.yandex.net"; // cloud-api.yandex.net
                string resourcLink = "v1/disk/resources"; // v1/disk/resources
                //string parameters = $"path={Target}&force_async=true"; // path=Test%2FVasiliy
                string parameters = $"path={Target}"; // path=Test%2FVasiliy
                string url = $"{baseLink}/{resourcLink}?{parameters}"; // https://cloud-api.yandex.net/v1/disk/resources?path=VS%20folder%2F12345
                var httpRequest = (HttpWebRequest)WebRequest.Create(url); // https://cloud-api.yandex.net/v1/disk/resources?path=Test%2FVasiliy
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

        public static string NormalizeToUrl(this string Data)
        {
            return Data.Replace("//", "/").Replace("/", "%2F").Replace(" ", "%20").Replace(":", "%3C");
        }

    }
}
