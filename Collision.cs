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
    /// class responsible for the ball and bats hitting/reflection
    /// </summary>
    class Collision : GameComponent
    {
        public RedBat redBat;
        public BlueBat blueBat;
        public Ball ball;
        private SoundEffect sound;
        /// <summary>
        /// constructor for the Collision class
        /// </summary>
        /// <param name="game"></param>
        /// <param name="redBat"></param>
        /// <param name="blueBat"></param>
        /// <param name="ball"></param>
        /// <param name="sound"></param>
        public Collision(Game game,
            RedBat redBat,
            BlueBat blueBat,
            Ball ball,
            SoundEffect sound) : base(game)
        {
            this.ball = ball;
            this.redBat = redBat;
            this.blueBat = blueBat;
            this.sound = sound;
        }
        /// <summary>
        /// Reflects the ball
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Rectangle redBatRect = redBat.GetBound();
            Rectangle blueBatRect = blueBat.GetBound();
            Rectangle ballRect = ball.GetBound();

            if(redBatRect.Intersects(ballRect))
            {
               ball.Speed = new Vector2(-ball.Speed.X, ball.Speed.Y);
               sound.Play();
            }
            if (blueBatRect.Intersects(ballRect))
            {
                ball.Speed = new Vector2(-ball.Speed.X, ball.Speed.Y);
                sound.Play();
            }

            base.Update(gameTime);
        }
    }
}
