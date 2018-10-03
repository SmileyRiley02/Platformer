using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    class Player
    {
        public Sprite playerSprite = new Sprite();

        Game1 game = null;
        float nunSpeed = 150430;
        public Player()
        {

        }
        
        public void Load(ContentManager content, Game1 theGame)
        {
            playerSprite.Load(content, "hero");
            game = theGame;
            playerSprite.velocity = Vector2.Zero;
            playerSprite.Position = new Vector2(theGame.GraphicsDevice.Viewport.Width / 2,
                                                         theGame.GraphicsDevice.Viewport.Height - 100);
        }
        public void UpdateInput(float deltaTime)
        {
            Vector2 localAcceleration =  new Vector2(0,0);
            if (Keyboard.GetState().IsKeyDown(Keys.Left) == true || Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                localAcceleration.X = nunSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) == true || Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                localAcceleration.X = -nunSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) == true || Keyboard.GetState().IsKeyDown(Keys.W) == true)
            {
                localAcceleration.Y = nunSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down) == true || Keyboard.GetState().IsKeyDown(Keys.S) == true)
            {
                localAcceleration.Y = -nunSpeed;
            }
            playerSprite.velocity = localAcceleration * deltaTime;
            playerSprite.Position += playerSprite.velocity * deltaTime;

            collision.game = game;
            playerSprite = collision.Collided();
}
        public void Update(float deltaTime)
        {
            UpdateInput(deltaTime);
            playerSprite.Update(deltaTime);
          
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            playerSprite.Draw(spriteBatch);
        }
    }
}
