using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    interface OnPieceCompleteListener
    {
        void OnPieceComplete(Piece piece);
    }
}
