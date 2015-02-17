
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

        public List<EnemyShip> enemyships = new List<EnemyShip>();
        public int maxShip = 0;

        public int nShield = 3;
        List<Shield> shields = new List<Shield>(); 
        //TODO: Add multiple invaders here
        
        
        public static List<Bullet> bullets = new List<Bullet>(); 
        public static List<EnemyBullet> enemybullets = new List<EnemyBullet>();


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
            //Create and Initialize invader
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.spriteBatch = spriteBatch;
            background = Content.Load<Texture2D>("background");
            scanlines = Content.Load<Texture2D>("scanlines");
            

            for (int i = 0; i <= nInvaders; i++)
            {
                theInvader = new Invader();
                theInvader.init();
                invaders.Add(theInvader);
                invaderSize = invaders.Count;    
            }

            for (int i = 0; i <= nShield; i++)
            {
               Shield theShield = new Shield(new Vector2(Global.width/4*i + 90 , Global.height - 100));;
               theShield.init();
               shields.Add(theShield);
            }
            for (int i = 0; i < 1; i++)
            {
                EnemyShip newShip = new EnemyShip(new Vector2(Player.position.X, Global.height / 8 - 65));
                newShip.Init();
                enemyships.Add(newShip);
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
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }
            for (int i = 0; i < invaderSize; i++)
            {
                invaders[i].Update();
            }
            for (int i = 0; i < shields.Count; i++)
            {
                shields[i].Update();
            }
            for (int i=0; i < enemybullets.Count; i++)
            {
                enemybullets[i].Update();
            }
            for (int i = 0; i < enemyships.Count; i++)
            {
                enemyships[i].Update();
            }

            


            for (int x = 0; x < bullets.Count; x++)
            {

                for (int loopNum = 0; loopNum < invaders.Count; loopNum++)
                {

                    if(Collision(bullets[x].position,bullets[x].position,bullets[x].texture,invaders[loopNum].position,invaders[loopNum].position,invaders[loopNum].texture))
                    {
                        invaders[loopNum].Reset();
                        bullets[x].RemoveBullet();
                        break;
                    }
                }
            }
            for (int x = 0; x < bullets.Count; x++)
            {
                for (int loopNum = 0; loopNum < enemyships.Count; loopNum++)
                {

                    if (Collision(bullets[x].position, bullets[x].position, bullets[x].texture, enemyships[loopNum].position, enemyships[loopNum].position, enemyships[loopNum].texture))
                    {
                        enemyships[loopNum].shipHp--;
                        bullets[x].RemoveBullet();
                        if (enemyships[loopNum].shipHp <= 0)
                        {
                            enemyships.RemoveAt(loopNum);
                        }
                        break;
                    }
                }
            }
            for (int x = 0; x < enemybullets.Count; x++)
            {

                for (int loopNum = 0; loopNum < shields.Count; loopNum++)
                {

                    if (Collision(enemybullets[x].position, enemybullets[x].position, enemybullets[x].texture, shields[loopNum].position, shields[loopNum].position, shields[loopNum].texture))
                    {
                        shields[loopNum].shieldHp--;
                        enemybullets.RemoveAt(x);
                        if (shields[loopNum].shieldHp <= 0)
                        {
                            shields.RemoveAt(loopNum);
                        }
                        break;
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

            for (int i = 0; i < invaderSize; i++)
            {
                invaders[i].Draw();
            }

            for (int i = 0; i < shields.Count; i++)
            {
                shields[i].Draw();
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw();
            }
            for (int i = 0; i < enemybullets.Count; i++)
            {
                enemybullets[i].Draw();
            }
            for (int i = 0; i < enemyships.Count; i++)
            {
                enemyships[i].Draw();
            }
            spriteBatch.Draw(scanlines, Global.screenRect, Color.White);
            spriteBatch.End();

            
            base.Draw(gameTime);
        }

    }
}
