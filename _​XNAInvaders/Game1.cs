
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
        
        public static List<Bullet> bullets = new List<Bullet>(); 


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

            for (int x = 0; x < bullets.Count; x++)
            {

                for (int loopNum = 0; loopNum < invaders.Count; loopNum++)
                {

                    if(Collision(bullets[x].position,bullets[x].position,bullets[x].texture,invaders[loopNum].position,invaders[loopNum].position,invaders[loopNum].texture))
                    {
                        invaders[loopNum].Reset();
                        Bullet.RemoveBullet();
                    }
                }
            }
                thePlayer.Update(gameTime);



                base.Update(gameTime);
            }
        public bool Collision(Vector2 x0, Vector2 y0, Texture2D texture0, Vector2 x1, Vector2 y1, Texture2D texture1)
        {



            if (x0.X > x1.X + texture1.Width || x0.X + texture0.Width < x1.X || y0.Y > y1.Y + texture1.Height || y0.Y + texture0.Height < y1.Y)
                return false;
            else
                return true;

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
