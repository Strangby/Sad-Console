using SadConsole.Configuration;

Settings.WindowTitle = "My SadConsole Game";

Game.Create(90, 30, Startup);
Game.Instance.Run();
Game.Instance.Dispose();

static void Startup(object? sender, GameHost host)
{
    Console startingConsole = Game.Instance.StartingConsole!;

    startingConsole.Fill(new Rectangle(3, 3, 23, 3), Color.Purple, Color.Black, 0, Mirror.None);
    startingConsole.Print(5, 4, "I Always Come Back");

    startingConsole.DrawBox(new Rectangle(3, 3, 23, 3), ShapeParameters.CreateStyledBox(ICellSurface.ConnectedLineThin,
                                                        new ColoredGlyph(Color.Purple, Color.Black)));

    startingConsole.DrawCircle(new Rectangle(5, 8, 16, 8), ShapeParameters.CreateFilled(new ColoredGlyph(Color.Purple, Color.Black, 176),
                                                           new ColoredGlyph(Color.White, Color.Black)));

    startingConsole.DrawLine(new Point(60, 5), new Point(66, 20), '$', Color.AnsiRed, Color.AnsiRed, Mirror.None);
}