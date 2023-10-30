using System.IO;
using System.Security.Cryptography;

namespace RehabilityApplication.CoreLib
{
    public class FileManager
    {
        public static string GetMd5(string FilePath)
        {
            byte[] hash = File.ReadAllBytes(FilePath);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] hashenc = md5.ComputeHash(hash);
            string result = "";
            foreach (var b in hashenc)
            {
                result += b.ToString("x2");
            }
            return result;
        }
    }
}
