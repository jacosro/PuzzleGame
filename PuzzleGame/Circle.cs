using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Shapes;

namespace PuzzleGame
{
    class Circle : Piece
    {

        public Circle(Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null) : base(grid, position, color, orientation, scale, isTarget, target)
        {

        }

        internal override bool CheckOrientation(float targetOrientation, int error)
        {
            return true;
        }

        internal override void InitializeShape()
        {
            Shape = new Ellipse
            {
                Height = 100,
                Width = 100
            };
        }
    }
}
