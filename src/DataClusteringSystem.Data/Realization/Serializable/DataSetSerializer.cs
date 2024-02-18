using System;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text.Json;

using DataClusteringSystem.Data.Realization.Math;
using DataClusteringSystem.Data.Abstraction.Math;

namespace DataClusteringSystem.Data.Realization.Serializable
{
    public static class DataSetSerializer
    {
        public static IMathSet SetToIMathSet(SerializableSet set)
        {
            MathSet mathSet = new MathSet((UInt32)set.Points.Max(p => p.Coordinates.Length));
            set.Points.ForEach((SerializablePoint p) => { mathSet.Add(new MathPoint(p)); });
            return mathSet;
        }

        public static String SetToJson(SerializableSet set)
        {
            return JsonSerializer.Serialize<SerializableSet>(set);
        }

        public static String MathSetToJson(IMathSet mathSet)
        {
            return DataSetSerializer.SetToJson(mathSet.SerializableSet);
        }

        public static SerializableSet JsonToSet(String jsonStrnig)
        {
            return JsonSerializer.Deserialize<SerializableSet>(jsonStrnig);
        }

        public static IMathSet JsonToMathSet(String jsonStrnig)
        {
            return DataSetSerializer.SetToIMathSet(DataSetSerializer.JsonToSet(jsonStrnig));
        }

        public static void SaveToXmlFile(String fileName, SerializableSet set)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (!fileInfo.Directory.Exists)
            {
                fileInfo.Directory.Create();
            }

            if (!fileInfo.Exists)
            {
                using (StreamWriter stream = new StreamWriter(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SerializableSet));
                    serializer.Serialize(stream, set);
                }
                return;
            }
            throw new IOException("файл с таким именем уже существует");
        }

        public static SerializableSet LoadFromXmlFile(String fileName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                using (StreamReader stream = new StreamReader(fileName))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(SerializableSet));
                    return (SerializableSet)serializer.Deserialize(stream);
                }
            }
            throw new FileNotFoundException("файл с таким имененм не найден");
        }
    }
}