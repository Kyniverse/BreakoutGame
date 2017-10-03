using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BreakOut
{
    /*
     *      Syntax          ::    Microsoft StyleCop-SA1201
     *      C# Version      ::    7.0
     */
    abstract class Scene
    {


        public string Name { get; private set; } = "New Scene";

        public virtual void Initialize() {; }
        public virtual void Update() {; }
        public virtual void Render(ref SpriteBatch spriteBatch) {; }
    }
}
