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


namespace Procejct
{
    public class Car : DrawableGameComponent
    {
        public Texture2D Texture;

        public Model CarModel;

        Game1 Game1;

        public Body body;

        float Density;

        float Friction;

        float Angle;

        float Speed;

        public Car(Game game, float Density, float Friction)
            : base(game)
        {
            this.Game1 = (Game1)(game);

            this.Density = Density;

            this.Friction = Friction;
        }

        public override void Initialize()
        {  
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture = Game1.Content.Load<Texture2D>("Ferrari");

            CarModel = Game.Content.Load<Model>("Model2");

            PolygonDef polygonDef = new PolygonDef();

            polygonDef.SetAsBox(Texture.Width / 2, Texture.Height / 2);

            polygonDef.Density = Density;

            polygonDef.Friction = Friction;

            BodyDef bodyDef = new BodyDef();

            bodyDef.Position = new Vec2(Game1.Window.ClientBounds.Width / 2, Game1.Window.ClientBounds.Height / 2);

            bodyDef.LinearDamping = 0.01f;

            bodyDef.AngularDamping = 0.01f;

            body = Game1.world.CreateBody(bodyDef);

            PolygonShape shape = (PolygonShape)body.CreateShape(polygonDef);

            body.SetMassFromShapes();

            Angle = 0f;

            Speed = 0f;

           

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            Vec2 v = new Vec2((float)System.Math.Sin(Angle), (float)System.Math.Cos(Angle)) * Speed;

            body.ApplyForce(body.GetWorldVector(v), body.GetWorldPoint(new Vec2(0, -(Texture.Height / 2) + 10)));

            if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Speed -= 0.01f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (Speed > 0)
                {
                    Speed += 0.01f;
                }
                else
                {
                    Speed += 0.1f;
                }
            }
            else
            {     
                if (Speed > 0)
                {
                    Speed -= 0.01f;
                }
                else
                {
                    Speed += 0.01f; 
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Right) && Angle >= -1 * (System.Math.PI / 4))
            {
                Angle -= 0.01f;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left) && Angle <= (System.Math.PI / 4))
            {
                Angle += 0.01f;
            }
            else
            {
                if (Angle < 0)
                {
                    Angle += 0.01f;
                }
                else
                {
                    Angle -= 0.01f;
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            /*Rectangle? r = null;

            Game1.spriteBatch.Draw(Texture, new Vector2(body.GetPosition().X, body.GetPosition().Y), r, Microsoft.Xna.Framework.Color.White, body.GetAngle(), new Vector2(Texture.Width / 2, Texture.Height / 2), 1, SpriteEffects.None, 0);
           */

            Matrix[] transforms = new Matrix[CarModel.Bones.Count];

            CarModel.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (ModelMesh mesh in CarModel.Meshes)
            {

                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.World = transforms[mesh.ParentBone.Index];

                    effect.View = Matrix.CreateLookAt(new Vector3(-15, 0, 0), Vector3.Zero, Vector3.Up);

                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), Game1.graphics.GraphicsDevice.Viewport.AspectRatio, 1.0f, 10000.0f);
                }

                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}
