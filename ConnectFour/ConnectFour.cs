using KewlEngine;
using Math = System.Math;

namespace ConnectFour
{
    public class ConnectFour : Game
    {
        public static Vector size = new Vector(9, 6);
        public ConnectFour() : base(size, 30) { }


        public Cursor cursor;
        public bool gameOver = false;


        public override void Start()
        {
            cursor = new Cursor(new Vector((int)size.x / 2, 0));
            grid.Print();
            print($"It's {(cursor.redTurn ? "Red" : "Blue")}'s turn!");
        }

        public override void Update()
        {
            if (gameOver) {
                if (!System.Console.KeyAvailable) return;
                if (System.Console.ReadKey().Key == System.ConsoleKey.R) {
                    throw new Reload();
                }
            }
            if (cursor.Compute(out var move, out var p))
            {
                grid.Print();
                print($"It's", $"{(cursor.redTurn ? "Red" : "Blue")}'s turn!");
            }
            if (move != Cursor.MoveCode.space || p.y >= grid.size.y) return;
            gameOver = CheckWin(p);
        }

        public bool Win(Color color) {
            print(color, "won! Press R to restart."); 
            return true; 
        }

        public bool CheckWin(Vector pos)
        {
            if (grid.GetTile(pos) == null) return false;
            Color currentColor = grid.GetTile(pos).fore; // the current turn
            if (cursor.redTurn == (currentColor == Color.Red)) return false;

            // horizontalCheck 
            for (int y = 0; y < grid.size.y - 3; y++)
            {
                for (int x = 0; x < grid.size.x; x++)
                {
                    if (grid.GetTile(new Vector(x, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x, y + 1))?.fore == currentColor 
                        && grid.GetTile(new Vector(x, y + 2))?.fore == currentColor 
                        && grid.GetTile(new Vector(x, y + 3))?.fore == currentColor)
                    {
                        return Win(currentColor);
                    }
                }
            }
            // verticalCheck
            for (int x = 0; x < grid.size.x - 3; x++)
            {
                for (int y = 0; y < this.grid.size.y; y++)
                {
                    if (grid.GetTile(new Vector(x, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x + 1, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x + 2, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x + 3, y))?.fore == currentColor)
                    {
                        return Win(currentColor);
                    }
                }
            }
            // ascendingDiagonalCheck 
            for (int x = 3; x < grid.size.x; x++)
            {
                for (int y = 0; y < grid.size.y - 3; y++)
                {
                    if (grid.GetTile(new Vector(x, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 1, y + 1))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 2, y + 2))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 3, y + 3))?.fore == currentColor)
                        return Win(currentColor);
                }
            }
            // descendingDiagonalCheck
            for (int x = 3; x < grid.size.x; x++)
            {
                for (int y = 3; y < grid.size.y; y++)
                {
                    if (grid.GetTile(new Vector(x, y))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 1, y - 1))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 2, y - 2))?.fore == currentColor 
                        && grid.GetTile(new Vector(x - 3, y - 3))?.fore == currentColor)
                        return Win(currentColor);
                }
            }
            return false;
        }
    }
}
