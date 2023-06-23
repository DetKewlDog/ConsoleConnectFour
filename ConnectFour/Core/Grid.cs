using System;

namespace KewlEngine
{
    public class Grid
    {
        public static Grid Inst;

        public Vector size;
        private Tile[,] grid;
        public Grid(Vector size)
        {
            this.size = size;
            this.grid = new Tile[(int)size.x, (int)size.y];
            for (int x = 0; x < size.x; x++)
            {
                for (int y = 0; y < size.y; y++)
                {
                    grid[x, y] = null;
                }
            }
        }

        public bool InBounds(Vector p) => p.x >= 0 && p.y >= 0 && p.x < size.x && p.y < size.y;

        public Tile GetTile(Vector p) =>
            InBounds(p) ? grid[(int)p.x, (int)p.y] : null;

        public void SetTile(Vector p, Tile t)
        {
            if (InBounds(p)) grid[(int)p.x, (int)p.y] = t;
        }

        public void FillTiles(Vector p1, Vector p2, Tile t)
        {
            for (int x = (int)Math.Min(p1.x, p2.x); x < (int)Math.Max(p1.x, p2.x); x++)
            {
                for (int y = (int)Math.Min(p1.y, p2.y); y < (int)Math.Max(p1.y, p2.y); y++)
                {
                    grid[x, y] = t;
                }
            }
        }

        public void Print()
        {
            for (int y = (int)size.y - 1; y >= 0; y--)
            {
                for (int x = 0; x < size.x; x++)
                {
                    Console.SetCursorPosition(x * 2 + 1, (int)size.y - y + 1);
                    var tile = grid[x, y] ?? new Tile(0, 0, ' ');
                    Console.BackgroundColor = (ConsoleColor)tile.back;
                    Console.ForegroundColor = (ConsoleColor)tile.fore;
                    if (x >= 1 && grid[x - 1, y]?.back == Color.White)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(" ");
                    Console.BackgroundColor = (ConsoleColor)tile.back;
                    Console.Write(tile + " ");
                    Console.ResetColor();
                }
            }
        }
    }
}
