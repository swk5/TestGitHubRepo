using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.Graphics;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SwKMonoGame1.Interfaces;


namespace SwKMonoGame1
{
    class Actor : IActor
    {
        public int ActorID => throw new NotImplementedException();

        public Vector2 LastPosition => throw new NotImplementedException();

        public Vector2 LastVelocity => throw new NotImplementedException();

        public int Speed => throw new NotImplementedException();

        public Vector2 Velocity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Vector2 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RectangleF BoundingBox => throw new NotImplementedException();

        public void OnCollision(CollisionInfo collisionInfo)
        {
            throw new NotImplementedException();
        }
    }
}
