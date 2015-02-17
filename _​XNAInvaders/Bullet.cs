using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    public class Bullet
    {
        public static Boolean isFired = false;
        public Vector2 position;
        Vector2 velocity;
        public Texture2D texture;

        public Bullet(Vector2 _position)
        {
            texture = Global.content.Load<Texture2D>("bullet");
            position = _position;
            Init();

        }

        public void Init()
        {
            velocity.Y = 5f;
            isFired = true;
        }

        public void Update()
        {

            position -= velocity;

            if (position.Y < 0)
            {
                RemoveBullet();
                isFired = false;
            }

        }

        public void RemoveBullet()
            {
                for (int i = 0; i < Game1.bullets.Count; i++)
                {
                    Game1.bullets.RemoveAt(i);
                   
                }
            }

            

        

        public void Draw()
        {
            if(isFired)
            {
                Global.spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public void Reset()
        {
            isFired = false;
            //position.X = -1000;

        }

//        public Boolean OverlapsInvader(Invader anInvader)
//        {
//        }

    }
}
