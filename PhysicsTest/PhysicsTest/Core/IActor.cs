
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using FarseerPhysics.Dynamics;


namespace PhysicsTest
{
    public interface IActor
    {
        Texture2D Tex { get; set; }
        Vector2 Position { get; set; }
        float Health { get; set; }
        Sprite Sprite { get; set; }
        Vector2 ImpulseForce { get; set; }
        Body PhysxBody { get; set; }
        RectangleF HitBox { get; set; }
        ActorState CurrentState { get; set; }
        ActorState LastState { get; set; }
        void Update(GameTime gt);
        void Draw(SpriteBatch sp);
    }
}
