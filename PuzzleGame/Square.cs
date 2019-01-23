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
            float orientation = Orientation;

            while (orientation < 0)
            {
                orientation += 360;
            }

            orientation = orientation % 90;
            float tOrientation = targetOrientation % 90;

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
