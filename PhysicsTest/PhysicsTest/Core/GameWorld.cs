using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.ViewportAdapters;
using FarseerPhysics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace PhysicsTest
{
    class GameWorld : World
    {
        public SpriteFont spFont { get; set; }
        private World world;
        Body P1Body;
        public PlayerActor P1 { get; set; }
        World PhysicsWorld { get => world; set => world = value; }
        public StaticBodies StaticSolids { get; set; }
        float DefMass { get; set; }
        float DefRestitution { get; set; }
        float DefDensity { get; set; }
        public GameWorld(Texture2D PlayerTex, Vector2 gravity) : base(gravity)
        {
            P1Body = BodyFactory.CreateCircle(this, 24f, 1f, new Vector2(150f, 150f), "Player1");
            P1Body.BodyType = BodyType.Dynamic;
            P1Body.Friction = .2f;
            P1Body.Restitution = .5f;
            P1 = new PlayerActor(PlayerTex, ref P1Body);

        }

        public bool PopulateWorldWithStaticBodies()
        {
            StaticSolids = new StaticBodies(this, 200f,
               400f);


            return true;

        }
        public void Update(GameTime gt)
        {
            this.Step(gt.GetElapsedSeconds());

        }
        public void Draw(SpriteBatch sp)
        {
            Console.WriteLine("Draw Called");
            foreach (Body b in this.BodyList)
            {
                foreach (Fixture f in b.FixtureList)
                {
                    switch (f.Shape.ShapeType)
                    {
                        case ShapeType.Chain:
                            ChainShape chs = (ChainShape)f.Shape;
                            break;
                        case ShapeType.Circle:
                            CircleShape cs = (CircleShape)f.Shape;
                            break;
                        case ShapeType.Edge:
                            EdgeShape es = (EdgeShape)f.Shape;
                            ShapeExtensions.DrawLine(sp, es.Vertex1, es.Vertex2, Color.White, 3f);
                            break;
                        case ShapeType.Polygon:
                            PolygonShape ps = (PolygonShape)f.Shape;
                            break;
                        case ShapeType.Unknown:
                            Shape s = f.Shape;
                            break;
                    }
                }
            }
            P1.Draw(sp);
            sp.DrawString(spFont, P1.PhysxBody.Position.ToString(), new Vector2(100f, 100f), Color.White);

        }

    }
}
