using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace PuzzleGame
{ 
    class Pieces
    {
        private static readonly int[] PIECES = new int[5] { 0, 1, 2, 3, 4 };
        private static int index = 0;

        private const int CIRCLE = 0;
        private const int SQUARE = 1;
        private const int TRIANGLE = 2;
        private const int PENTAGON = 3;
        private const int HEXAGON = 4;

        public static Piece NewPiece(Grid grid, Image image, bool target = false)
        {
            Piece nextPiece = null;

            switch (PIECES[index])
            {
                case CIRCLE:
                    break;
                case SQUARE:
                    break;
                case TRIANGLE:
                    break;
                case PENTAGON:
                    break;
                case HEXAGON:
                    break;
            }

            index = index == 4 ? 0 : ++index; // update index

            return nextPiece;
        }
    }
}
