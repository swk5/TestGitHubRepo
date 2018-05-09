using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using FarseerPhysics.Collision;
using FarseerPhysics.Factories;
using FarseerPhysics.Collision.Shapes;

namespace PhysicsTest
{
    class StaticBodies : List<Body>
    {

        List<Body> _bodies;
        List<Shape> _shapes;
        List<Vector2> _b;



        public StaticBodies(World world, float height, float width) : base()
        {
            _b = new List<Vector2>();
            _b.Add(new Vector2(0f, 0f));
            _b.Add(new Vector2(0f, width));
            _b.Add(new Vector2(height, width));
            _b.Add(new Vector2(height, 0f));
            Add(BodyFactory.CreateEdge(world, _b[0], _b[1], null));
            Add(BodyFactory.CreateEdge(world, _b[1], _b[2], null));
            Add(BodyFactory.CreateEdge(world, _b[2], _b[3], null));
            Add(BodyFactory.CreateEdge(world, _b[3], _b[0], null));
        }
        public StaticBodies(int capacity) : base(capacity)
        {

        }

        public StaticBodies(IEnumerable<Body> collection) : base(collection)
        {

        }
    }


}
