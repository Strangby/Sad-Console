using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadConsoleGame
{
    internal class Wall:GameObject
    {
        public Wall(Point position, IScreenSurface hostingSurface)
        : base(new ColoredGlyph(Color.Brown, Color.Brown, 'W'), position, hostingSurface)
        {

        }
        public override bool Touched(GameObject source, Map map)
        {
            return base.Touched(source, map);
        }

    }
}
