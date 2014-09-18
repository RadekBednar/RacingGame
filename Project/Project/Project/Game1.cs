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
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;

        public SpriteBatch spriteBatch;

        public BasicEffect basicEffect;

        public World world;

        public Camera camera;

        public Car car;

        /*public Vector2[] Array = new Vector2[]
        {
            new Vector2(-35, -35),
            new Vector2(-35, 35),
            new Vector2(35, 35),
            new Vector2(35, -35)
        };

        
            
            new Vector2(-45, 0),
            ,
            new Vector2(0, 45),
            ,
            new Vector2(45, 0),
            ,
            new Vector2(0, -45)
        */

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            AABB aabb = new AABB();

            aabb.LowerBound = new Vec2(-10000, -10000);

            aabb.UpperBound = new Vec2(10000, 10000);

            world = new World(aabb, new Vec2(0, 0), false);

            basicEffect = new BasicEffect(this.GraphicsDevice);

            basicEffect.DiffuseColor = new Vector3(1, 1, 1);

            Components.Add(new Map(this, "MainMap"));

            CarData cd = Json.GetCar("BMW");

            car = new Car(this, cd.Position, cd.CollisionBody, cd.ModelName, cd.Density, cd.Friction, cd.Scale, cd.Angle);

            Components.Add(car);

            camera = new Camera(car);

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

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

            //Drawing.ArrayVectors(Array, this);

            base.Draw(gameTime);
        }
    }
}
