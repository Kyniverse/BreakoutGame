using Microsoft.Xna.Framework;

/*
 *      Syntax::        Microsoft StyleCop-SA1201
 *      C# Version::    7.0
 */
namespace BreakOut
{
    /// <summary>
    ///     The Transform Object represents an coordinal system within a 2D space.
    /// </summary>
	public class Transform
    {
#region PROPERTIES
        /// <summary>
        ///     Defines the Position of the Transform Object within a 2D world-space.
        /// </summary>
        public Vector2 Position { get; set; } = Vector2.Zero;

        /// <summary>
        ///     Defines the Scaling of the Transform Object within a 2D world-space.
        /// </summary>
        public Vector2 Scale { get; set; } = Vector2.One;

        /// <summary>
        ///     Defines the Rotation of the Transform Object within a 2D world-space.
        /// </summary>
        public float Rotation { get; set; } = 0f;

        /// <summary>
        ///     Returns a new Transform with default values;
        /// </summary>
        public static Transform Empty { get => new Transform(); }

        /// <summary>
        ///     Returns the Objects values in a suitable format.
        /// </summary>
        /// <returns>Formatted string with Object Properties.</returns>
        public override string ToString() => $"Position: {this.Position}, Rotation: {this.Rotation}, Scale: {this.Scale};";
#endregion
    }
}