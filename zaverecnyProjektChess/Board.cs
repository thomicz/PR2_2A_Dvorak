namespace zaverecnyProjektChess
{
    internal class Board
    {
        public ChessPiece[,] GameBoard { get; set; }
        public Color ToMove { get; set; } = Color.White;

        public Board()
        {
            GameBoard = new ChessPiece[8, 8];
        }

        public void SetupBoard()
        {
            SetupWhite();
            SetupBlack();
        }

        public void SetupWhite()
        {
            GameBoard[0, 0] = new Rook(Color.White);
            GameBoard[0, 1] = new Knight(Color.White);
            GameBoard[0, 2] = new Bishop(Color.White);
            GameBoard[0, 3] = new King(Color.White);
            GameBoard[0, 4] = new Queen(Color.White);
            GameBoard[0, 5] = new Bishop(Color.White);
            GameBoard[0, 6] = new Knight(Color.White);
            GameBoard[0, 7] = new Rook(Color.White);

            for (int i = 0; i < 8; i++)
            {
                GameBoard[1, i] = new Pawn(Color.White);
            }
        }

        public void SetupBlack()
        {
            GameBoard[7, 0] = new Rook(Color.Black);
            GameBoard[7, 1] = new Knight(Color.Black);
            GameBoard[7, 2] = new Bishop(Color.Black);
            GameBoard[7, 3] = new King(Color.Black);
            GameBoard[7, 4] = new Queen(Color.Black);
            GameBoard[7, 5] = new Bishop(Color.Black);
            GameBoard[7, 6] = new Knight(Color.Black);
            GameBoard[7, 7] = new Rook(Color.Black);

            for (int i = 0; i < 8; i++)
            {
                GameBoard[6, i] = new Pawn(Color.Black);
            }
        }

        public ChessPiece[,] Copy2DArray(ChessPiece[,] original)
        {
            int rows = original.GetLength(0);
            int cols = original.GetLength(1);
            ChessPiece[,] copy = new ChessPiece[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (original[i, j] != null)
                    {
                        var cloned = original[i, j].Clone();
                        copy[i, j] = cloned;
                    }
                }
            }

            return copy;

        }


        public bool IsWhiteKingInCheck(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            ChessPiece[,] boardCopy = Copy2DArray(board);

            boardCopy[sx, sy] = boardCopy[fx, fy];
            boardCopy[fx, fy] = null;

            int kingX = 0;
            int kingY = 0;

            //Najdu krále bílé barvy
            for (int i = 0; i < boardCopy.GetLength(0); i++)
            {
                for (int j = 0; j < boardCopy.GetLength(1); j++)
                {
                    if (boardCopy[i, j] != null && boardCopy[i, j].Name == ChessPieceName.King && boardCopy[i, j].Color == Color.White)
                    {
                        kingX = i;
                        kingY = j;

                        break;
                    }
                }
            }

            for (int i = 0; i < boardCopy.GetLength(0); i++)
            {
                for (int j = 0; j < boardCopy.GetLength(1); j++)
                {
                    if (boardCopy[i, j] != null)
                    {
                        if (boardCopy[i, j].IsMoveLegal(i, j, kingX, kingY, boardCopy, boardCopy[i, j].Color, true))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        public bool IsBlackKingInCheck(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            ChessPiece[,] boardCopy = Copy2DArray(board);

            boardCopy[sx, sy] = boardCopy[fx, fy];
            boardCopy[fx, fy] = null;

            int kingX = 0;
            int kingY = 0;

            //Najdu krále černé barvy
            for (int i = 0; i < boardCopy.GetLength(0); i++)
            {
                for (int j = 0; j < boardCopy.GetLength(1); j++)
                {
                    if (boardCopy[i, j] != null && boardCopy[i, j].Name == ChessPieceName.King && boardCopy[i, j].Color == Color.Black)
                    {
                        kingX = i;
                        kingY = j;

                        break;
                    }
                }
            }

            for (int i = 0; i < boardCopy.GetLength(0); i++)
            {
                for (int j = 0; j < boardCopy.GetLength(1); j++)
                {
                    if (boardCopy[i, j] != null)
                    {
                        if (boardCopy[i, j].IsMoveLegal(i, j, kingX, kingY, boardCopy, boardCopy[i, j].Color, true))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;

        }

        public void LongCastling()
        {
            throw new NotImplementedException();
        }
        public void ShortCastling()
        {
            throw new NotImplementedException();
        }
    }
}