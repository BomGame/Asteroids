using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Game1.Objects;
using Game1.Controllers;
using Game1.Resorses;
using System.Threading;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        protected KeyboardController _keyboardController;

        protected Texture2D _PlayerTexture, _PlayerLaser;
        protected Player Player;

        protected Texture2D _t;
        protected Background Background;

        protected Texture2D _asteroidTexture1;
        protected Texture2D _asteroidTexture2;
        protected Texture2D _asteroidTexture3;
        protected Texture2D _asteroidTexture4;
        protected Texture2D _asteroidTexture5;
        protected Asteroids _asteroid1;
        protected Asteroids _asteroid2;
        protected Asteroids _asteroid3;
        protected Asteroids _asteroid4;
        protected Asteroids _asteroid5;

        protected Bonuses _bonusHeals;
        protected Texture2D _heart;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            //контроллер
            _keyboardController = new KeyboardController(this);

            //игрок
            Player = new Player(_PlayerTexture);
            Player._laser = _PlayerLaser;
            Player.SetPosition(120, graphics.PreferredBackBufferHeight/2);
            Player.SetScale(0.5f);
            _keyboardController.Attach(Player);

            //фон
            Background = new Background(_t);

            //астероиды
            _asteroid1 = new Asteroids(_asteroidTexture1, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _asteroid2 = new Asteroids(_asteroidTexture2, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _asteroid3 = new Asteroids(_asteroidTexture3, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _asteroid4 = new Asteroids(_asteroidTexture4, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);
            _asteroid5 = new Asteroids(_asteroidTexture5, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            //бонусы
            _bonusHeals = new Bonuses(_heart);
            _bonusHeals.SetPosition(500, 500);
            _bonusHeals.SetScale(0.6f);
            _bonusHeals.SetVelocity(new Vector2(-1, 0));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            _PlayerTexture = Content.Load<Texture2D>("spaceship");

            //_t = Content.Load<Texture2D>("bg5");
            _t = Content.Load<Texture2D>("Background-2");

            _asteroidTexture1 = Content.Load<Texture2D>("asteroidR1");
            _asteroidTexture2 = Content.Load<Texture2D>("asteroidR2");
            _asteroidTexture3 = Content.Load<Texture2D>("asteroidR3");
            _asteroidTexture4 = Content.Load<Texture2D>("asteroidR4");
            _asteroidTexture5 = Content.Load<Texture2D>("asteroidR5");
            _PlayerLaser = Content.Load<Texture2D>("laser");
            _heart = Content.Load<Texture2D>("heart");
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
            base.Update(gameTime);

            _asteroid1.Update(gameTime);
            _asteroid2.Update(gameTime);
            _asteroid3.Update(gameTime);
            _asteroid4.Update(gameTime);
            _asteroid5.Update(gameTime);
            Player.Update(gameTime, graphics.PreferredBackBufferWidth);
            _bonusHeals.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            //игра
            Background.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            _asteroid1.Draw(spriteBatch);
            _asteroid2.Draw(spriteBatch);
            _asteroid3.Draw(spriteBatch);
            _asteroid4.Draw(spriteBatch);
            _asteroid5.Draw(spriteBatch);
            _bonusHeals.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
