using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Box2DX.Dynamics;
using Box2DX.Collision;
using Box2DX.Common;

namespace Procejct
{
    class Camera
    {
        public Matrix transform;

        public Viewport viewport;

        public Vector2 centre;

        public Camera(Viewport newView)
        {
            viewport = newView;
            transform = Matrix.CreateTranslation(0, 0, 0);
            centre = Vector2.Zero;
        }

        public void Update(GameTime gt, Car car)
        {

            Vec2 CarPosition = car.body.GetWorldCenter();

            centre = new Vector2(CarPosition.X - viewport.Bounds.Width / 2, CarPosition.Y - viewport.Bounds.Height / 2);

            transform = Matrix.CreateTranslation(new Vector3(-centre.X, -centre.Y, 0)) * Matrix.CreateTranslation(new Vector3(-viewport.Width / 2, -viewport.Height / 2, 0))
                * Matrix.CreateRotationZ(-car.body.GetAngle())
                * Matrix.CreateTranslation(new Vector3(viewport.Width / 2, viewport.Height / 2, 0));/**  * Matrix.CreateScale(new Vector3(1, 1, 0));*/;
        }
    }
}
