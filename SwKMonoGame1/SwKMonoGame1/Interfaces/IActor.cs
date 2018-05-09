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


namespace SwKMonoGame1.Interfaces
{
    public interface IActor : IActorTarget
    {
        int ActorID { get; }
        Vector2 LastPosition { get; }
        Vector2 LastVelocity { get; }
        int Speed { get; }

    }
}
