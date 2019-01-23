using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<string> levels = new ObservableCollection<string>();

        public MainPage()
        {
            this.InitializeComponent();

            levels.Add("1");
            levels.Add("2");
            levels.Add("3");

            comboBox.SelectedItem = "1";

            Init();
        }

        private void Init()
        {
            pieces = Pieces.Instance;

            piecesToMove = new Piece[Pieces.numPieces];
            targetPieces = new Piece[Pieces.numPieces];

            for (int i = 0; i < Pieces.numPieces; i++)
            {
                targetPieces[i] = pieces.NewTargetPiece(rootLayout);
                piecesToMove[i] = pieces.NextPiece(rootLayout, targetPieces[i]);
            }

            textBox.Visibility = Visibility.Collapsed;

            pieces.AddOnPuzzleCompleteListener(this);
        }

        public void OnComplete()
        { 
            textBox.Visibility = Visibility.Visible;
        }

        private void Reset(object sender, RoutedEventArgs e)
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pieces.numPieces = comboBox.SelectedIndex + 1;
            Reset(null, null);
        }
    }
}
