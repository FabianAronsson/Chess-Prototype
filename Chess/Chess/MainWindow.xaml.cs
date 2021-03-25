using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ImageBrush> WhiteImages = new List<ImageBrush>();
        public List<ImageBrush> BlackImages = new List<ImageBrush>();
        public MainWindow()
        {
            InitializeComponent();
            SetImages();
            CreatePieces();
        }


        public void CreatePieces()
        {
            int indexForWhite = 0;
            int indexForBlack = 0;
            //Black Pieces
            for (int i = 0; i < 9; i++)
            {
                if (i == 8)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Button piece = new Button
                        {
                            Background = BlackImages[8],
                            BorderThickness = new Thickness(0)
                        };
                        Grid.SetRow(piece, 1);
                        Grid.SetColumn(piece, j);
                        Board.Children.Add(piece);
                    }
                }
                else
                {
                    Button piece = new Button
                    {
                        Background = BlackImages[indexForBlack],
                        BorderThickness = new Thickness(0)
                    };
                    Grid.SetRow(piece, 0);
                    Grid.SetColumn(piece, i);
                    Board.Children.Add(piece);
                    indexForBlack++;
                }
            }

            //White Pieces
            for (int i = 47; i < 63; i++)
            {
                if (i == 47)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        Button piece = new Button
                        {
                            Background = WhiteImages[8],
                            BorderThickness = new Thickness(0)
                        };
                        Grid.SetRow(piece, 6);
                        Grid.SetColumn(piece, j);
                        Board.Children.Add(piece);
                    }
                }
                else
                {
                    Button piece = new Button
                    {
                        Background = WhiteImages[indexForWhite],
                        BorderThickness = new Thickness(0)
                    };
                    Grid.SetRow(piece, 7);
                    Grid.SetColumn(piece, indexForWhite);
                    Board.Children.Add(piece);
                    indexForWhite++;
                }
                if (indexForWhite == 8)
                {
                    break;
                }
            }



        }

        public void SetImages()
        {
            List<string> ImagePathsForWhite = new List<string>() { "../../../ChessImages/wRook.png", "../../../ChessImages/wKnight.png",
                "../../../ChessImages/wBishop.png", "../../../ChessImages/wQueen.png", "../../../ChessImages/wKing.png", "../../../ChessImages/wBishop.png",
                "../../../ChessImages/wKnight.png", "../../../ChessImages/wRook.png", "../../../ChessImages/wPawn.png",  };
            List<string> ImagePathsForBlack = new List<string>() { "../../../ChessImages/Rook.png", "../../../ChessImages/Knight.png",
                "../../../ChessImages/Bishop.png", "../../../ChessImages/Queen.png", "../../../ChessImages/King.png", "../../../ChessImages/Bishop.png",
                "../../../ChessImages/Knight.png", "../../../ChessImages/Rook.png", "../../../ChessImages/Pawn.png",  };
            for (int i = 0; i < 9; i++)
            {
                var brush = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri(ImagePathsForWhite[i], UriKind.Relative));
                WhiteImages.Add(brush);


            }
            for (int i = 0; i < 9; i++)
            {
                var brushForBlack = new ImageBrush();
                brushForBlack.ImageSource = new BitmapImage(new Uri(ImagePathsForBlack[i], UriKind.Relative));
                BlackImages.Add(brushForBlack);
            }
        }
    }
}


//C# (CSharp) IDragSourceAdvisor.IsDraggable Examples https://csharp.hotexamples.com/examples/-/IDragSourceAdvisor/IsDraggable/php-idragsourceadvisor-isdraggable-method-examples.html

//Scan board for legal moves -> save legal move coordinate in list per piece per player -> get legal moves and 
//display legal  moves to player -> get player move coordinate -> compare to LegalMoveModel.cs -> if player move
//== any move in LegalMoveModel.cs -> play move, else play sound. 

//Check if played move is a check, if check, play sound and restrict king movement

//MVC, View = xaml, Intermediator = xaml.cs, Controller, Model

//2-Dimensional Array for coordinates of pieces

//Fen-notation, Shredder-FEN notation


//https://codereview.stackexchange.com/questions/213606/chess-move-validator