using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FinalProject.Model;
using Newtonsoft.Json;

namespace FinalProject.Service
{
    class JsonReader
    {
        public static List<Exercise> eList;

        public static void LoadJson()
        {
            eList = DeserializeObjects<Exercise>(GetFileContents("csvjson.json")).ToList();
        }

        public static IEnumerable<T> DeserializeObjects<T>(string input)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (var strreader = new StringReader(input))
            using (var jsonreader = new JsonTextReader(strreader))
            {
                //you should use this line
                jsonreader.SupportMultipleContent = true;
                while (jsonreader.Read())
                {
                    yield return serializer.Deserialize<T>(jsonreader);
                }

            }
        }

        public static string GetFileContents(string fname)
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(JsonReader)).Assembly;
            string namespaceName = "FinalProject";
            Stream stream = assembly.GetManifestResourceStream(namespaceName + "." + fname);
            string text = "";
            using (var dictReader = new System.IO.StreamReader(stream))
            {
                text = dictReader.ReadToEnd();
            }
            return text;
        }
    }
}
