using SadConsole.Configuration;

Settings.WindowTitle = "My SadConsole Game";

Game.Create(90, 30, Startup);
Game.Instance.Run();
Game.Instance.Dispose();

static void Startup(object? sender, GameHost host)
{
    Console startingConsole = Game.Instance.StartingConsole!;

    Game.Instance.StartingConsole!.FillWithRandomGarbage(SadConsole.Game.Instance.StartingConsole!.Font);
    Game.Instance.StartingConsole.Fill(new Rectangle(3, 3, 23, 3), Color.Purple, Color.Black, 0, Mirror.None);
    Game.Instance.StartingConsole.Print(5, 4, "I Always Come Back");
    startingConsole.DrawBox(new Rectangle(3, 3, 23, 3), ShapeParameters.CreateBorder(new ColoredGlyph(Color.Purple, Color.Black, 176)));
}