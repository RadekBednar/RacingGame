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
    public class MapPart : DrawableGameComponent
    {
        public Vector3 Position;

        public string Type;

        public Texture2D Texture;

        public Model Plane;

        public Game1 Game1;

        public string MapName;

        public MapPart(Game game, Vector3 Position, string Type, Texture2D Texture)
            : base(game)
        {
            this.Game1 = (Game1)(game);

            this.Position = Position;

            this.Type = Type;

            this.Texture = Texture;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            this.Plane = Game1.Content.Load<Model>("Plane");
            
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Matrix[] transforms = new Matrix[Plane.Bones.Count];

            Plane.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in Plane.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {

                    effect.TextureEnabled = true;

                    effect.Texture = Texture;

                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateTranslation(Position);

                    effect.View = Game1.camera.GetBetterView();

                    effect.Projection = Game1.camera.GetProjection();//Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), Game1.graphics.GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);
                }

                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }


    public class MapPartData
    {
        public Vector3 Position { get; set; }

        public string TextureName { get; set; }

        public string Type { get; set; }

        public MapPartData()
        {

        }
    }
}
