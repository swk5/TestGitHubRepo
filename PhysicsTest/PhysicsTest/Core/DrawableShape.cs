using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using MonoGame.Extended.Shapes;
using MonoGame.Extended;
using MonoGame.Extended.Graphics;
using MonoGame.Utilities;
using MonoGame;
using FarseerPhysics;
using MonoGame.Extended.Sprites;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsTest
{
    public class DrawableShape
    {
        private Shape _shape;
        private EdgeShape _es;
        private CircleF _cf;
        private Polyline _ef;
        private Polygon _pf;
        private CircleShape _cs;
        private PolygonShape _ps;
        private float _rotation;

        private ShapeType _type = ShapeType.Unknown;
        private Vector2 _bodyPosition;
        private Vector2 _edgeShapeInfo;


        public DrawableShape(PolygonShape ps, ShapeType type, Vector2 bodyPosition)
        {
            _ps = ps ?? throw new ArgumentNullException(nameof(ps));
            _shape = _ps;
            _type = type;
            _bodyPosition = bodyPosition;
            _pf = new Polygon(_ps.Vertices);
        }

        public DrawableShape(EdgeShape es, ShapeType type, Vector2 bodyPosition, Vector2 edgeShapeInfo)
        {
            _es = es ?? throw new ArgumentNullException(nameof(es));
            _bodyPosition = bodyPosition;
            _edgeShapeInfo = edgeShapeInfo;
            _type = type;
        }

        public DrawableShape(CircleShape cs, ShapeType type, Vector2 bodyPosition)
        {
            _cs = cs ?? throw new ArgumentNullException(nameof(cs));
            _type = type;
            _bodyPosition = bodyPosition;
            _cf = new CircleF(new Point2(_bodyPosition.X, _bodyPosition.Y), _cs.Radius);
        }

        public DrawableShape(Shape shape, EdgeShape es, CircleShape cs, PolygonShape ps, ShapeType type, Vector2 bodyPosition, Vector2 edgeShapeInfo, float circleRadius, float somethingelse)
        {
            _shape = shape ?? throw new ArgumentNullException(nameof(shape));
            _es = es ?? null;
            _cs = cs ?? null;
            _ps = ps ?? null;
            _type = type;
            _bodyPosition = bodyPosition;
            _edgeShapeInfo = edgeShapeInfo;
        }


        public void Draw(SpriteBatch sp, Color color, float thickness)
        {
            switch (_type)
            {
                case ShapeType.Circle:
                    {
                        sp.DrawCircle(_cf, 25, color, thickness);
                        break;
                    }
                case ShapeType.Edge:
                    {

                        sp.DrawLine(_es.Vertex1, _es.Vertex2, color, thickness);
                        break;
                    }
                case ShapeType.Polygon:
                    {

                        sp.DrawPolygon(_bodyPosition, _pf, Color.Black, thickness);
                        break;
                    }
                case ShapeType.Unknown:
                    {
                        Console.WriteLine("Shape Type Unknown!");
                        break;
                    }
            }
        }


        public void SetRotation(float r)
        {
            _rotation = r;
        }

        public PolygonShape Ps { get => _ps; set => _ps = value; }
        public CircleShape Cs { get => _cs; set => _cs = value; }
        public EdgeShape Es { get => _es; set => _es = value; }
        public Shape Shape { get => _shape; set => _shape = value; }
        public ShapeType Type { get => _type; set => _type = value; }
        public Vector2 BodyPosition { get => _bodyPosition; set => _bodyPosition = value; }
        public Vector2 EdgeShapeInfo { get => _edgeShapeInfo; set => _edgeShapeInfo = value; }
        public float Rotation { get => _rotation; set => _rotation = value; }
    }

}
