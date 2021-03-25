using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess
{
    public class MoveModel : Pieces.Piece
    {
        public int srcX;
        public int srcY;
        public int destX;
        public int destY;
        public bool pieceSelected = false;

        public Button piece;

        public override string pieceName { get; set; }
    }
}
