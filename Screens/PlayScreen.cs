using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using Pacman.Entities;

namespace Pacman.Screens;

public class PlayScreen : GameScreen
{
    private readonly Entities.Pacman _pacman = new();
    private readonly Entities.Blinky _blinky = new(); 
    private readonly Entities.Blinky _clyde = new(); 
    private readonly Entities.Blinky _inky = new(); 
    private readonly Entities.Blinky _pinky = new(); 
    private SpriteBatch _spriteBatch;

    public PlayScreen(Game game) : base(game)
    {
    }

    public override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _pacman.LoadContent(Content, "Graphics/pacman-right/1");
        _pacman.Position = new Vector2(640,460);
        
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
        _pacman.Update(gameTime);
        _blinky.Update(gameTime);
        _clyde.Update(gameTime);
        _inky.Update(gameTime);
        _pinky.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        _spriteBatch.Begin();
        _pacman.Draw(_spriteBatch);
        _blinky.Draw(_spriteBatch);
        _clyde.Draw(_spriteBatch);
        _inky.Draw(_spriteBatch);
        _pinky.Draw(_spriteBatch);
        _spriteBatch.End();
    }
}