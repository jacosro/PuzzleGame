using System;
using System.Diagnostics;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;

namespace PuzzleGame
{
    class Square : Piece
    {
        public Square(Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null) : base(grid, position, color, orientation, scale, isTarget, target)
        {

        }

        internal override bool CheckOrientation(float targetOrientation, int error)
        {
            Debug.WriteLine("orientation: " + Orientation);
            Debug.WriteLine("target orientation: " + targetOrientation);

            float orientation = Orientation % 90;
            float tOrientation = targetOrientation % 90;

            Debug.WriteLine("orientation modulo: " + orientation);
            Debug.WriteLine("target orientation modulo: " + tOrientation);

            double calc = Math.Abs(orientation - tOrientation);
            return calc < error;
        }

        internal override void InitializeShape()
        {
            Shape = new Windows.UI.Xaml.Shapes.Rectangle
            {
                Width = 100,
                Height = 100
            };
        }
    }
}
