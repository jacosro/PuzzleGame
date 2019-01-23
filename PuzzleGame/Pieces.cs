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
    class Pieces : OnPieceCompleteListener
    {
        public static int numPieces = 2;

        private const int CIRCLE = 0;
        private const int SQUARE = 1;
        private const int TRIANGLE = 2;
        private const int PENTAGON = 3;
        private const int HEXAGON = 4;

        private static readonly int[] PIECES = new int[5] { CIRCLE, SQUARE, TRIANGLE, PENTAGON, HEXAGON };

        private static readonly Color[] COLORS = new Color[5] {
            Color.FromArgb(255, 255, 0, 0), // Red
            Color.FromArgb(255, 0, 255, 0), // green
            Color.FromArgb(255, 0, 0, 255), // blue
            Color.FromArgb(255, 255, 255, 0), // yellow
            Color.FromArgb(255, 0, 255, 255), // light blue
        };

        private static Pieces instance = null;

        public static Pieces Instance { get
            {
                if (instance == null)
                    instance = new Pieces();

                return instance;
            }
        }

        private int index = 0;

        private readonly List<double> Positions;
        private readonly List<double> TargetPositions;

        private OnPuzzleCompleteListener PuzzleCompleteListener;

        private int CompleteCount = 0;

        private Pieces()
        {
            Positions = new List<double>(numPieces);
            TargetPositions = new List<double>(numPieces);

            for (int i = 0; i < numPieces; i++)
            {
                double pos = (Window.Current.Bounds.Width / 2 * -1) + (Window.Current.Bounds.Width * (i + 1) / (numPieces + 1)); // Position on window of the element based on the index

                Positions.Add(pos);
                TargetPositions.Add(pos);
            }
        }

        public void AddOnPuzzleCompleteListener(OnPuzzleCompleteListener listener)
        {
            PuzzleCompleteListener = listener;
        }

        internal void Reset()
        {
            instance = new Pieces();
        }

        public Piece NextPiece(Grid root, Piece target)
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

            nextPiece.SetOnPieceCompleteListener(this);

            index = index == 4 ? 0 : ++index; // update index

            return nextPiece;
        }

        private Point GetNextPiecePosition()
        {
            double partitionX = Positions[index];
            double partitionY = Window.Current.Bounds.Height / 4;


            return new Point
            (
                partitionX,
                partitionY
            );
        }

        private Point GetNextTargetPosition()
        {
            double partitionX = TargetPositions[Utils.RandomInt(0, TargetPositions.Count)];
            double partitionY = Window.Current.Bounds.Height / 4 * -1;

            TargetPositions.Remove(partitionX);

            return new Point
            (
                partitionX,
                partitionY
            );
        }

        public Piece NewTargetPiece(Grid root)
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

        public void OnPieceComplete(Piece piece)
        {
            if (++CompleteCount == numPieces)
            {
                PuzzleCompleteListener.OnComplete();
            } 
        }
    }
}
