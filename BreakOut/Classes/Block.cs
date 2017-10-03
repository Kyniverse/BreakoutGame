using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakOut
{
    /// <summary>
    ///     The 'Block' Object represents an object which is used as a game-element
    ///     within the breakout game. The player can destroy this block in order to
    ///     gain points of power-ups.
    /// </summary>
    class Block
    {
#region FIELDS
        private Texture2D sprite;
        private Color color = Color.White;
        private Vector2 pivot = Vector2.Zero;
        private Transform transform = Transform.Empty;
#endregion

#region CONSTRUCTORS & DESTRUCTORS
        /// <summary>
        ///     Object type of 'Block' used as game element.
        /// </summary>
        public Block()
        {
            this.sprite = ResourceGenerator.Instance.LoadSprite("block");

            this.GeneratePivot();
        }

        /// <summary>
        ///     Object type of 'Block' used as game element.
        /// </summary>
        /// <param name="position">Position of the Block</param>
        public Block(Vector2 position)
        {
            this.sprite = ResourceGenerator.Instance.LoadSprite("block");
            this.transform.Position = position;

            this.GeneratePivot();
        }

        /// <summary>
        ///     Object type of 'Block' used as game element.
        /// </summary>
        /// <param name="position">Position of the Block</param>
        /// <param name="color">Color of the Block.</param>
        public Block(Vector2 position, Color color)
        {
            this.sprite = ResourceGenerator.Instance.LoadSprite("block");
            this.transform.Position = position;
            this.color = color;

            this.GeneratePivot();
        }
#endregion

#region METHODS
        /// <summary>
        ///     Generates the proper PIVOT of the Block.
        /// </summary>
        private void GeneratePivot()
        {
            this.transform.Scale = new Vector2(0.25f, 0.25f);

            this.pivot = new Vector2(
                sprite.Width * 0.5f,
                sprite.Height * 0.5f
            );
        }

        /// <summary>
        ///     Initializes the Block object.
        /// </summary>
        public void Initialize() {; }

        /// <summary>
        ///     Updates the Block object.
        /// </summary>
        public void Update() {; }

        /// <summary>
        ///     Renders the Block object onto the surface.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Render(ref SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                this.sprite,
                this.transform.Position,
                null,
                this.color,
                0f,
                this.pivot,
                this.transform.Scale,
                SpriteEffects.None,
                0.01f
            );
        }
#endregion
    }
}
