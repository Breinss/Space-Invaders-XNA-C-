using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    public class EnemyBullet
    {
        

        public Vector2 position;
        private Vector2 velocity;
        public Boolean IsFired;
        public Texture2D texture;

        private Game1 theGame1;

        public EnemyBullet(Vector2 _position)
        {
            IsFired = false;
            texture = Global.content.Load<Texture2D>("bullet");
            Init();
            position = _position;
        }

        public void Init()
        {
            IsFired = true;
        }

        public void Reset()
        {
            
            IsFired = false;
        }
        public void Update()
        {
            velocity.Y = 5f;
            position += velocity;
            for (int i = 0; i < Game1.enemybullets.Count; i++)
            {
          
                    
                    if (position.Y > Global.height)
                    {
                        
                        Game1.enemybullets.RemoveAt(i);
                       
                  }

                }
            }

        
        public void Draw()
        {
            Global.spriteBatch.Draw(texture,position,Color.White);
        }

    }
}
