using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Project
{
    public class Map : DrawableGameComponent
    {
        public Game1 Game1;

        public string MapName;

        public List<MapPart> MapParts;

        public List<Object> MapObjects;
       
        public Map(Game game, string MapName)
            : base(game)
        {
            this.Game1 = (Game1)(game);

            this.MapName = MapName;
        }

        protected override void LoadContent()
        {
            JsonData Data = Json.GetMap(MapName);

            MapParts = new List<MapPart>();

            MapObjects = new List<Object>();

            foreach (MapPartData mp in Data.MapPartsData)
            {
                Texture2D tx = Texture2D.FromStream(Game1.GraphicsDevice, File.OpenRead("Data/Maps/" + MapName + "/Textures/" + mp.TextureName));

                MapPart part = new MapPart(Game1, mp.Position, mp.Type, tx);

                Game1.Components.Add(part);

                MapParts.Add(part);
            }

            foreach (ObjectData od in Data.ObjectsData)
            {
                Model m = Game1.Content.Load<Model>(od.ModelName);

                Object obj = new Object(Game1, od.Position, m, od.Density, od.Scale, od.CollisionBody);

                Game1.Components.Add(obj);

                MapObjects.Add(obj);
            }

            base.LoadContent();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
