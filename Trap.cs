namespace SadConsoleGame;

internal class Trap : GameObject
{
    public Trap(Point position, IScreenSurface hostingSurface)
    : base(new ColoredGlyph(Color.Orange, Color.Black, 'T'), position, hostingSurface)
    {

    }
    public override bool Touched(GameObject source, Map map)
    {
        if (source == map.UserControlledObject)
        {
            map.RemoveMapObject(map.UserControlledObject);
            return true;
        }

        return base.Touched(source, map);
    }  
}