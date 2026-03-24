using Microsoft.Xna.Framework.Input;

namespace Pacman.Systems;

public static class MovementSystem
{
    private static KeyboardState _currentKeyState;
    private static KeyboardState _previousKeyState;

    public static void Update()
    {
        _previousKeyState = _currentKeyState;
        _currentKeyState = Keyboard.GetState();
    }

    public static bool HasBeenPressed(Keys key)
    {
        return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
    }

    public static bool IsDown(Keys key)
    {
        return _currentKeyState.IsKeyDown(key);
    }
}