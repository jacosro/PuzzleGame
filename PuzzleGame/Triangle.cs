using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace PuzzleGame
{
    class Triangle : Piece
    {
        public Triangle(Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null) : base(grid, position, color, orientation, scale, isTarget, target)
        {

        }

        internal override bool CheckOrientation(float targetOrientation, int error)
        {
            float orientation = Math.Abs(Orientation) % 360;
            float tOrientation = Math.Abs(targetOrientation) % 360;

            return Math.Abs(orientation - tOrientation) < error;
        }

        internal override void InitializeShape()
        {
            Shape = new Polygon()
            {
                Height = 100,
                Width = 100
            };

            PointCollection points = new PointCollection
            {
                new Point(0, 100),
                new Point(50, 0),
                new Point(100, 100)
            };

            ((Polygon)Shape).Points = points;
        }
    }
}
