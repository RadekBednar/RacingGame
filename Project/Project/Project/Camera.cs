using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Box2DX.Common;

namespace Project
{
    public class Camera
    {
        Car car;

        Game1 Game1;

        //public Matrix MainView;

        public float angleX;

        public float angleZ;

        public Camera(Car car, Game1 game1)
        {
            this.car = car;

            this.Game1 = game1;

            this.angleX = 0;

            this.angleZ = 0;

            //MainView = Matrix.CreateLookAt(new Vector3(0, -10, 10), Vector3.Zero, Vector3.Up); //(0, 0, 5) !!!

            //-MathHelper.PiOver4 - 0.2f
        }

        public Matrix GetBetterView()
        {
            return Matrix.CreateTranslation(-new Vector3(car.Body.GetPosition().X, car.Body.GetPosition().Y, 0)) * Matrix.CreateRotationZ(-car.Body.GetAngle()) * Matrix.CreateRotationZ(angleZ) * Matrix.CreateRotationX(angleX)  * Matrix.CreateLookAt(new Vector3(0, 0, 7f), new Vector3(0, 0, 0), Vector3.Up);
        }

        public Matrix GetProjection()
        {
            //return Matrix.CreateOrthographic(Game1.GraphicsDevice.Viewport.Width / 50, Game1.GraphicsDevice.Viewport.Height / 50, -30f, 100);

            //return Matrix.CreatePerspectiveOffCenter(-Game1.graphics.PreferredBackBufferWidth / 2, -Game1.graphics.PreferredBackBufferHeight / 2, Game1.graphics.PreferredBackBufferWidth, Game1.graphics.PreferredBackBufferHeight, 0.1f, 100f);

            //return Matrix.CreatePerspectiveOffCenter(-0.5f, 0.5f, -0.5f, 0.5f, 0.1f, 100);

            return Matrix.CreatePerspectiveFieldOfView(1, Game1.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100);
        }
    }
}
