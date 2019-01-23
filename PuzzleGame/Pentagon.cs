﻿using System;
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
    class Pentagon : Piece
    {
        public Pentagon(Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null) : base(grid, position, color, orientation, scale, isTarget, target)
        {

        }

        internal override bool CheckOrientation(float targetOrientation, int error)
        {
            float orientation = Orientation;

            while (orientation < 0)
            {
                orientation += 360;
            }

            orientation = orientation % 360;
            float tOrientation = targetOrientation % 360;

            return Math.Abs(orientation - tOrientation) < error;
        }

        internal override void InitializeShape()
        {
            Shape = new Polygon()
            {
                Height = 100,
                Width = 100
            };

            // Calculate left and right vertex
            int distanceFromTopVertexToCenter = 50;
            double heightOfUnknownVertex = distanceFromTopVertexToCenter * Math.Sin(54 * Math.PI / 180); // (top angle / 2) in radians


            PointCollection points = new PointCollection
            {
                new Point(50, 0), // top vertex
                new Point(100, heightOfUnknownVertex),
                new Point(75, 100),
                new Point(25, 100),
                new Point(0, heightOfUnknownVertex)
            };

            ((Polygon)Shape).Points = points;
        }
    }
}
