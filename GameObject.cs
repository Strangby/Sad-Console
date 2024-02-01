namespace SadConsoleGame;

internal class GameObject
{
    private ColoredGlyph _mapAppearance = new ColoredGlyph();

    public Point Position { get; private set; }
    public ColoredGlyph Appearance { get; set; }

    public GameObject(ColoredGlyph appearance, Point position, IScreenSurface hostingSurface)
    {
        Appearance = appearance;
        Position = position;

        hostingSurface.Surface[position].CopyAppearanceTo(_mapAppearance);

        DrawGameObject(hostingSurface);
    }
    public bool Move(Point newPosition, Map map)
    {
        if (!map.SurfaceObject.IsValidCell(newPosition.X, newPosition.Y)) return false;

        if (map.TryGetMapObject(newPosition, out GameObject? foundObject))
        {
            if (!foundObject.Touched(this, map))
                return false;
        }

        _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

        map.SurfaceObject.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

        Position = newPosition;
        DrawGameObject(map.SurfaceObject);

        return true;
    }

    public virtual bool Touched(GameObject source, Map map)
    {
        return false;
    }

    public void RestoreMap(Map map) =>
    _mapAppearance.CopyAppearanceTo(map.SurfaceObject.Surface[Position]);

    private void DrawGameObject(IScreenSurface screenSurface)
    {
        Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
        screenSurface.IsDirty = true;
    }
}