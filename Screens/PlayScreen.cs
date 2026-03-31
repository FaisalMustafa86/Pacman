using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Pacman.Entities;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using Pacman.Systems;
using System.Collections.Generic;
using System.Linq;

namespace Pacman.Screens;

public class PlayScreen : GameScreen
{
    private readonly Entities.Pacman _pacman = new();
    private readonly Entities.Blinky _blinky = new(); 
    private readonly Entities.clyde _clyde = new(); 
    private readonly Entities.inky _inky = new();
    private readonly Entities.pinky _pinky = new();

    private SpriteBatch _spriteBatch;
    private List<Rectangle> _walls;

    private static readonly string[] Map =
    {
        "W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W",
        "W,-,-,-,C,-,-,-,-,-,-,-,-,-,-,-,W,-,-,-,-,-,-,-,-,-,-,-,C,-,-,-,W",
        "W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W",
        "W,-,-,-,-,-,-,-,C,-,-,-,-,-,-,-,-,-,-,-,-,-,-,-,C,-,-,-,-,-,-,-,W",
        "W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W",
        "W,-,-,-,C,-,-,-,-,W,-,-,-,-,-,-,W,-,-,-,-,-,-,W,-,-,-,-,C,-,-,-,W",
        "W,W,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,W,W",
        " , , , , , , ,W,-,W,-,-,C,-,-,-,-,-,-,-,C,-,-,W,-,W, , , , , , , ",
        "W,W,W,W,W,W,W,W,-,W,-,W,W,W,T,T,T,T,T,W,W,W,-,W,-,W,W,W,W,W,W,W,W",
        "-,-,-,-,-,-,-,-,-,-,-,W, , , , , , , , , ,W,-,-,-,-,-,-,-,-,-,-,-",
        "W,W,W,W,W,W,W,W,-,W,-,W, ,G, , ,G, , ,G, ,W,-,W,-,W,W,W,W,W,W,W,W",
        "-,-,-,-,-,-,-,-,-,-,-,W, , , , , , , , , ,W,-,-,-,-,-,-,-,-,-,-,-",
        "W,W,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,W,W",
        " , , , , , , ,W,-,W,-,-,C,-,-,-,-,-,-,-,C,-,-,W,-,W, , , , , , , ",
        "W,W,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,W,W",
        "W,-,-,-,C,-,-,-,-,W,P,-,-,-,-,-,W,-,-,-,-,-,-,W,-,-,-,-,C,-,-,-,W",
        "W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W",
        "W,-,-,-,-,-,-,-,C,-,-,-,-,-,-,-,-,-,-,-,-,-,-,-,C,-,-,-,-,-,-,-,W",
        "W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W,-,W,W,W,W,W,W,-,W,W,W,W,W,W,-,W",
        "W,-,-,-,C,-,-,-,-,-,-,-,-,-,-,-,W,-,-,-,-,-,-,-,-,-,-,-,C,-,-,-,W",
        "W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W,W"
    };

    public PlayScreen(Game game) : base(game)
    {
    }

    public override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _walls = WallSystem.CreateWallsFromMap(Map);

        _pacman.LoadContent(Content, "Graphics/pacman-right/1");
        _pacman.Position = new Vector2(10 * WallSystem.TileSize + 20, 15 * WallSystem.TileSize + 20);

        _blinky.LoadContent(Content, "Graphics/ghosts/blinky");
        _blinky.Position = new Vector2(560, 200);

        _clyde.LoadContent(Content, "Graphics/ghosts/clyde");
        _clyde.Position = new Vector2(610, 200);

        _inky.LoadContent(Content, "Graphics/ghosts/inky");
        _inky.Position = new Vector2(660, 200);

        _pinky.LoadContent(Content, "Graphics/ghosts/pinky");
        _pinky.Position = new Vector2(710, 200);
    }

    public override void Update(GameTime gameTime)
    {
        MovementSystem.Update();

        if (MovementSystem.HasBeenPressed(Keys.Up)) _pacman.NextDirection = Direction.Up;
        if (MovementSystem.HasBeenPressed(Keys.Down)) _pacman.NextDirection = Direction.Down;
        if (MovementSystem.HasBeenPressed(Keys.Left)) _pacman.NextDirection = Direction.Left;
        if (MovementSystem.HasBeenPressed(Keys.Right)) _pacman.NextDirection = Direction.Right;

        var previousPosition = _pacman.Position;

        _pacman.Update(gameTime);

        if (_walls.Exists(w => w.Intersects(_pacman.Bounds)))
            _pacman.Position = previousPosition;

        _blinky.Update(gameTime);
        _clyde.Update(gameTime);
        _inky.Update(gameTime);
        _pinky.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();

        foreach (var wall in _walls)
            _spriteBatch.DrawRectangle(wall, Color.Navy, 2f);

        _pacman.Draw(_spriteBatch);
        _blinky.Draw(_spriteBatch);
        _clyde.Draw(_spriteBatch);
        _inky.Draw(_spriteBatch);
        _pinky.Draw(_spriteBatch);

        _spriteBatch.End();
    }
}