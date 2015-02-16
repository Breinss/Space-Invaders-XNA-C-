
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XNAInvaders
{
    class Player
    {
        public Vector2 position;
        Vector2 velocity;
        Texture2D texture;

        Invader theInvader;
        Bullet theBullet;
        EnemyBullet theEnemyBullet;
        Game1 theGame1;

        public Player()
        {
            texture = Global.content.Load<Texture2D>("ship");
            Init();
            theBullet = new Bullet(position);
            theEnemyBullet = new EnemyBullet();
            theInvader = new Invader();
            theGame1 = new Game1();
        }

        public void Init()
        {
            position.X = Global.width / 2; // horizontal center on screen
            position.Y = Global.height - texture.Height; // bottom of screen
        }

        public void Update(GameTime gameTime)
        {
           
            // Assume player is not moving
            velocity.X = 0;
            FireBullet();
            // Alter velocity when keys are pressed
            if (Global.keys.IsKeyDown(Keys.Left)) velocity.X = -10.0f;
            if (Global.keys.IsKeyDown(Keys.Right)) velocity.X = 10.0f;

            position += velocity;

            // If x position is out of bounds, "undo" velocity
            if ((position.X < 100) || (position.X > Global.width - texture.Width - 100))
                position -= velocity;
            if (Global.keys.IsKeyDown(Keys.Space))
            {
                
                    //theBullet.isFired = false;
                 FireBullet();


            }
            
          
        }

        public void Draw()
        {
            Global.spriteBatch.Draw(texture, position, Color.White);
           
        }

        void FireBullet()
        {
           Bullet newBullet = new Bullet(position);
           newBullet.Init();
           theGame1.bullets.Add(newBullet);
        }
    }
}
