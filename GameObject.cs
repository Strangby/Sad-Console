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
    public void Move(Point newPosition, IScreenSurface screenSurface)
    {
        _mapAppearance.CopyAppearanceTo(screenSurface.Surface[Position]);

        screenSurface.Surface[newPosition].CopyAppearanceTo(_mapAppearance);

        Position = newPosition;
        DrawGameObject(screenSurface);
    }

    private void DrawGameObject(IScreenSurface screenSurface)
    {
        Appearance.CopyAppearanceTo(screenSurface.Surface[Position]);
        screenSurface.IsDirty = true;
    }
}