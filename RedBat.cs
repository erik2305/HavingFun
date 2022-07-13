/*Erik Altynbayev 
 * Final Project
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HavingFun
{
    /// <summary>
    /// class responsible for the Red bat
    /// </summary>
    public class RedBat : DrawableGameComponent
    {
        public Game1 game;

        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        public Vector2 Speed { get => speed; set => speed = value; }
        /// <summary>
        /// Red Bat Constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="stage"></param>
        public RedBat(Game game,
            SpriteBatch spriteBatch,
            Texture2D texture,
            Vector2 position,
            Vector2 speed,
            Vector2 stage
            ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
        }

        /// <summary>
        /// Draws red Bat
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        /// <summary>
        /// Updates Info
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if(ks.IsKeyDown(Keys.W))
            {
                position -= speed;
                if(position.Y <0)
                {
                    position.Y = 0;
                }
            }

            if (ks.IsKeyDown(Keys.S))
            {
                position += speed;
                if (position.Y + texture.Height > stage.Y)
                {
                    position.Y = stage.Y- texture.Height;
                }
            }
            base.Update(gameTime);
        }
        /// <summary>
        /// receives hitbox of the Red Bat
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

    }
}
