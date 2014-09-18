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
        public static MapData GetMap(string Name)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string Content = "";

            using (StreamReader sr = new StreamReader("Data/Maps/" + Name + "/JSON.js"))
            {
                Content = sr.ReadToEnd();
            }

            return serializer.Deserialize<MapData>(Content);
        }

        public static CarData GetCar(string Name)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string Content = "";

            using (StreamReader sr = new StreamReader("Data/Cars/" + Name + ".js"))
            {
                Content = sr.ReadToEnd();
            }

            return serializer.Deserialize<CarData>(Content);
        }
    }
}
