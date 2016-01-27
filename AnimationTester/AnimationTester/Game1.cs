using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AnimationTester
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D stand;
        Texture2D walkingAnimation;
        Texture2D characterState;

        Vector2 pos1 = new Vector2(300, 300);

        float speed1 = 0.75f;

        Point frameSize = new Point(80, 80);
        Point currentFrame = new Point(0, 0);
        Point sheetSize = new Point(1, 1);

        SpriteEffects direction = SpriteEffects.None;

        int gameSetFramerate = 17; //60 fps is 16.6~ ms

        int timeSinceLastFrame = 0;
        int millisecondsPerFrame = 100; //animations are 10fps

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TargetElapsedTime = new TimeSpan(0, 0, 0, 0, gameSetFramerate); 
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            walkingAnimation = Content.Load<Texture2D>("Walkingtest");
            stand = Content.Load<Texture2D>("StandingTest");
            characterState = stand;
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            // TODO: Add your update logic here


            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;


            if (Keyboard.GetState().IsKeyUp(Keys.D) && Keyboard.GetState().IsKeyUp(Keys.A))
            {
                
                currentFrame.X = 0;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame = 0;
                    currentFrame.X = AnimationClass.AnimationStill(currentFrame);
                }
                characterState = stand; 
                //there is an issue where the sprite will occasionally flash when going to 'stand'. this is caused by the animation logic. the flash is 100 ms gap between frames. this needs to be fixed.
            }

            //how to handle keyboard input conflict?
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos1.X += speed1;
                sheetSize = new Point(10, 1);
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame = 0;
                    currentFrame.X = AnimationClass.AnimationLoop(currentFrame, sheetSize);
                }
                characterState = walkingAnimation;
                direction = SpriteEffects.None;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos1.X -= speed1;
                sheetSize = new Point(10, 1);
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame = 0;
                    currentFrame.X = AnimationClass.AnimationLoop(currentFrame, sheetSize);
                }
                characterState = walkingAnimation;
                direction = SpriteEffects.FlipHorizontally;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            spriteBatch.Draw(characterState, pos1, new Rectangle(currentFrame.X * frameSize.X, currentFrame.Y*frameSize.Y, frameSize.X, frameSize.Y), Color.White, 0, Vector2.Zero, 1, direction, 0);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
