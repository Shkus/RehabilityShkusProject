using System.IO;
using System.Xml.Serialization;

namespace RehabilityApplication.CoreLib
{
    public class ClassObject
    {
        public static void Serialize(object obj, string path)
        {
            System.IO.StreamWriter strWrt = new StreamWriter(path);
            System.Xml.Serialization.XmlSerializer x = new XmlSerializer(obj.GetType());
            x.Serialize(strWrt, obj);
            strWrt.Close();
        }

        public static object Deserialize(object obj, string path)
        {
            System.IO.StreamReader strRdr = new StreamReader(path);
            System.Xml.Serialization.XmlSerializer x = new XmlSerializer(obj.GetType());
            obj = x.Deserialize(strRdr);
            strRdr.Close();
            return obj;
        }
    }
}
