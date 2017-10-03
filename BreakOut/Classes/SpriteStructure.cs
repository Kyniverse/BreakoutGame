using Microsoft.Xna.Framework;

/*
 *      Syntax          ::    Microsoft StyleCop-SA1201
 *      C# Version      ::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     Pattern which will be generated ontop of a sprite.
    /// </summary>
    enum SPRITE_PATTERN
    {
        SOLID,
        CHECKERED
    }

    /// <summary>
    ///     Style of the border generated ontop of a sprite.
    /// </summary>
    enum SPRITE_BORDERSTYLE
    {
        SOLID,
        BEVEL
    }

    /// <summary>
    ///     The SpriteStructure Object contains important information on how a sprite is generated.
    /// </summary>
    class SpriteStructure
    {
#region CONSTRUCTORS & DESTRUCTORS
        public SpriteStructure() {; }
        public SpriteStructure(Color color, SPRITE_PATTERN pattern, bool border, SpriteBorderStructure borderStructure)
        {
            this.Color = color;
            this.PATTERN = pattern;
            this.Border = border;
            this.SpriteBorderStructure = borderStructure;
        }
#endregion

#region PROPERTIES
        public bool Border { get; private set; } = false;
        public Color Color { get; private set; } = Color.White;
        public SPRITE_PATTERN PATTERN { get; private set; } = SPRITE_PATTERN.SOLID;
        public SpriteBorderStructure SpriteBorderStructure { get; private set; } = SpriteBorderStructure.Empty;
        public static SpriteStructure Empty { get => new SpriteStructure(); }
#endregion
    }

    /// <summary>
    ///     The SpriteBorder Object contains important information on how the border of a sprite is generated.
    /// </summary>
    class SpriteBorderStructure
    {
#region CONSTRUCTORS & DESTRUCTORS
        public SpriteBorderStructure() {; }
        public SpriteBorderStructure(Color color, float constrast, SPRITE_BORDERSTYLE style)
        {
            this.Color = color;
            this.Constrast = constrast;
            this.STYLE = style;
        }
#endregion

#region PROPERTIES
        public Color Color { get; set; } = Color.Black;
        public float Constrast { get; private set; } = 1f;
        public SPRITE_BORDERSTYLE STYLE { get; private set; } = SPRITE_BORDERSTYLE.SOLID;
        public static SpriteBorderStructure Empty { get => new SpriteBorderStructure(); }
#endregion
    }
}
