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
    class Hexagon : Piece
    {
        public Hexagon(Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null) : base(grid, position, color, orientation, scale, isTarget, target)
        {

        }

        internal override bool CheckOrientation(float targetOrientation, int error)
        {
            float orientation = Orientation;

            while (orientation < 0)
            {
                orientation += 360;
            }

            orientation = orientation % 45;
            float tOrientation = targetOrientation % 45;

            double calc = Math.Abs(orientation - tOrientation);
            return calc < error;
        }

        internal override void InitializeShape()
        {
            Shape = new Polygon()
            {
                Height = 100,
                Width = 100
            };

            double factor = 100 / 3.0;

            PointCollection points = new PointCollection
            {
                new Point(0, factor),
                new Point(factor, 0),
                new Point(factor * 2, 0),
                new Point(100, factor),
                new Point(100, factor * 2),
                new Point(factor * 2, 100),
                new Point(factor, 100),
                new Point(0, factor * 2)
            };

            ((Polygon)Shape).Points = points;
        }
    }
}
