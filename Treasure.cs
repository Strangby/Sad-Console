namespace SadConsoleGame;

internal class Treasure : GameObject
{
    public Treasure(Point position, IScreenSurface hostingSurface)
    : base(new ColoredGlyph(Color.Yellow, Color.Black, 'T'), position, hostingSurface)
    {

    }
    public override bool Touched(GameObject source, Map map)
    {
        if (source == map.UserControlledObject)
        {
            map.RemoveMapObject(this);
            return true;
        }

        return false;
    }
}