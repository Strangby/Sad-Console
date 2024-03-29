﻿using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;

namespace SadConsoleGame;

internal class Map
{
    private List<GameObject> _mapObjects;
    private ScreenSurface _mapSurface;
    private string trap;

    public IReadOnlyList<GameObject> GameObjects => _mapObjects.AsReadOnly();
    public ScreenSurface SurfaceObject => _mapSurface;
    public GameObject UserControlledObject { get; set; }

    public string[] trap_lista = new string[1000];
    
    public Map(int mapWidth, int mapHeight)
    {
        _mapObjects = new List<GameObject>();
        _mapSurface = new ScreenSurface(mapWidth, mapHeight);
        _mapSurface.UseMouse = false;

        FillBackground();

        UserControlledObject = new GameObject(new ColoredGlyph(Color.White, Color.Black, 2), _mapSurface.Surface.Area.Center, _mapSurface);

        for (int i = 0; i < 50; i++)
        {
            CreateTreasure();
        }

        for (int i = 0; i < 10; i++)
        {
            CreateTrap();
            trap_lista.Append(trap);
        }

        for (int i = 0; i < 200; i++)
        {
            CreateWall();
        }
    }

    public bool TryGetMapObject(Point position, [NotNullWhen(true)] out GameObject? gameObject)
    {
        foreach (var otherGameObject in _mapObjects)
        {
            if (otherGameObject.Position == position)
            {
                gameObject = otherGameObject;
                return true;
            }
        }

        gameObject = null;
        return false;
    }

    public void RemoveMapObject(GameObject mapObject)
    {
        if (_mapObjects.Contains(mapObject))
        {
            _mapObjects.Remove(mapObject);
            mapObject.RestoreMap(this);
        }
    }

    private void FillBackground()
    {
        Color[] colors = new[] { Color.Black, Color.Black, Color.Black, Color.Black };
        float[] colorStops = new[] { 0f, 0.35f, 0.75f, 1f };

        Algorithms.GradientFill(_mapSurface.FontSize,
                                _mapSurface.Surface.Area.Center,
                                _mapSurface.Surface.Width / 3,
                                45,
                                _mapSurface.Surface.Area,
                                new Gradient(colors, colorStops),
                                (x, y, color) => _mapSurface.Surface[x, y].Background = color);
    }
    private void CreateTreasure()
    {
        for (int i = 0; i < 1000; i++)
        {
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                             Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            Treasure treasure = new Treasure(randomPosition, _mapSurface);
            _mapObjects.Add(treasure);
            break;
        }
    }
    private void CreateTrap()
    {
        for (int i = 0; i < 1000; i++)
        {
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            Trap trap = new Trap(randomPosition, _mapSurface);
            _mapObjects.Add(trap);
            break;
        }
    }
    private void CreateWall()
    {
        for (int i = 0; i < 1000; i++)
        {
            Point randomPosition = new Point(Game.Instance.Random.Next(0, _mapSurface.Surface.Width),
                                                Game.Instance.Random.Next(0, _mapSurface.Surface.Height));

            bool foundObject = _mapObjects.Any(obj => obj.Position == randomPosition);
            if (foundObject) continue;

            Wall wall = new Wall(randomPosition, _mapSurface);
            _mapObjects.Add(wall);
            break;
        }
    }
}