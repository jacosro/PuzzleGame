using System;
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
            float orientation = Orientation % 90;
            float tOrientation = targetOrientation % 90;

            return Math.Abs(orientation - tOrientation) < error;
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
