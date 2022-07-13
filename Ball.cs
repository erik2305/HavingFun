
/*Erik Altynbayev 
 * Final Project
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HavingFun
{
    /// <summary>
    /// Class responsible for the Ball object
    /// </summary>
    public class Ball: DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D texture;
        private Vector2 position;
        private Vector2 speed;
        private Vector2 stage;
        public int score1, score2;
        private SoundEffect sound;
        Random rand = new Random();
        public Vector2 Speed { get => speed; set => speed = value; }
        /// <summary>
        /// Ball class constructor
        /// </summary>
        /// <param name="game"></param>
        /// <param name="spriteBatch"></param>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="speed"></param>
        /// <param name="stage"></param>
        /// <param name="sound"></param>
        public Ball(Game game, SpriteBatch spriteBatch, Texture2D texture,
            Vector2 position, Vector2 speed, Vector2 stage, SoundEffect sound) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.texture = texture;
            this.position = position;
            this.speed = speed;
            this.stage = stage;
            this.score1 = 0;
            this.score2 = 0;
            this.sound = sound;
        }
        /// <summary>
        /// Draws
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
        /// Updates
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            position += speed;
            //top wall
            if (position.Y < 0)
            {
                speed.Y = -speed.Y;
            }
            //right wall
            if(position.X + texture.Width > stage.X)
            {
                score1++;
                position.X = stage.X / 2;
                position.Y = stage.Y / 2;
                speed.X = 0;
                speed.Y = 0;
            }
            //bottom wall
            if(position.Y + texture.Height > stage.Y)
            {
                speed.Y = -speed.Y;
            }
            //left wall
            if (position.X < 0)
            {
                score2++;
                position.X = stage.X / 2;
                position.Y = stage.Y / 2;
                speed.X = 0;
                speed.Y = 0;
            }
                KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Enter))
            {
                speed.Y = rand.Next(3, 5);
                speed.X = rand.Next(-5, 5);
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// Receives hitbox of the ball
        /// </summary>
        /// <returns></returns>
        public Rectangle GetBound()
        {
            return new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
    }
}
