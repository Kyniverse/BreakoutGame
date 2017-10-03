using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 *      Syntax          ::    Microsoft StyleCop-SA1201
 *      C# Version      ::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     The ResourceGenerator Object creates additional textures, audios and other various
    ///     resources which are used within the game.
    /// </summary>
    class ResourceGenerator
    {
        /*
         *      The Singleton pattern allows this Object to only have a singular
         *      instance which is accessible from anywhere within the application.
         *      This Lazy<T> implementation is also thread-safe.
         */
        private static readonly Lazy<ResourceGenerator> instance = new Lazy<ResourceGenerator>();
        public static ResourceGenerator Instance => instance.Value;



        private GraphicsDevice graphicsDevice => Utilities.Instance.GraphicsDeviceManager.GraphicsDevice;
        private Dictionary<string, Texture2D> graphicsList = new Dictionary<string, Texture2D>();


        /// <summary>
        ///     Generates all the resources that the game requires.
        /// </summary>
        public void GenerateResources()
        {
            this.GenerateGraphics();
        }

        private void GenerateGraphics()
        {
            //  Generating the default texture which we use as a fall-back for the LoadGraphics function.
            graphicsList.Add("default", CreateSprite(1, 1, Color.White));

            graphicsList.Add("player", CreateSprite(32, 8, Color.White,
                new SpriteStructure(
                    Color.Crimson,
                    SPRITE_PATTERN.SOLID,
                    true,
                    new SpriteBorderStructure(
                        Color.Crimson,
                        1f, 
                        SPRITE_BORDERSTYLE.BEVEL
                    )
            )));

            graphicsList.Add("block", CreateSprite(32, 8, Color.White,
                new SpriteStructure(
                    Color.LightGray,
                    SPRITE_PATTERN.SOLID,
                    true,
                    new SpriteBorderStructure(
                        Color.LightGray,
                        1f,
                        SPRITE_BORDERSTYLE.BEVEL
                    )
            )));
        }

        public Texture2D LoadSprite(string name) => graphicsList.ContainsKey(name) ? graphicsList[name] : graphicsList["default"];

        /// <summary>
        ///     Generates a new sprite with the given configuration.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="color"></param>
        /// <param name="spriteStructure"></param>
        /// <returns></returns>
        private Texture2D CreateSprite(int width, int height, Color color, SpriteStructure spriteStructure = null)
        {
            /*
             *  Generating a new sprite takes a bit of time, hence the reason why 
             *  this function is mainly called within the initialization state / 
             *  content loading state of the game. 
             *  
             *  After some null-checks, we preform various other checks to either
             *  render a bevel or a pattern.
             */

            if (spriteStructure == null)
                spriteStructure = new SpriteStructure();

            Texture2D texture = new Texture2D(graphicsDevice, width, height);
            Color[] colorData = new Color[width * height];

            if (spriteStructure == null)
            {
                for (int i = 0; i < colorData.Length; i++)
                {
                    colorData[i] = color;
                }
            }
            else
            {
                for (int j = 0; j < height; j++)
                {
                    for (int i = 0; i < width; i++)
                    {
                        colorData[(j * width) + i] = spriteStructure.Color;

                        if (spriteStructure.Border)
                        {
                            if (spriteStructure.SpriteBorderStructure.STYLE == SPRITE_BORDERSTYLE.SOLID)
                            {
                                if ((j == 0 | j == height - 1) | (i == 0 | i == width - 1))
                                {
                                    colorData[(j * width) + i] = spriteStructure.SpriteBorderStructure.Color;
                                }
                            }
                            else if (spriteStructure.SpriteBorderStructure.STYLE == SPRITE_BORDERSTYLE.BEVEL)
                            {
                                if (j == 0 & i > 0)
                                {
                                    colorData[(j * width) + i] = new Color(
                                        spriteStructure.SpriteBorderStructure.Color.R + (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.G + (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.B + (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast)
                                    );
                                }
                                else if (j == height - 1 & i < width - 1)
                                {
                                    colorData[(j * width) + i] = new Color(
                                        spriteStructure.SpriteBorderStructure.Color.R - (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.G - (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.B - (byte)(32 * spriteStructure.SpriteBorderStructure.Constrast)
                                    );
                                }
                                else if (i == 0)
                                {
                                    colorData[(j * width) + i] = new Color(
                                        spriteStructure.SpriteBorderStructure.Color.R + (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.G + (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.B + (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast)
                                    );
                                }
                                else if (i == width - 1)
                                {
                                    colorData[(j * width) + i] = new Color(
                                        spriteStructure.SpriteBorderStructure.Color.R - (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.G - (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast),
                                        spriteStructure.SpriteBorderStructure.Color.B - (byte)(16 * spriteStructure.SpriteBorderStructure.Constrast)
                                    );
                                }
                            }
                        }
                    }
                }
            }

            texture.SetData(colorData);

            return texture;
        }
    }
}
