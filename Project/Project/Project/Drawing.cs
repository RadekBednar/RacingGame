using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class Drawing
    {
        public static void ArrayVectors(Vector2[] Array, Game1 Game1)
        {
            var vectors = Array.Concat(Array.Take(1)).Select((v) => new VertexPositionColor(new Vector3(v.X, v.Y, 0.2f), Microsoft.Xna.Framework.Color.Red)).ToArray();

            var Effect = Game1.basicEffect;

            Effect.World = Matrix.Identity;

            Effect.View = Game1.camera.GetBetterView();//Matrix.CreateScale(1) * Matrix.CreateLookAt(Vector3.Backward, Vector3.Zero, Vector3.Up);

            Effect.Projection = Game1.camera.GetProjection();//Matrix.CreateOrthographic(Game1.GraphicsDevice.Viewport.Width, Game1.GraphicsDevice.Viewport.Height, 0.1f, 10);

            Effect.VertexColorEnabled = true;

            foreach (EffectPass pass in Effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                Game1.GraphicsDevice.DrawUserPrimitives(PrimitiveType.LineStrip, vectors, 0, vectors.Length - 1);
            }

            Effect.VertexColorEnabled = false;
        }
    }
}
