using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

/*
 *      Syntax          ::    Microsoft StyleCop-SA1201
 *      C# Version      ::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     The Player Object is the main entity within the game. The person playing
    ///     the game controll this object.
    /// </summary>
    class Player
    {
        /*
         *      The Singleton pattern allows this Object to only have a singular
         *      instance which is accessible from anywhere within the application.
         *      This Lazy<T> implementation is also thread-safe.
         */
        private static readonly Lazy<Player> instance = new Lazy<Player>();
        public static Player Instance => instance.Value;


        
        private float moveSpeed = 16f;
        private Vector2 pivot = Vector2.Zero;
        private Transform transform = Transform.Empty;
        private Texture2D sprite = ResourceGenerator.Instance.LoadSprite("player");



        List<Block> blockList = new List<Block>();
        Random random = new Random();

        /// <summary>
        ///     Initializes the Player Object.
        /// </summary>
        public void Initialize()
        {
            this.transform.Position = new Vector2(0, 16);
            this.transform.Scale = new Vector2(0.25f, 0.25f);
            this.pivot = new Vector2(
                sprite.Width * 0.5f, 
                sprite.Height * 0.5f
            );

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    blockList.Add(new Block(new Vector2(-12 + (i * 8), -16 + (j * 2)), 
                        new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255))
                    ));
                }
            }
        }

        /// <summary>
        ///     Update the PlayerObject.
        /// </summary>
        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left) | Keyboard.GetState().IsKeyDown(Keys.A))
                this.transform.Position += (new Vector2(-this.moveSpeed, 0) * Utilities.Instance.DeltaTimeScaled);

            if (Keyboard.GetState().IsKeyDown(Keys.Right) | Keyboard.GetState().IsKeyDown(Keys.D))
                this.transform.Position += (new Vector2(this.moveSpeed, 0) * Utilities.Instance.DeltaTimeScaled);
        }

        /// <summary>
        ///     Renders the Player object onto the surface.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Render(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.sprite,
                this.transform.Position,
                null,
                Color.White,
                0f,
                this.pivot,
                this.transform.Scale,
                SpriteEffects.None,
                0.01f
            );

            foreach (Block block in blockList)
                block.Render(ref spriteBatch);
        }
    }
}
