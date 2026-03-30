using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman.Entities;

public enum Direction { None, Up, Down, Left, Right }

public sealed class Pacman
{
    private Texture2D _texture;
    private const float Speed = 150f;

    public Direction CurrentDirection = Direction.None;
    public Direction NextDirection = Direction.None;
    public float Rotation;

    public Vector2 Position { get; set; }

    public float HalfWidth => _texture == null ? 0f : (_texture.Width * 2f) / 2f;
    public float HalfHeight => _texture == null ? 0f : (_texture.Height * 2f) / 2f;

    public Rectangle Bounds =>
        new Rectangle(
            (int)(Position.X - HalfWidth),
            (int)(Position.Y - HalfHeight),
            (int)(HalfWidth * 2),
            (int)(HalfHeight * 2));

    public void LoadContent(ContentManager content, string assetName)
    {
        _texture = content.Load<Texture2D>(assetName);
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (NextDirection != Direction.None)
            CurrentDirection = NextDirection;

        Vector2 movement = Vector2.Zero;

        switch (CurrentDirection)
        {
            case Direction.Up:
                movement.Y -= 1;
                Rotation = MathHelper.ToRadians(-90);
                break;
            case Direction.Down:
                movement.Y += 1;
                Rotation = MathHelper.ToRadians(90);
                break;
            case Direction.Left:
                movement.X -= 1;
                Rotation = MathHelper.ToRadians(180);
                break;
            case Direction.Right:
                movement.X += 1;
                Rotation = 0f;
                break;
            case Direction.None:
                return;
        }

        if (movement != Vector2.Zero)
            movement.Normalize();

        Position += movement * Speed * dt;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (_texture == null)
            return;

        var origin = new Vector2(_texture.Width / 2f, _texture.Height / 2f);
        spriteBatch.Draw(_texture, Position, null, Color.White, Rotation, origin, 2f, SpriteEffects.None, 0f);
    }
}