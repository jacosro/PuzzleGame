using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;

namespace PuzzleGame
{
    abstract class Piece
    {
        protected double PosX { get; set; }
        protected double PosY { get; set; }
        protected float Orientation { get; set; }
        protected double Scale { get; set; }
        protected readonly bool IsTarget;

        protected Shape Shape { get; set; }
        protected Piece Target;

        protected CompositeTransform compositeTransform = new CompositeTransform();

        public Piece (Grid grid, Color color = Colors.Gray, bool isTarget = false, Piece target = null)
        {
            Target = target;

            IsTarget = isTarget;

            Shape.ManipulationMode = 
                IsTarget 
                    ? ManipulationModes.None 
                    : ManipulationModes.TranslateX | ManipulationModes.TranslateY | ManipulationModes.Scale | ManipulationModes.Rotate;

            Shape.Fill =
                IsTarget
                    ? new SolidColorBrush(Colors.Gray)
                    : new SolidColorBrush(color);

            Orientation = 0;
            Scale = 1;

            PosX = grid.ActualWidth / 2.0;
            PosY = grid.ActualHeight * 2 / 3.0;

            compositeTransform.TranslateX = PosX;
            compositeTransform.TranslateY = PosY;

            Shape.RenderTransform = compositeTransform;

            grid.Children.Add(Shape);
        }

        public void OnDelta(ManipulationDeltaRoutedEventArgs e)
        {
            compositeTransform.CenterX = Shape.ActualWidth / 2.0;
            compositeTransform.CenterY = Shape.ActualHeight / 2.0;

            compositeTransform.ScaleX *= e.Delta.Scale;
            compositeTransform.ScaleY *= e.Delta.Scale;

            Scale *= e.Delta.Scale;

            compositeTransform.TranslateX += e.Delta.Translation.X;
            compositeTransform.TranslateY += e.Delta.Translation.Y;

            PosX += e.Delta.Translation.X;
            PosY += e.Delta.Translation.Y;

            compositeTransform.Rotation += e.Delta.Rotation;

            Orientation += e.Delta.Rotation;

            Shape.RenderTransform = compositeTransform;
        }

        public bool IsOK()
        {
            if (IsTarget)
                return false;

            return PosX == Target.PosX 
                && PosY == Target.PosY 
                && Scale == Target.Scale
                && CheckOrientation();
        }

        protected abstract bool CheckOrientation();
    }
}
