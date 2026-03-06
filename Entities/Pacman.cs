using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman.Entities;

public sealed class Pacman
{
    private Texture2D _texture;

    public Vector2 Position { get; set; }
    public void LoadContent(ContentManager content, string assetName)
    {
        _texture = content.Load<Texture2D>(assetName);
    }

    public void Update(GameTime gameTime)
    {
        // Movement/animation will go here later.
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_texture == null)
            return;

        var origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
        spriteBatch.Draw(_texture, Position, null, Color.White, 0f, origin, 2f, SpriteEffects.None, 0f);
    }
}