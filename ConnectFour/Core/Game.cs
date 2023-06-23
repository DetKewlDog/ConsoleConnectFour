using Console = System.Console;

namespace KewlEngine
{
    public class Game
    {
        protected Grid grid { get { return Grid.Inst; } set { Grid.Inst = grid; } }
        public int fps;
        public Game(Vector size = default, int fps = 0) {
            Console.CursorVisible = false;
            this.grid = Grid.Inst = new Grid(size);
            this.fps = fps;
        }
        public virtual void Start() { }

        public virtual void Update() { }
        protected virtual void log(params object[] objs) {
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.WriteLine(string.Join(" ", objs));
            Console.ForegroundColor = System.ConsoleColor.Black;
        }
        protected virtual void print(params object[] objs) {
            Console.ForegroundColor = System.ConsoleColor.White;
            Console.SetCursorPosition(0, (int)this.grid.size.y + 2);
            Console.Write(string.Join(" ", objs));
            for (int i = string.Join(" ", objs).Length; i <= Core.lastLength; i++)
            {
                Console.SetCursorPosition(i, (int)this.grid.size.y + 2);
                Console.Write(" ");
            }
            Core.lastLength = string.Join(" ", objs).Length;
            Console.ForegroundColor = System.ConsoleColor.Black;
        }
    }
}
