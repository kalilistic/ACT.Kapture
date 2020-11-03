using System;
using System.IO;
using System.Xml.Serialization;

namespace ACT_FFXIV.Aetherbridge
{
	public static class ConfigSerializer
	{
		public static void WriteXml(string filePath, dynamic objectToWrite)
		{
			try
			{
				using (var writer = new StreamWriter(filePath))
				{
					var ns = new XmlSerializerNamespaces();
					ns.Add(string.Empty, string.Empty);
					var serializer = new XmlSerializer(objectToWrite.GetType());
					serializer.Serialize(writer, objectToWrite, ns);
					writer.Flush();
				}
			}
			catch (Exception)
			{
				// ignored
			}
		}

		public static dynamic ReadXml(string filePath, dynamic objectToWrite)
		{
			if (!File.Exists(filePath)) return null;
			using (var stream = File.OpenRead(filePath))
			{
				try
				{
					var serializer = new XmlSerializer(objectToWrite.GetType());
					return serializer.Deserialize(stream);
				}
				catch (Exception)
				{
					// ignored
				}

				stream.Dispose();
			}

			return null;
		}
	}
}