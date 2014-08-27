using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;

namespace Project
{
    public class Json
    {
        public static JsonData GetMap(string Name)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string Content = "";

            using (StreamReader sr = new StreamReader("Data/Maps/" + Name + "/JSON.js"))
            {
                Content = sr.ReadToEnd();
            }

            return serializer.Deserialize<JsonData>(Content);
        }
    }

    public class JsonData
    {
        public List<MapPartData> MapPartsData { get; set; }

        public List<ObjectData> ObjectsData { get; set; }

        public JsonData()
        {

        }
    }
}
