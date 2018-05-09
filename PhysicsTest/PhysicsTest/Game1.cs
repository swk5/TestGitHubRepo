using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Shapes;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.ViewportAdapters;
using FarseerPhysics;
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using System.Collections.Generic;
using System;

namespace PhysicsTest

{
    public class Game1 : Game
    {
        List<Texture2D> charAnim;
        Camera2D myCam;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameWorld GW;
        GWorld Level;
        SpriteFont Font;
        World world;

        float Timer, Cooldown, CooldownTime;
        public Game1()
        {
            Timer = 0f;
            Cooldown = 0f;
            CooldownTime = 1f;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            world = new World(new Vector2(0f, 100f));

            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1000;

            //charAnim = new List<Texture2D>();
        }

        protected override void Initialize()
        {

            myCam = new Camera2D(graphics.GraphicsDevice);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            Texture2D temp;
            Font = Content.Load<SpriteFont>("Font");
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //charAnim.Add(this.Content.Load<Texture2D>("SpriteSheets/DownIdle.png"));
            temp = this.Content.Load<Texture2D>("RightIdle");
            Texture2D[] temps = new Texture2D[1];
            temps[0] = temp;
            Level = new GWorld(new Vector2(0f, 10f), Font, temps, new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight));

            //            GW = new GameWorld(temp,new Vector2(0f,20f ));
            //GW.PopulateWorldWithStaticBodies();
            //GW.spFont = Font;
        }

        protected override void Update(GameTime gameTime)
        {

            Timer += gameTime.GetElapsedSeconds();
            MouseState ms = Mouse.GetState();
            if (Cooldown > 0f)
            {
                Cooldown += gameTime.GetElapsedSeconds();
            }
            Console.WriteLine("Elapsed Game Seconds: " + Timer.ToString());
            if (Timer >= 1f / 65f)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    if (Cooldown == 0f)
                    {
                        Body newBody = BodyFactory.CreateRectangle(Level, 20f, 10f, 20f, new Vector2(ms.X, ms.Y));
                        newBody.BodyType = BodyType.Dynamic;
                        newBody.Friction = .5f;
                        newBody.Restitution = .75f;
                        newBody.ApplyForce(new Vector2(75f, 75f));
                        Level.NewBody(ref newBody);
                        Cooldown = 0.001f;
                    }
                    else if (Cooldown >= 1f)
                    {
                        Cooldown = 0f;
                    }
                }
                Timer = 0f;
                Level.Update(1f / 65f);
            }
            //GW.Update(gameTime);
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            Level.Draw(spriteBatch);
            //GW.Draw(spriteBatch);
            //            spriteBatch.DrawString(Font, GW.P1.Position.ToString(),new Vector2(300f,50f),Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        protected override void UnloadContent() { }
    }
}
