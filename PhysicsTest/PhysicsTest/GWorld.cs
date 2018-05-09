using FarseerPhysics.Dynamics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Factories;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsTest
{
    class GWorld : World
    {
        private Texture2D[] textures;
        private SpriteFont font;
        private GameTime gt;
        private float dt = 1f / 30f;
        private KeyboardState ks;
        private MouseState ms;
        private float d = 31f;
        private float f = .2f;
        private float r = .125f;
        private Vector2 impulse = Vector2.Zero;
        private float horizontalImpulse = 0f;
        private float verticalImpulse = 0f;
        private Dictionary<int, Color> colrs;
        private Vector2 bounds;
        private float thickness = 2f;
        private List<Body> bodies;
        private List<Body> staticBodies;
        private List<Body> dynamicBodies;
        private PolygonShape ps;
        private CircleShape cs;
        private EdgeShape es;
        private ChainShape chs;
        private Shape genericShape;
        private CircleF cf;
        private RectangleF rf;
        private Fixture fix;
        private Vector2 location;
        private Body curBody;



        public PlayerActor P1;
        public Body P1Body;
        public List<Body> Bodies { get => bodies; }
        public List<Body> StaticBodies { get => StaticBodies; }
        public List<Body> DynamicBodies { get => DynamicBodies; }

        public DrawableShapes DrawableShapes { get; set; }



        public GWorld(Vector2 gravity, SpriteFont spFont = null, Texture2D[] tex2ds = null, Vector2? winSize = null) : base(gravity)
        {
            DrawableShapes = new DrawableShapes();
            bodies = new List<Body>();
            staticBodies = new List<Body>();
            dynamicBodies = new List<Body>();
            if (!(tex2ds == null)) { textures = tex2ds; }
            if (!(spFont == null)) { font = spFont; }
            colrs = new Dictionary<int, Color>();
            colrs.Add(0, Color.White);
            colrs.Add(1, Color.Red);
            colrs.Add(2, Color.Blue);
            colrs.Add(3, Color.Black);
            if (winSize.HasValue)
            {
                bounds = winSize.Value;
                Vector2 x1, x2, x3, x4;
                x1 = new Vector2(3f, 3f);
                x2 = new Vector2(bounds.X - 3f, 3f);
                x3 = new Vector2(bounds.X - 3f, bounds.Y - 3f);
                x4 = new Vector2(3f, bounds.Y - 3f);
                Body[] edges = new Body[4];
                edges[0] = BodyFactory.CreateEdge(this, x1, x2);
                edges[1] = BodyFactory.CreateEdge(this, x2, x3);
                edges[2] = BodyFactory.CreateEdge(this, x3, x4);
                edges[3] = BodyFactory.CreateEdge(this, x4, x1);
                for (int i = 0; i < 4; i++)
                {
                    edges[i].BodyType = BodyType.Static;
                    edges[i].Friction = .125f;
                    edges[i].Restitution = .5f;
                    NewBody(ref edges[i]);
                }
                Body temp = BodyFactory.CreateCircle(this, 12f, d, new Vector2(20f, 100f), null);
                temp.BodyType = BodyType.Dynamic;
                temp.Friction = f;
                temp.Restitution = r;

                NewBody(ref temp);

            }
        }

        public void Update(GameTime Gt)
        {
            Console.WriteLine("Update Called");
            this.Step(Gt.GetElapsedSeconds());
            //PrepDraw();
        }
        public void Update(float Dt)
        {
            Console.WriteLine("Update Called");
            this.Step(Dt);
            this.Step(Dt);
            this.Step(Dt);
            PrepDraw();
        }
        public void PrepDraw()
        {
            Console.WriteLine("PrepDraw Called.  Body Count: " + bodies);
            DrawableShapes.Clear();
            foreach (Body b in this.BodyList)
            {
                foreach (Fixture f in b.FixtureList)
                {
                    genericShape = f.Shape;
                    switch (genericShape.ShapeType)
                    {
                        case ShapeType.Edge:
                            {
                                es = (EdgeShape)f.Shape;
                                DrawableShapes.Add(new DrawableShape(es, ShapeType.Edge, b.Position, Vector2.Zero));
                                break;
                            }
                        case ShapeType.Polygon:
                            ps = (PolygonShape)f.Shape;
                            DrawableShapes.Add(new DrawableShape(ps, ShapeType.Polygon, b.Position));
                            break;
                        case ShapeType.Circle:
                            cs = (CircleShape)f.Shape;
                            DrawableShapes.Add(new DrawableShape(cs, ShapeType.Circle, b.Position));
                            break;
                        case ShapeType.Chain:
                            break;
                        case ShapeType.Unknown:
                            break;
                    }
                }
            }
        }
        public void Draw(SpriteBatch sp)
        {
            Console.WriteLine("Drawing " + DrawableShapes.Count.ToString() + " Shapes");
            //DrawableShapes.DrawAll(sp);
            foreach (Body b in this.BodyList)
            {
                foreach (Fixture f in b.FixtureList)
                {
                    genericShape = f.Shape;
                    switch (genericShape.ShapeType)
                    {
                        case ShapeType.Edge:
                            es = (EdgeShape)f.Shape;
                            sp.DrawLine(es.Vertex1, es.Vertex2, colrs[1], thickness);
                            break;
                        case ShapeType.Circle:
                            cs = (CircleShape)f.Shape;
                            cf = new CircleF(b.Position, cs.Radius);
                            sp.DrawCircle(cf, 20, colrs[3], thickness);
                            break;

                        case ShapeType.Polygon:
                            ps = (PolygonShape)f.Shape;
                            Polygon pf = new Polygon(ps.Vertices);
                            pf.Rotate(b.Rotation);
                            sp.DrawPolygon(b.Position, pf, colrs[3], thickness);

                            break;

                    }
                }
            }
        }
        public void NewBody(ref Body b)
        {
            switch (b.BodyType)
            {
                case BodyType.Dynamic:
                    dynamicBodies.Add(b);
                    bodies.Add(b);
                    Console.WriteLine("Successfully Added Dynamic Body.\n\t\t\t +++ Debug Info +++\n∙ Mass: " + b.Mass.ToString() + "\n∙ Position: " + b.Position.ToString() + "\n∙ Velocity(L): " + b.LinearVelocity.ToString() + "\n∙ ToString: " + b.ToString());
                    break;
                case BodyType.Static:
                    staticBodies.Add(b);
                    bodies.Add(b);
                    Console.WriteLine("Successfully Added Static Body.\n\t\t\t +++ Debug Info +++\n∙ Position: " + b.Position.ToString() + "\n∙ ToString: " + b.ToString());
                    break;
            }



        }

    }
}
