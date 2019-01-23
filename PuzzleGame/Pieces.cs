using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PuzzleGame
{ 
    class Pieces
    {
        public const int NUM_PIECES = 3;

        private static readonly int[] PIECES = new int[5] { CIRCLE, SQUARE, TRIANGLE, PENTAGON, HEXAGON };
        private static readonly Color[] COLORS = new Color[5] {
            Color.FromArgb(255, 255, 0, 0), // Red
            Color.FromArgb(255, 0, 255, 0), // green
            Color.FromArgb(255, 0, 0, 255), // blue
            Color.FromArgb(255, 255, 255, 0), // yellow
            Color.FromArgb(255, 0, 255, 255), // light blue
        };

        private static double NextX 
        {
            get => (Window.Current.Bounds.Width / 2 * -1) + (Window.Current.Bounds.Width * (index + 1) / (NUM_PIECES + 1)); // Position on window of the element based on the index
        }

        private static int index = 0;

        private const int CIRCLE = 0;
        private const int SQUARE = 1;
        private const int TRIANGLE = 2;
        private const int PENTAGON = 3;
        private const int HEXAGON = 4;

        public static Piece NextPiece(Grid root, Piece target)
        {
            Piece nextPiece = null;

            switch (PIECES[index])
            {
                case CIRCLE:
                    nextPiece = new Circle(root, GetNextPiecePosition(), COLORS[index], isTarget: false, target: target);
                    break;
                case SQUARE:
                    nextPiece = new Square(root, GetNextPiecePosition(), COLORS[index], isTarget: false, target: target);
                    break;
                case TRIANGLE:
                    nextPiece = new Triangle(root, GetNextPiecePosition(), COLORS[index], isTarget: false, target: target);
                    break;
                case PENTAGON:
                    break;
                case HEXAGON:
                    break;
            }

            index = index == 4 ? 0 : ++index; // update index

            return nextPiece;
        }

        private static Point GetNextPiecePosition()
        {
            double partitionX = NextX;
            double partitionY = Window.Current.Bounds.Height / 4;


            return new Point
            (
                partitionX,
                partitionY
            );
        }

        private static Point GetNextTargetPosition()
        {
            double partitionX = NextX;
            double partitionY = Window.Current.Bounds.Height / 4 * -1;

            return new Point
            (
                partitionX,
                partitionY
            );
        }

        public static Piece NewTargetPiece(Grid root)
        {
            Piece target = null;

            switch (PIECES[index])
            {
                case CIRCLE:
                    target = new Circle(root, GetNextTargetPosition(), Colors.Gray, orientation: (float) Utils.RandomDouble(0, 360), scale: Utils.RandomDouble(0.5, 2.5));
                    break;
                case SQUARE:
                    target = new Square(root, GetNextTargetPosition(), Colors.Gray, orientation: (float)Utils.RandomDouble(0, 360), scale: Utils.RandomDouble(0.5, 2.5));
                    break;
                case TRIANGLE:
                    target = new Triangle(root, GetNextTargetPosition(), Colors.Gray, orientation: (float)Utils.RandomDouble(0, 360), scale: Utils.RandomDouble(0.5, 2.5));
                    break;
                case PENTAGON:
                    break;
                case HEXAGON:
                    break;
            }

            return target;
        }
    }
}
