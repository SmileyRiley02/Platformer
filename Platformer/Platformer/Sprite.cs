﻿using System;
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
    public class Sprite
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 offset = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        Texture2D texture;
        public int width = 0;
        public int height = 0;

        public int leftEdge = 0;
        public int rightEdge = 0;
        public int topEdge = 0;
        public int bottomEdge = 0;
        public Sprite()
        {

        }

        public void Load(ContentManager content,string asset)
        {
            texture = content.Load<Texture2D>(asset);
        }
        public void Update(float deltaTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position = offset, Color.White);
        }
    }
}
