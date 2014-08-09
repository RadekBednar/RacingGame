using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;

namespace Procejct
{
    class Json
    {
        public static List<Barrier> LoadBarriers(Game1 game1)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string classes = "";

            List<Barrier> BarrierList = new List<Barrier>();

            using (StreamReader sr = new StreamReader("barriers.js"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    classes += line;
                }
            }

            Barriers dict = serializer.Deserialize<Barriers>(classes);

            foreach (LoadBarrier b in dict.data)
            {
                BarrierList.Add(new Barrier(game1, new Microsoft.Xna.Framework.Vector2(b.x, b.y), b.angle, b.texture, b.density));
            }

            return BarrierList;
        }
    }
}
