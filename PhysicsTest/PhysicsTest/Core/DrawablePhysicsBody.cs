
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Common;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.ViewportAdapters;
using FarseerPhysics;
using FarseerPhysics.Controllers;
namespace PhysicsTest
{
    class DrawablePhysicsBody : Body
    {
        Shape BodyShape { get; set; }

        public DrawablePhysicsBody(World world, Vector2? position = null, float rotation = 0, object userdata = null) : base(world, position, rotation, userdata)
        {
            if (FixtureList[0] != null)
            {
                if (FixtureList[0].Shape != null)
                {
                    BodyShape = FixtureList[0].Shape;
                }
            }
        }
        public void Draw(SpriteBatch sp)
        {
            switch (BodyShape.ShapeType)
            {
                case ShapeType.Circle:
                    sp.DrawCircle(Position, BodyShape.Radius, 25, Color.White, 1f);
                    break;
                case ShapeType.Polygon:
                    PolygonShape ps = (PolygonShape)BodyShape;
                    Polygon poly = new Polygon(ps.Vertices);
                    sp.DrawPolygon(Position, poly, Color.White, 1f);
                    break;

            }
        }
    }
}

