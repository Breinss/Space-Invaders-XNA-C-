using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    class EnemyBullet
    {
        private int currentBullets;

        public Vector2 position;
        private Vector2 velocity;
        public Boolean enemyIsFired;
        private Texture2D texture;

        private Game1 theGame1;

        public EnemyBullet()
        {
            texture = Global.content.Load<Texture2D>("bullet");
            init();
        }

        public void init()
        {
            
            enemyIsFired = false;
            theGame1 = new Game1();
        }

        public void Reset()
        {
            currentBullets = 0;
            enemyIsFired = false;
        }
        public void Update()
        {
            
                if (enemyIsFired && currentBullets <= 1)
                {
                    velocity.Y = 5f;
                    position += velocity;
                    currentBullets = 1;
                    if (position.Y < Global.width)
                    {
                        Reset();
                    }

                }
            
        }
        public void Draw()
        {
            Global.spriteBatch.Draw(texture,position,Color.White);
        }

    }
}
