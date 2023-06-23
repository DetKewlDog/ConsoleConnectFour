using System;
using System.Collections.Generic;
using System.Text;

namespace KewlEngine
{
    public class Tile
    {
        public Color fore;
        public Color back;
        public char text;
        public Tile(Color fore, Color back, char text) {
            this.fore = fore;
            this.back = back;
            this.text = text;
        }
        public override string ToString() => text.ToString();
    }

    public enum Color
    {
        Black,
        DarkBlue,
        DarkGreen,
        DarkCyan,
        DarkRed,
        DarkMagenta,
        DarkYellow,
        Gray,
        DarkGray,
        Blue,
        Green,
        Cyan,
        Red,
        Magenta,
        Yellow,
        White

    }
}
