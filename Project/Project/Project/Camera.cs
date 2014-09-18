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

        public Matrix MainView;

        public Camera(Car car)
        {
            this.car = car;

            MainView = Matrix.CreateLookAt(new Vector3(0, -10, 10), Vector3.Zero, Vector3.Up); //(0, 0, 5) !!!
        }

        public Matrix GetBetterView()
        {
            return Matrix.CreateLookAt(new Vector3(car.Body.GetPosition().X, car.Body.GetPosition().Y, 10), new Vector3(car.Body.GetPosition().X, car.Body.GetPosition().Y, 0), Vector3.Up) /** Matrix.CreateRotationZ(car.Body.GetAngle())*/;
        }
    }
}
