using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Pacman.Systems;

public static class WallSystem
{
    public static List<Rectangle> CreateDefaultWalls()
    {
        return new List<Rectangle>
        {
            new Rectangle(0, 0, 1280, 40),
            new Rectangle(0, 680, 1280, 40),
            new Rectangle(0, 0, 40, 720),
            new Rectangle(1240, 0, 40, 720),

            new Rectangle(160, 120, 960, 40),
            new Rectangle(160, 240, 40, 280),
            new Rectangle(280, 240, 720, 40),
            new Rectangle(960, 240, 40, 280),
            new Rectangle(160, 520, 960, 40),
            new Rectangle(280, 360, 600, 40)
        };
    }
}