/*Erik Altynbayev 
 * Final Project
 */
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HavingFun
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        private Ball ball;
        private RedBat redBat;
        private BlueBat blueBat;
        private Collision collision;
        Vector2 score1Position, score2Position, startPosiotion;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            Vector2 stage = new Vector2(graphics.PreferredBackBufferWidth,
                graphics.PreferredBackBufferHeight);
            //Creates al text in the screen
            font = Content.Load<SpriteFont>("Fonts/Score");
            score1Position.X = 20;
            score1Position.Y = 30;
            score2Position.X = stage.X - 135;
            score2Position.Y = 30;
            startPosiotion.X =stage.X/2- 90;
            startPosiotion.Y = 30 ;

            Texture2D ballTex = this.Content.Load<Texture2D>("Images/ball");
            Texture2D redBatTex = this.Content.Load<Texture2D>("Images/Redbat");
            Texture2D blueBatTex = this.Content.Load<Texture2D>("Images/Bluebat");

            SoundEffect sound = Content.Load<SoundEffect>("Sounds/click");

            //displays ball
            Vector2 ballInitPos = new Vector2(stage.X / 2 - ballTex.Width,
                stage.Y / 2);
            Vector2 ballSpeed = new Vector2(0, 0);
            ball = new Ball(this, spriteBatch, ballTex, ballInitPos, ballSpeed, stage, sound);
            this.Components.Add(ball);

            //displays Red Bat
            Vector2 redBatInitPos = new Vector2(redBatTex.Width, stage.Y/2 - redBatTex.Height/2);
            Vector2 redBatSpeed = new Vector2(0, 4);
            redBat = new RedBat(this, spriteBatch, redBatTex, redBatInitPos, redBatSpeed, stage);
            this.Components.Add(redBat);

            //displays Blue Bat
            Vector2 blueBatInitPos = new Vector2(stage.X-blueBatTex.Width*2, stage.Y / 2 - blueBatTex.Height / 2);
            Vector2 blueBatSpeed = new Vector2(0, 4);
            blueBat = new BlueBat(this, spriteBatch, blueBatTex, blueBatInitPos, blueBatSpeed, stage);
            this.Components.Add(blueBat);


            collision = new Collision(this, redBat,blueBat, ball, sound);
            this.Components.Add(collision);

            IsMouseVisible = true;
            graphics.ApplyChanges();
        }

    

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// game-specific content.
    /// </summary>
    protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();

            GraphicsDevice.Clear(Color.White);

            //Displays Score and hint
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Red Player: " + ball.score1, score1Position, Color.Red);
            spriteBatch.DrawString(font, "Blue Player: " + ball.score2, score2Position, Color.Blue);
            if (ball.Speed.X == 0)
            {
                spriteBatch.DrawString(font, "Press Enter to Start ", startPosiotion, Color.Black);
            }

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
