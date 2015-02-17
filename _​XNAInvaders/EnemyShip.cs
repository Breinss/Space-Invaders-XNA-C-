using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XNAInvaders
{
    public class EnemyShip
    {
        public Vector2 position;
        private Vector2 velocity;
        public Texture2D texture;

        private Boolean left;
        private Boolean right;

        public int shipHp;

        public EnemyShip(Vector2 _position)
        {
            texture = Global.content.Load<Texture2D>("enemy_ship");
            position = _position;
        }

        public void Init()
        {
            left = true;
            shipHp = 3;
        }

        public void Draw()
        {
            switch (shipHp)
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

        public void Update()
        {
            if (right)
            {
                velocity.X = 1f;
                position.X += velocity.X;
            }
            if (left)
            {
                velocity.X = 1f;
                position.X -= velocity.X;
            }
            if (position.X >= Global.width - 60)
            {
                right = false;
                left = true;
            }
            if (position.X <= Global.width - Global.width)
            {
                right = true;
                left = false;
            }
        }

        public void Reset()
        {
            
        }
    }
}
