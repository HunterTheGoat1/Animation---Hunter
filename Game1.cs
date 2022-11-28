using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Security.Cryptography;

namespace Animation___Hunter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleGreyRect;
        Rectangle tribbleBrownRect;
        Rectangle tribbleCreamRect;
        Rectangle tribbleOrangeRect;
        Vector2 greySpeed;
        Vector2 brownSpeed;
        Vector2 creamSpeed;
        Vector2 orangeSpeed;
        public static Random ran;
        int randomNum;
        int backNum = 0;

        enum Screen
        {
            Intro,
            TribbleYard
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            randomNum = 4;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            ran = new Random();
            tribbleGreyRect = new Rectangle((ran.Next(0, 700)), (ran.Next(0, 500)), 100, 100);
            greySpeed = new Vector2(2, 2);

            tribbleBrownRect = new Rectangle(ran.Next(0, 700), ran.Next(0, 500), 100, 100);
            brownSpeed = new Vector2(6, 0);

            tribbleCreamRect = new Rectangle(ran.Next(0, 700), ran.Next(0, 500), 100, 100);
            creamSpeed = new Vector2(0, 10);

            tribbleOrangeRect = new Rectangle(ran.Next(0, 700), ran.Next(0, 500), 100, 100);
            orangeSpeed = new Vector2(6, 4);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int) greySpeed.X;
            tribbleGreyRect.Y += (int) greySpeed.Y;

            tribbleBrownRect.X += (int)brownSpeed.X;
            tribbleBrownRect.Y += (int)brownSpeed.Y;

            tribbleCreamRect.X += (int)creamSpeed.X;
            tribbleCreamRect.Y += (int)creamSpeed.Y;

            tribbleOrangeRect.X += (int)orangeSpeed.X;
            tribbleOrangeRect.Y += (int)orangeSpeed.Y;

            if (tribbleGreyRect.Right >= (_graphics.PreferredBackBufferWidth) || tribbleGreyRect.Left <= 0)
                greySpeed.X *= -1;
            if (tribbleGreyRect.Bottom >= (_graphics.PreferredBackBufferHeight) || tribbleGreyRect.Top <= 0)
                greySpeed.Y *= -1;

            if (tribbleBrownRect.Right >= (_graphics.PreferredBackBufferWidth) || tribbleBrownRect.Left <= 0)
                brownSpeed.X *= -1;
            if (tribbleBrownRect.Bottom >= (_graphics.PreferredBackBufferHeight) || tribbleBrownRect.Top <= 0)
                brownSpeed.Y *= -1;

            if (tribbleCreamRect.Right >= (_graphics.PreferredBackBufferWidth) || tribbleCreamRect.Left <= 0)
            {
                creamSpeed.X *= -1;
                backNum++;
                if (backNum == 5)
                {
                    backNum = 0;
                }
            }
            if (tribbleCreamRect.Bottom >= (_graphics.PreferredBackBufferHeight) || tribbleCreamRect.Top <= 0)
            {
                creamSpeed.Y *= -1;
                backNum++;
                if (backNum == 5)
                {
                    backNum = 0;
                }
            }

            if (tribbleOrangeRect.Right >= (_graphics.PreferredBackBufferWidth) || tribbleOrangeRect.Left <= 0)
            {
                orangeSpeed.X *= -1;
                tribbleOrangeRect.X = ran.Next(0, 700);
            }
            if (tribbleOrangeRect.Bottom >= (_graphics.PreferredBackBufferHeight) || tribbleOrangeRect.Top <= 0)
            {
                orangeSpeed.Y *= -1;
                tribbleOrangeRect.Y = ran.Next(0, 500);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here




            if (backNum == 0)
            {
                GraphicsDevice.Clear(Color.Tomato);
            }
            else if (backNum == 1)
            {
                GraphicsDevice.Clear(Color.Cyan);
            }
            else if (backNum == 2)
            {
                GraphicsDevice.Clear(Color.Green);
            }
            else if (backNum == 3)
            {
                GraphicsDevice.Clear(Color.Gold);
            }
            else if (backNum == 4)
            {
                GraphicsDevice.Clear(Color.BlueViolet);
            }

            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}