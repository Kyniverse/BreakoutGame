using System;
/*
 *      Syntax          ::    Microsoft StyleCop-SA1201
 *      C# Version      ::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     The Game-Manager Object takes care of the global game value.
    /// </summary>
    class GameManager
    {
        /*
         *      The Singleton pattern allows this Object to only have a singular
         *      instance which is accessible from anywhere within the application.
         *      This Lazy<T> implementation is also thread-safe.
         */
        private static readonly Lazy<GameManager> instance = new Lazy<GameManager>();
        public static GameManager Instance => instance.Value;

        public int CurrentLevel { get; set; } = 1;
    }
}
