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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;

        public SpriteBatch spriteBatch;

        public World world;

        Camera camera;

        Car car;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;

            graphics.PreferredBackBufferWidth = 1000;
        }

        protected override void Initialize()
        {
            AABB aabb = new AABB();

            aabb.LowerBound = new Vec2(-1000, -1000);
            aabb.UpperBound = new Vec2(1000, 1000);

            world = new World(aabb, new Vec2(0, 0), false);

            car = new Car(this, 0.1f, 1f);

            Components.Add(car);

            List<Barrier> BarrierList = Json.LoadBarriers(this);

            foreach(Barrier b in BarrierList)
            {
                Components.Add(b);
            }

            camera = new Camera(GraphicsDevice.Viewport);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {

        }

        protected override void Update(GameTime gameTime)
        {
            world.Step(gameTime.ElapsedGameTime.Milliseconds, 6, 2);

            camera.Update(gameTime, car);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);

            base.Draw(gameTime);

            spriteBatch.End();
        }
    }
}
