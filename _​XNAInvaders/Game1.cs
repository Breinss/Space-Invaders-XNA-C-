
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.GamerServices;
using System.Collections;

namespace XNAInvaders
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background, scanlines;

        Player thePlayer;
        Invader theInvader;
        Bullet  theBullet;
        Shield theShield;
        public List<Invader> invaders  = new List<Invader>();
        public int nInvaders = 15;
        private int invaderSize;

        public int nShield = 3;
        List<Shield> shields = new List<Shield>(); 
        //TODO: Add multiple invaders here
        private int loopNum = 0;
        
        public List<Bullet> bullets = new List<Bullet>(); 


        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);            
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;


            Content.RootDirectory = "Content";
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            
            // Pass often referenced variables to Global
            Global.GraphicsDevice = GraphicsDevice;            
            Global.content = Content;
            // Create and Initialize game objects
            thePlayer = new Player();
            theInvader = new Invader();
            theShield = new Shield();
            //Create and Initialize invader
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            

            for (int iInvader = 0; iInvader <= nInvaders; iInvader++)
            {
                theInvader = new Invader();
                theInvader.init();
                invaders.Add(theInvader);
                invaderSize = invaders.Count;    
            }

            for (int iShields = 0; iShields <= nShield; iShields++)
            {
               theShield = new Shield();
               theShield.init();
               shields.Add(theShield);

            }
            
                base.Initialize();
        }

       
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Pass keyboard state to Global so we can use it everywhere
            Global.keys = Keyboard.GetState();

            // Update the game objects
            for (int iBullet = 0; iBullet < bullets.Count; iBullet++)
            {
                bullets[iBullet].Update();
            }
            for (int iUpdate = 0; iUpdate < invaderSize; iUpdate++)
            {
                invaders[iUpdate].Update();

                
            }
            int x = 0;
            while (x < bullets.Count)
            {
                loopNum = 0;
                while (loopNum < invaders.Count)
                {
                    if (((bullets[x].position.X > (invaders[loopNum].position.X)) &&
                         (bullets[x].position.X < (invaders[loopNum].position.X))) &&
                        (invaders[loopNum].position.Y < (invaders[loopNum].position.Y)))
                    {
                        invaders.RemoveAt(loopNum);
                        theBullet.Reset();
                        break;
                    }
                    loopNum++;
                }
                x++;
            }
            thePlayer.Update(gameTime);
            


            base.Update(gameTime);
        }

       

        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {            
            spriteBatch.Begin();
            // Draw the background (and clear the screen)
            spriteBatch.Draw(background, Global.screenRect, Color.White);

            // Draw the game objects
            thePlayer.Draw();

            for (int iInvader = 0; iInvader < invaderSize; iInvader++)
            {
                invaders[iInvader].Draw();
            }

            for (int iShields = 0; iShields < shields.Count; iShields++)
            {
                shields[iShields].Draw();
            }
            for (int iBullet = 0; iBullet < bullets.Count; iBullet++)
            {
                bullets[iBullet].Draw();
            }
            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            
            base.Draw(gameTime);
        }

    }
}
