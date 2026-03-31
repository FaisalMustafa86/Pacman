using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Pacman.Systems;

public static class WallSystem
{
    public const int TileSize = 40;

    public static List<Rectangle> CreateWallsFromMap(string[] mapLines)
    {
        var walls = new List<Rectangle>();

        for (int row = 0; row < mapLines.Length; row++)
        {
            var cells = mapLines[row].Split(',', StringSplitOptions.None);

            for (int col = 0; col < cells.Length; col++)
            {
                var cell = cells[col].Trim();

                if (cell == "W")
                {
                    walls.Add(new Rectangle(
                        col * TileSize,
                        row * TileSize,
                        TileSize,
                        TileSize));
                }
            }
        }

        return walls;
    }
}