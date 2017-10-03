using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 *      Syntax          ::    Microsoft StyleCop-SA1201
 *      C# Version      ::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     The Utilities Object contains usefull information used within the entire game.
    /// </summary>
    class Utilities
    {
        /*
         *      The Singleton pattern allows this Object to only have a singular
         *      instance which is accessible from anywhere within the application.
         *      This Lazy<T> implementation is also thread-safe.
         */
        private static readonly Lazy<Utilities> instance = new Lazy<Utilities>();
        public static Utilities Instance => instance.Value;



        public float TimeScale { get; set; } = 1f;

        public float DeltaTime { get; private set; } = 0f;
        public float DeltaTimeScaled { get; private set; } = 0f;

        public Vector2 Resolution { get; set; } = new Vector2(640, 640);

        public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }



        public void Initialize(ref GraphicsDeviceManager graphicsDeviceManager) => this.GraphicsDeviceManager = graphicsDeviceManager;

        public void Update(ref GameTime gameTime)
        {
            this.DeltaTime = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1000f;
            this.DeltaTimeScaled = (this.DeltaTime * this.TimeScale);
        }
    }
}
