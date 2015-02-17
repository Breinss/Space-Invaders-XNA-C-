using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace XNAInvaders
{
    class Shield
    {
        public Texture2D texture;
        public Vector2 position;
        Rectangle shieldRectangle;
        Bullet theBullet;
        public int shieldHp;

        public Shield(Vector2 _position)
        {
            shieldHp = 3;
            texture = Global.content.Load<Texture2D>("shield");
            position = _position;
        }
        public void init()
        {
            
         
        }

        public void Reset()
        {
            
        }

        public void Update()
        {
            
          
        }

        public void Draw()
        {
            switch (shieldHp)
            {
                case 1:
                    Global.spriteBatch.Draw(texture, position, Color.White * 0.33f);
                break;

                case 2:
                    Global.spriteBatch.Draw(texture, position, Color.White * 0.66f);
                break;

                case 3:
                    Global.spriteBatch.Draw(texture, position, Color.White * 1f);
                break;
            }
                
            
        }
    }
}
