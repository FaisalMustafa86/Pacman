using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Pacman.Entities;

namespace Pacman.Screens;

public class PlayScreen : GameScreen
{
    private readonly Entities.Pacman _pacman = new();
    private SpriteBatch _spriteBatch;

    public PlayScreen(Game game) : base(game)
    {
    }

    public override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pacman.LoadContent(Content, "Graphics/pacman-right/1");

        var center = new Vector2(GraphicsDevice.Viewport.Width / 2f, GraphicsDevice.Viewport.Height / 2f);
        _pacman.Position = center;
    }

    public override void Update(GameTime gameTime)
    {
        _pacman.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        _pacman.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}