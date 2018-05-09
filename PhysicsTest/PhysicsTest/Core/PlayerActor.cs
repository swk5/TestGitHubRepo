using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using MonoGame.Utilities;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.Animations;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Content;
using MonoGame.Extended.Entities;
using MonoGame.Extended.Gui;
using MonoGame.Extended.Input;
using MonoGame.Extended.Particles;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.TextureAtlases;
using MonoGame.Extended.Timers;
using MonoGame.Extended.Graphics;

using FarseerPhysics;
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;


namespace PhysicsTest
{




    public class PlayerActor : IActor
    {
        private Texture2D _tex;
        private Sprite _sprite;
        private Vector2 _position;
        private float _health;
        private Vector2 _impulseForce;
        private Body _physxBody;
        private RectangleF _hitBox;
        private ActorState _currentState;
        private ActorState _lastState;


        public Sprite Sprite { get => _sprite; set => _sprite = value; }
        public Texture2D Tex { get => _tex; set => _tex = value; }
        public Vector2 Position { get => _position; set => _position = value; }
        public float Health { get => _health; set => _health = value; }
        public Vector2 ImpulseForce { get => _impulseForce; set => _impulseForce = value; }
        public Body PhysxBody { get => _physxBody; set => _physxBody = value; }
        public RectangleF HitBox { get => _hitBox; set => _hitBox = value; }
        public ActorState CurrentState { get => _currentState; set => _currentState = value; }
        public ActorState LastState { get => _lastState; set => _lastState = value; }

        public PlayerActor(Texture2D Texture, ref Body Body)
        {
            _tex = Texture;
            _sprite = new Sprite(Tex);
            _physxBody = Body;
            _position = _physxBody.Position;
        }
        public PlayerActor()
        { }
        public void Update(GameTime gt)
        { }

        public void Draw(SpriteBatch sp)
        {
            Sprite.Position = PhysxBody.Position;
            Sprite.Draw(sp);
        }
    }
}
