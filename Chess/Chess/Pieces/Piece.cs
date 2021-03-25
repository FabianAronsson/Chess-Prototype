using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess.Pieces
{
    public abstract class Piece : Button
    {
        public abstract string pieceName { get; set; }

        public int value;
        public int xPosition;
        public int yPosition;
    }
}
