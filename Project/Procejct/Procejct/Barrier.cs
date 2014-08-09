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

    public class Barrier : DrawableGameComponent
    {
        Texture2D Texture;

        Game1 Game1;

        Body body;

        string TextureName;

        float Density;

        Vector2 Position;

        float angle;

        public Barrier(Game game, Vector2 Position, float angle, string TextureName, float Density)
            : base(game)
        {
            this.Game1 = (Game1)(game);

            this.TextureName = TextureName;

            this.Density = Density;

            this.Position = Position;

            this.angle = (float)(angle * System.Math.PI) / 180;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Texture = Game1.Content.Load<Texture2D>(TextureName);

            PolygonDef poligonDef = new PolygonDef();

            poligonDef.SetAsBox(Texture.Width / 2, Texture.Height / 2);

            poligonDef.Density = Density;

            poligonDef.Friction = 0f;

            BodyDef bodyDef = new BodyDef();

            bodyDef.Position = new Vec2(Position.X, Position.Y);

            bodyDef.Angle = angle;

            body = Game1.world.CreateBody(bodyDef);

            PolygonShape shape = (PolygonShape)body.CreateShape(poligonDef);

            body.SetMassFromShapes();

            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle? r = null;

            var angleis = body.GetAngle();

            Game1.spriteBatch.Draw(Texture, new Vector2(body.GetPosition().X, body.GetPosition().Y), r, Microsoft.Xna.Framework.Color.Black, body.GetAngle(), new Vector2(Texture.Width / 2, Texture.Height / 2), 1, SpriteEffects.None, 0);
            
            base.Draw(gameTime);
        }

    }
}
