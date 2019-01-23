using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PuzzleGame
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page, OnPuzzleCompleteListener
    {
        private Pieces pieces;
        private Piece[] piecesToMove;
        private Piece[] targetPieces;

        public MainPage()
        {
            if (Pieces.NUM_PIECES < 1 || Pieces.NUM_PIECES > 5)
                throw new Exception("NUM_PIECES must be between 1 and 5");

            this.InitializeComponent();

            Init();
        }

        private void Init()
        {
            pieces = Pieces.Instance;

            piecesToMove = new Piece[Pieces.NUM_PIECES];
            targetPieces = new Piece[Pieces.NUM_PIECES];

            for (int i = 0; i < Pieces.NUM_PIECES; i++)
            {
                targetPieces[i] = pieces.NewTargetPiece(rootLayout);
                piecesToMove[i] = pieces.NextPiece(rootLayout, targetPieces[i]);
            }

            // TextBlock to congratulate 

            textBox.Visibility = Visibility.Collapsed;

            pieces.AddOnPuzzleCompleteListener(this);
        }

        public void OnComplete()
        {
            textBox.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            pieces.Reset();

            for (int i = 0; i < piecesToMove.Length; i++)
            {
                Piece piece = piecesToMove[i];
                Piece target = targetPieces[i];

                piece.Visibility = Visibility.Collapsed;
                target.Visibility = Visibility.Collapsed;
            }

            Init();
        }
    }
}
