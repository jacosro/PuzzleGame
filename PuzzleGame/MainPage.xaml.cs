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
    public sealed partial class MainPage : Page
    {
        private int numPieces = 1;
        private Image[] allImages; // max images 10
        private Piece[] piecesToMove;
        private Piece[] targetPieces;

        public MainPage()
        {
            this.InitializeComponent();

            allImages = new Image[10]{ piece1, piece2, piece3, piece4, piece5, piece6, piece7, piece8, piece9, piece10 };
            piecesToMove = new Piece[numPieces / 2];
            targetPieces = new Piece[numPieces / 2];

            int i = 0;

            while (i < numPieces - 1)
            {
                piecesToMove[i] = Pieces.NewPiece(rootLayout, allImages[i], true);
            }
        }

        private Piece FindPieceByImage(Image image)
        {
            for (int i = 0; i < 10; i++)
            {
                if (allImages[i].Equals(image))
                {
                    return pieces[i];
                }
            }

            return null;
        }
    }
}
