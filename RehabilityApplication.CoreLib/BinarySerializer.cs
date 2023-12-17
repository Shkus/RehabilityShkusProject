using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace RehabilityApplication.CoreLib
{
	public static class BinarySerializer
	{
		public static void SaveObject(string pathSerializeTo, object sourceObjectForSerialization)
		{
			try
			{
				using (Stream output = File.Create(pathSerializeTo))
				{
					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(output, sourceObjectForSerialization);
				}
			}
			catch (Exception ex)
			{
			}
		}

		public static object OpenObject(string pathDeserializeFrom)
		{
			try
			{
				using (Stream inputStream = File.OpenRead(pathDeserializeFrom))
				{
					BinaryFormatter binaryFormatter = new BinaryFormatter();
					return binaryFormatter.Deserialize(inputStream);
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

	}
}
