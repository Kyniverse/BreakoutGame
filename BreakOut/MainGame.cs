using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BreakOut
{
    /// <summary>
    ///     The MainGame Object is the main layer / framework of the game.
    /// </summary>
    public class MainGame : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        
        public MainGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //  Initializing the Utilies Object.
            Utilities.Instance.Initialize(ref this.graphics);

            //  Setting the screen-resolution to a fixed size.
            graphics.PreferredBackBufferWidth = (int)Utilities.Instance.Resolution.X;
            graphics.PreferredBackBufferHeight = (int)Utilities.Instance.Resolution.Y;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            //  defining the local field 'spriteBatch' to a new instance of SpriteBatch.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //  Generating the resources which the game requires.
            ResourceGenerator.Instance.GenerateResources();

            //  The game's initialization is running after the LoadContent method
            //  in order to prevent some weird stuff happening.
            Player.Instance.Initialize();
        }

        protected override void UnloadContent() {; }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //  Updating the Utilities Object which provides us with important information.
            Utilities.Instance.Update(ref gameTime);
            
            //  Updating the Player-Object which is used to play the game.
            Player.Instance.Update();

            GameManager.Instance.ToString();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(
                SpriteSortMode.BackToFront,
                null,
                SamplerState.PointClamp,
                DepthStencilState.None,
                null,
                null,
                Matrix.CreateScale(16) * 
                Matrix.CreateTranslation(new Vector3(graphics.PreferredBackBufferWidth * 0.5f, graphics.PreferredBackBufferHeight * 0.5f, 0))
            );


            //  Rendering the Player Object onto the screen.
            Player.Instance.Render(ref spriteBatch);



            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
