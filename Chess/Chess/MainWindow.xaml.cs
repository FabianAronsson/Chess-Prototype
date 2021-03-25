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
        public List<BitmapImage> WhiteImages = new List<BitmapImage>();
        public List<BitmapImage> BlackImages = new List<BitmapImage>();
        public MoveModel moveModel = new MoveModel();
        public MainWindow()
        {
            InitializeComponent();
            SetImages();
            CreatePieces();
        }

        private void GetPositionOfButton(object sender, RoutedEventArgs e)
        {
            if (e.Source is Button button)
            {
                
                if (!moveModel.pieceSelected)
                {
                    //get coordinate of piece
                    moveModel.srcX = Grid.GetColumn(button);
                    moveModel.srcY = Grid.GetRow(button);
                    //save piece
                    button.Background = Brushes.Red;
                    moveModel.piece = button;
                    moveModel.pieceName = button.Tag.ToString();
                    moveModel.pieceSelected = true;
                }
                else
                {
                    //get coordinate of destination
                    moveModel.destX = Grid.GetColumn(button);
                    moveModel.destY = Grid.GetRow(button);
                    //remove destination piece
                    Board.Children.Remove(button);
                    //remove the source piece
                    Board.Children.Remove(moveModel.piece);
                    //create an empty square
                    Button square = new Button()
                    {
                        Tag = "square",
                        BorderThickness = new Thickness(0),
                        Background = Brushes.Transparent,
                    };
                    square.Click += new RoutedEventHandler(GetPositionOfButton);

                    //Set coordinate of square
                    Grid.SetColumn(square, moveModel.srcX);
                    Grid.SetRow(square, moveModel.srcY);
                    Board.Children.Add(square);
                    
                    //Set source piece to destination coordinate
                    moveModel.piece.Background = Brushes.Transparent;
                    Grid.SetColumn(moveModel.piece, moveModel.destX);
                    Grid.SetRow(moveModel.piece, moveModel.destY);
                    Board.Children.Add(moveModel.piece);
                    moveModel.pieceSelected = false;
                    
                    if(button.Tag.ToString() ==  "bPawn" ) //should be variable for black and white, not necessarily a specific piece, as it is obvious with correct naming, e.g. wRook, bRook
                    {//Crashes at the moment due to only being usable on pawns, needs fixing. For example a boolean checking if it is white's or black's turn. Each piece needs a specific tag.
                        PlayChessSound("capture");
                        
                    }
                    else
                    {
                        PlayChessSound("nan");
                    }
                }
            }
        }

        public void PlayChessSound(string typeOfMove)
        {
            if(typeOfMove == "capture")
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../ChessFX/Capture.wav");
                player.Play();
            }
            else
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("../../../ChessFX/Move.wav");
                player.Play();
            }
            
        }


        public void ChessGame()
        {
            ChessModel chessValues = new ChessModel();
            while (true)
            {
                WhiteTurn();
                BlackTurn();
            }
        }

        private void BlackTurn()
        {
            throw new NotImplementedException();
        }

        private void WhiteTurn()
        {
            throw new NotImplementedException();
        }


        public void GetLegalMoves()
        {

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
                        Pieces.Pawn pawn = new Pieces.Pawn
                        {
                            Tag = "bPawn",
                            Content = new Image
                            {
                                Source = BlackImages[8],
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            Background = Brushes.Transparent,
                            BorderThickness = new Thickness(0),


                        };
                        pawn.Click += new RoutedEventHandler(GetPositionOfButton);
                        Grid.SetRow(pawn, 1);
                        Grid.SetColumn(pawn, j);
                        Board.Children.Add(pawn);
                    }
                }
                else
                {
                    Button piece = new Button
                    {
                        Content = new Image
                        {
                            Source = BlackImages[indexForBlack],
                            VerticalAlignment = VerticalAlignment.Center
                        },
                        Background = Brushes.Transparent,
                        BorderThickness = new Thickness(0)
                    };
                    piece.Click += new RoutedEventHandler(GetPositionOfButton);
                    Grid.SetRow(piece, 0);
                    Grid.SetColumn(piece, i);
                    Board.Children.Add(piece);
                    indexForBlack++;
                }
            }

            //Empty Squares
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Button square = new Button()
                    {
                        Tag = "square",
                        BorderThickness = new Thickness(0),
                        Background = Brushes.Transparent
                    };
                    square.Click += new RoutedEventHandler(GetPositionOfButton);
                    Grid.SetRow(square, i);
                    Grid.SetColumn(square, j);
                    Board.Children.Add(square);
                }

            }

            //White Pieces
            for (int i = 47; i < 63; i++)
            {
                if (i == 47)
                {
                    for (int j = 0; j < 8; j++)
                    {

                        Pieces.Pawn pawn = new Pieces.Pawn
                        {
                            Tag = "pawn",
                            Content = new Image { 
                                Source = WhiteImages[8],
                                VerticalAlignment = VerticalAlignment.Center
                            },
                            Background = Brushes.Transparent,
                            BorderThickness = new Thickness(0)
                        };
                        pawn.Click += new RoutedEventHandler(GetPositionOfButton);
                        Grid.SetRow(pawn, 6);
                        Grid.SetColumn(pawn, j);
                        Board.Children.Add(pawn);
                    }
                }
                else
                {
                    Button piece = new Button
                    {
                        Content = new Image
                        {
                            Source = WhiteImages[indexForWhite],
                            VerticalAlignment = VerticalAlignment.Center
                        },
                        Background = Brushes.Transparent,
                        BorderThickness = new Thickness(0)
                    };
                    piece.Click += new RoutedEventHandler(GetPositionOfButton);
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
               
                WhiteImages.Add(new BitmapImage(new Uri(ImagePathsForWhite[i], UriKind.Relative)));


            }
            for (int i = 0; i < 9; i++)
            {
                BlackImages.Add(new BitmapImage(new Uri(ImagePathsForBlack[i], UriKind.Relative)));
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

//Fen-notation, Shredder-FEN notation, dictionary


//https://codereview.stackexchange.com/questions/213606/chess-move-validator


//to do: Check if destination piece is white or black, return true/false