using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace KewlEngine
{
    public static class Core
    {
        public static int lastLength = 0;
        static Game currentGame;
        static void Main(string[] args)
        {
            while (currentGame == null) NewGame();
        }

        static void NewGame()
        {
            currentGame = new ConnectFour.ConnectFour();
            try
            {
                currentGame.Start();
                int time = 1000 / currentGame.fps;
                while (true)
                {
                    Thread.Sleep(time);
                    currentGame.Update();
                }
            } catch (Reload r)
            {
                currentGame = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                NewGame();
            }
        }
    }

    public class Reload : Exception { }
}
