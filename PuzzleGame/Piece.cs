using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Shapes;
using Windows.Foundation;
using System.Diagnostics;
using System;
using Windows.UI.Xaml;

namespace PuzzleGame
{
    abstract class Piece
    {
        protected double PosX { get; set; }
        protected double PosY { get; set; }
        protected float Orientation { get; set; }
        protected double Scale { get; set; }
        private OnPieceCompleteListener OnPieceCompleteListener;

        public Visibility Visibility { set => Shape.Visibility = value; }

        protected readonly bool IsTarget;

        protected Shape Shape;
        protected Piece Target;

        protected CompositeTransform compositeTransform;

        protected Piece (Grid grid, Point position, Color color, float orientation = 0, double scale = 1, bool isTarget = true, Piece target = null)
        {
            PosX = position.X;
            PosY = position.Y;

            Orientation = orientation;
            Scale = scale;

            IsTarget = isTarget;

            Target = target;

            InitializeShape();

            Shape.ManipulationMode = 
                IsTarget 
                    ? ManipulationModes.None 
                    : ManipulationModes.TranslateX | ManipulationModes.TranslateY | ManipulationModes.Scale | ManipulationModes.Rotate;

            Shape.Fill =
                IsTarget
                    ? new SolidColorBrush(Colors.Gray)
                    : new SolidColorBrush(color);

            compositeTransform = new CompositeTransform
            {
                CenterX = Shape.ActualWidth / 2.0,
                CenterY = Shape.ActualHeight / 2.0,
                TranslateX = PosX,
                TranslateY = PosY,
                Rotation = Orientation,
                ScaleX = Scale,
                ScaleY = Scale
            };

            Shape.RenderTransform = compositeTransform;

            Shape.ManipulationDelta += OnDelta;

            grid.Children.Add(Shape);
        }
       
        internal abstract void InitializeShape();

        public void OnDelta(object sender, ManipulationDeltaRoutedEventArgs e)
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

            if (IsOK())
            {
                Shape.ManipulationMode = ManipulationModes.None;

                Shape.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                Target.Shape.Visibility = Windows.UI.Xaml.Visibility.Collapsed;

                OnPieceCompleteListener.OnPieceComplete(this);
            }
        }

        public bool IsOK()
        {
            if (IsTarget)
                return false;

            int error = 3;
            double scaleError = 0.2;

            return Math.Abs(PosX - Target.PosX) < error
                && Math.Abs(PosY - Target.PosY) < error
                && Math.Abs(Scale - Target.Scale) < scaleError
                && CheckOrientation(Target.Orientation, error);
        }

        internal abstract bool CheckOrientation(float targetOrientation, int error);

        public void SetOnPieceCompleteListener(OnPieceCompleteListener listener)
        {
            OnPieceCompleteListener = listener;
        }
    }
}
