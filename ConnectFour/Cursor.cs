using KewlEngine;
using Console = System.Console;
using Key = System.ConsoleKey;

namespace ConnectFour
{
    public class Cursor
    {
        public static Cursor Inst;

        public bool redTurn = true;
        public Vector pos;
        private Grid grid { get { return Grid.Inst; } set { Grid.Inst = grid; } }
        public Cursor(Vector pos)
        {
            this.pos = pos;
            this.grid = Grid.Inst;
            Cursor.Inst = this;
            grid.SetTile(pos, new Tile(Color.Black, Color.White, ' '));
        }
        private MoveCode HandleInput()
        {
            if (!Console.KeyAvailable) return MoveCode.none;
            var key = Console.ReadKey();
            if (key.Key == Key.A) return MoveCode.left;
            if (key.Key == Key.D) return MoveCode.right;
            if (key.Key == Key.Spacebar) return MoveCode.space;
            return MoveCode.none;
        }

        private Vector CalcPosition(MoveCode move)
        {
            if (move == MoveCode.left && grid.InBounds(pos + Vector.left)) return Vector.left;
            if (move == MoveCode.right && grid.InBounds(pos + Vector.right)) return Vector.right;
            return Vector.zero;
        }

        private bool FindEmptyPosition(Vector pos, out Vector p)
        {
            p = pos;
            if (p.y == grid.size.y) return false;
            var tile = grid.GetTile(p);
            if (tile == null || tile.text == ' ') return true;
            return FindEmptyPosition(pos + Vector.up, out p);
        }

        public bool Compute(out MoveCode move, out Vector last)
        {
            Console.SetCursorPosition((int)grid.size.x, (int)grid.size.y + 3);
            Console.ForegroundColor = Console.BackgroundColor = System.ConsoleColor.Black;
            last = Vector.zero;
            move = HandleInput();
            if (move == MoveCode.none) return false;
            var toAdd = CalcPosition(move);
            Tile t;
            if (toAdd != Vector.zero)
            {
                t = grid.GetTile(pos);
                if (t != null) {
                    t.back = Color.Black;
                    grid.SetTile(pos, t);
                }
                pos += toAdd;
            }
            t = grid.GetTile(pos);
            if (t == null) t = new Tile(Color.Black, Color.White, ' ');
            t.back = Color.White;
            if (move != MoveCode.space)
            {
                grid.SetTile(pos, t);
                return true;
            }
            t = new Tile(redTurn ? Color.Red : Color.Blue, Color.White, '\u25A0');
            if (!FindEmptyPosition(pos, out var p))
            {
                p = grid.size + Vector.one * 2;
                return false;
            }
            if (p.y != 0) t.back = Color.Black;
            grid.SetTile(p, t);
            last = p;
            redTurn = !redTurn;
            return true;
        }

        public enum MoveCode { none, right, left, space }
    }
}
