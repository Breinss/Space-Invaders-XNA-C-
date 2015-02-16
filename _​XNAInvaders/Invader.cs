using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;



namespace XNAInvaders
{
    public class Invader
    {
       //variables
       public Texture2D texture;
       public Vector2 position;


       Vector2 velocity;
       private Random rnd;
        private Boolean leftWall;
        private Boolean rightWall;
        private string randomTexture;
        private Game1 theGame1;
        private EnemyBullet theEnemyBullet;
       

        public Invader()
        {
            

        }

        public void init()
        {
            rnd = new Random(Guid.NewGuid().GetHashCode());
            
            int randomTex = Random(1, 5);
            if (randomTex == 1)
            {
                randomTexture = "red_invader";
            }
            if (randomTex == 2)
            {
                randomTexture = "green_invader";
            }
            if (randomTex == 3)
            {
                randomTexture = "yellow_invader";
            }
            if (randomTex == 4)
            {
                randomTexture = "blue_invader";
            }

            
            theGame1 = new Game1();
            texture = Global.content.Load<Texture2D>(randomTexture);
            rightWall = true;
            leftWall = false;
            Reset();

        }
      
        public void Update()
        {
            
            
            
                //if (rightWall)
                //{
                //    velocity.X = 3f;
                //    position.X += velocity.X;
                //}
                //if (leftWall)
                //{
                //    velocity.X = 3f;
                //    position.X -= velocity.X;
                //}
                //if (position.X >= Global.width - 40)
                //{
                //    rightWall = false;
                //    leftWall = true;
                //    position.Y += velocity.Y;
                //}
                //if (position.X <= Global.width - Global.width)
                //{
                //    leftWall = false;
                //    rightWall = true;
                //    position.Y += velocity.Y;
                //}
            

        }
        public void Draw()
        {
            Global.spriteBatch.Draw(texture,position,Color.White);
        }

        public int Random(int randomNumber1, int randomNumber2)
        {
            int randomNumber = rnd.Next(randomNumber1, randomNumber2);   
            return randomNumber;
        }
        public void Reset()
        {
            velocity.X = 3f;
            velocity.Y = 10f;

            position.X = Random(100, Global.width - 100);
            position.Y = Random(0,Global.height - 300);
        }
    }
}
