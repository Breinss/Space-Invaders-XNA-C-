using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace XNAInvaders
{
    class Shield
    {
        Texture2D texture;
        public Vector2 position;
        Rectangle shieldRectangle;
        Bullet theBullet;
        private int shieldHit;
        public Boolean shieldIsDeSpawned;

        public Shield()
        {
            texture = Global.content.Load<Texture2D>("shield");
            shieldIsDeSpawned = false;
            theBullet = new Bullet(position);

        }
        public void init()
        {
            position.X = Global.width /4; // horizontal center on screen
            position.Y = Global.height - texture.Height - 50; // bottom of screen
            if (!shieldIsDeSpawned)
            {
               shieldRectangle = new Rectangle((int) position.X, (int) position.Y, 64, 47);
            }
           
        }

        public void Reset()
        {
            
        }

        public void Update()
        {
            
            if (shieldHit == 3)
            {
                shieldIsDeSpawned = true;
            }
        }

        public void Draw()
        {
            if (!shieldIsDeSpawned)
            {
                Global.spriteBatch.Draw(texture, shieldRectangle, Color.White);
            }
        }
    }
}
