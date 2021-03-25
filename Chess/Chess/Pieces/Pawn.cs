using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace Chess.Pieces
{
    public class Pawn : Piece 
    {
        public string pawnName;
        public bool canTwoStepMove;
        public bool canEnPassant;

        public override string pieceName { get; set; }

    }
}
