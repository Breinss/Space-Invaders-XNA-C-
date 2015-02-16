using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    public class Bullet
    {
        public Boolean isFired = true;
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
            
        }

        public void Update()
        {
            
            position -= velocity;
           
              //  if (position.Y < 0)
              //  {
               //     theGame1.RemoveBullet();
                //}
                
            
            

            

        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture,position,Color.White);
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
