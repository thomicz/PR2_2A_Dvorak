using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace zaverecnyProjektChess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point? firstClick = null;
        private Point? secondClick = null;
        private Board b;

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S)
            {
                if (b.ToMove == Color.White)
                {
                    b.ShortCastling(Color.White);
                    UpdateBoard();
                }
                else if (b.ToMove == Color.Black)
                {
                    b.ShortCastling(Color.Black);
                    UpdateBoard();
                }

            }
            else if (e.Key == Key.L)
            {
                if (b.ToMove == Color.White)
                {
                    b.LongCastling(Color.White);
                    UpdateBoard();
                }
                else if (b.ToMove == Color.Black)
                {
                    b.LongCastling(Color.Black);
                    UpdateBoard();
                }
            }
        }

        public MainWindow()
        {
            b = new Board();

            InitializeComponent();

            this.KeyDown += MainWindow_KeyDown;
            this.Focusable = true;
            this.Focus();


            for (int i = 0; i < 8; i++)
            {
                GameGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < 8; j++)
            {
                GameGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            b.SetupBoard();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Border tile = new Border();
                    tile.Background = ((i + j) % 2 == 0) ? Brushes.Beige : Brushes.SaddleBrown;

                    tile.MouseLeftButtonDown += Tile_MouseLeftButtonDown;
                    tile.Tag = new Point(i, j);

                    if (b.GameBoard != null && b.GameBoard[i, j] != null && b.GameBoard[i, j].Color == Color.White)
                    {
                        if (b.GameBoard[i, j].Name == ChessPieceName.Pawn)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wp.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Knight)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wn.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Bishop)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wb.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Rook)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wr.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Queen)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wq.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.King)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/wk.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }

                    }
                    if (b.GameBoard != null && b.GameBoard[i, j] != null && b.GameBoard[i, j].Color == Color.Black)
                    {

                        if (b.GameBoard[i, j].Name == ChessPieceName.Pawn)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/bp.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Knight)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/bn.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Bishop)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/bb.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Rook)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/br.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.Queen)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/bq.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                        if (b.GameBoard[i, j].Name == ChessPieceName.King)
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri("pack://application:,,,/Pictures/bk.png"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                    }

                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);
                    GameGrid.Children.Add(tile);
                }
            }
        }

        private void Tile_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border clickedTile = sender as Border;
            if (clickedTile == null || !(clickedTile.Tag is Point clickedPosition))
                return;

            if (firstClick == null)
            {
                firstClick = clickedPosition;
            }
            else
            {
                secondClick = clickedPosition;

                int fx = (int)firstClick.Value.X;
                int fy = (int)firstClick.Value.Y;
                int sx = (int)secondClick.Value.X;
                int sy = (int)secondClick.Value.Y;

                //Přesun figurky
                if (b.GameBoard[fx, fy] != null && b.GameBoard[fx, fy].IsMoveLegal(fx, fy, sx, sy, b.GameBoard, b.ToMove))
                {
                    b.GameBoard[fx, fy].Move(fx, fy, sx, sy, b.GameBoard);

                    if (b.GameBoard[sx, sy] is Pawn pawn)
                    {
                        pawn.TryPromote(sx, sy, b.GameBoard);
                    }

                    if (b.ToMove == Color.White)
                    {
                        b.ToMove = Color.Black;
                    }
                    else
                    {
                        b.ToMove = Color.White;
                    }
                }

                firstClick = null;
                secondClick = null;

                //Aktualizace UI
                UpdateBoard();

                if (b.FindCheckmate(Color.White) == Color.White)
                {
                    MessageBox.Show("Bílý král je v šach matu! Černý vyhrává!");
                    Application.Current.Shutdown();

                }
                if (b.FindCheckmate(Color.Black) == Color.Black)
                {
                    MessageBox.Show("Černý král je v šach matu! Bílý vyhrává!");
                    Application.Current.Shutdown();

                }
            }
        }

        private void UpdateBoard()
        {
            GameGrid.Children.Clear();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Border tile = new Border();
                    tile.Background = ((i + j) % 2 == 0) ? Brushes.Beige : Brushes.SaddleBrown;

                    // Nastavení klikacího políčka
                    tile.MouseLeftButtonDown += Tile_MouseLeftButtonDown;
                    tile.Tag = new Point(i, j);

                    if (b.GameBoard != null && b.GameBoard[i, j] != null)
                    {
                        var piece = b.GameBoard[i, j];
                        string imagePath = "";

                        if (piece.Color == Color.White)
                        {
                            switch (piece.Name)
                            {
                                case ChessPieceName.Pawn: imagePath = "wp.png"; break;
                                case ChessPieceName.Knight: imagePath = "wn.png"; break;
                                case ChessPieceName.Bishop: imagePath = "wb.png"; break;
                                case ChessPieceName.Rook: imagePath = "wr.png"; break;
                                case ChessPieceName.Queen: imagePath = "wq.png"; break;
                                case ChessPieceName.King: imagePath = "wk.png"; break;
                            }
                        }
                        else if (piece.Color == Color.Black)
                        {
                            switch (piece.Name)
                            {
                                case ChessPieceName.Pawn: imagePath = "bp.png"; break;
                                case ChessPieceName.Knight: imagePath = "bn.png"; break;
                                case ChessPieceName.Bishop: imagePath = "bb.png"; break;
                                case ChessPieceName.Rook: imagePath = "br.png"; break;
                                case ChessPieceName.Queen: imagePath = "bq.png"; break;
                                case ChessPieceName.King: imagePath = "bk.png"; break;
                            }
                        }

                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            Image pieceImage = new Image();
                            pieceImage.Source = new BitmapImage(new Uri($"pack://application:,,,/Pictures/{imagePath}"));
                            pieceImage.Stretch = Stretch.Uniform;
                            tile.Child = pieceImage;
                        }
                    }

                    Grid.SetRow(tile, i);
                    Grid.SetColumn(tile, j);
                    GameGrid.Children.Add(tile);
                }
            }
        }
    }
}