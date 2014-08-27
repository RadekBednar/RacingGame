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
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;


namespace Project
{
    public class Object : DrawableGameComponent
    {
        Model Model;

        Body Body;

        Vec2[] CollisionBody;

        Vector3 Position;

        float Density;

        float Scale;

        Game1 Game1;

        public Object(Game game, Vector3 Position, Model Model, float Density, float Scale, Vec2[] CollisionBody)
            : base(game)
        {
            this.Game1 = (Game1)(game);

            this.Position = Position;

            this.Model = Model;

            this.Density = Density;

            this.Scale = Scale;

            this.CollisionBody = CollisionBody;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            PolygonDef poligonDef = new PolygonDef();

            //poligonDef.Vertices = CollisionBody;

            //poligonDef.VertexCount = CollisionBody.Length;

            //poligonDef.SetAsBox(20, 20);

            poligonDef.Vertices = new Vec2[]
            {
                new Vec2(-35, -35),
                new Vec2(-45, 0),
                new Vec2(-35, 35),
                new Vec2(0, 45),
                new Vec2(35, 35),
                new Vec2(45, 0),
                new Vec2(35, -35),
                new Vec2(0, -45)
            };

            poligonDef.VertexCount = 8;

            poligonDef.Density = 20f;

            poligonDef.Friction = 1f;

            BodyDef bodyDef = new BodyDef();

            bodyDef.Position = new Vec2(Position.X, Position.Y);

            Body = Game1.world.CreateBody(bodyDef);

            PolygonShape shape = (PolygonShape)Body.CreateShape(poligonDef);

            Body.SetMassFromShapes();

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Matrix[] transforms = new Matrix[Model.Bones.Count];

            Model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in Model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.World = transforms[mesh.ParentBone.Index] * Matrix.CreateScale(Scale) * Matrix.CreateTranslation(new Vector3(Body.GetPosition().X, Body.GetPosition().Y, 0));

                    effect.View = Camera.GetView();
                    
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), Game1.graphics.GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);
                }

                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }

    public class ObjectData
    {
        public Vector3 Position { get; set; }

        public string ModelName { get; set; }

        public float Density { get; set; }

        public float Scale { get; set; }

        public Vec2[] CollisionBody { get; set; }

        public ObjectData()
        {

        }
    }
}
