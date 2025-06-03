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

        public void LongCastling(Color c)
        {
            if (c == Color.White)
            {
                if (GameBoard[0, 7] != null &&
                   GameBoard[0, 7].Name == ChessPieceName.Rook &&
                   !GameBoard[0, 7].WasAlreadyMoved &&
                   GameBoard[0, 3] != null &&
                   GameBoard[0, 3].Name == ChessPieceName.King &&
                   !GameBoard[0, 3].WasAlreadyMoved &&
                   GameBoard[0, 4] == null &&
                   GameBoard[0, 5] == null &&
                   GameBoard[0, 6] == null)
                {
                    GameBoard[0, 4] = GameBoard[0, 7];
                    GameBoard[0, 5] = GameBoard[0, 3];
                    GameBoard[0, 7] = null;
                    GameBoard[0, 3] = null;

                    ToMove = Color.Black;



                }
            }
            else if (c == Color.Black)
            {
                if (GameBoard[7, 7] != null &&
                    GameBoard[7, 7].Name == ChessPieceName.Rook &&
                    !GameBoard[7, 7].WasAlreadyMoved &&
                    GameBoard[7, 3] != null &&
                    GameBoard[7, 3].Name == ChessPieceName.King &&
                   !GameBoard[7, 3].WasAlreadyMoved &&
                   GameBoard[7, 4] == null &&
                   GameBoard[7, 5] == null &&
                  GameBoard[7, 6] == null)
                {
                    GameBoard[7, 4] = GameBoard[7, 7];
                    GameBoard[7, 5] = GameBoard[7, 3];
                    GameBoard[7, 7] = null;
                    GameBoard[7, 3] = null;

                    ToMove = Color.White;



                }
            }
        }
        public void ShortCastling(Color c)
        {
            if (c == Color.White)
            {
                if (GameBoard[0, 0] != null &&
                    GameBoard[0, 0].Name == ChessPieceName.Rook &&
                    !GameBoard[0, 0].WasAlreadyMoved &&
                    GameBoard[0, 3] != null &&
                    GameBoard[0, 3].Name == ChessPieceName.King &&
                    !GameBoard[0, 3].WasAlreadyMoved &&
                    GameBoard[0, 1] == null &&
                    GameBoard[0, 2] == null)
                {
                    GameBoard[0, 2] = GameBoard[0, 0];
                    GameBoard[0, 1] = GameBoard[0, 3];
                    GameBoard[0, 0] = null;
                    GameBoard[0, 3] = null;

                    ToMove = Color.Black;



                }
            }
            else if (c == Color.Black)
            {
                if (GameBoard[7, 0] != null &&
                   GameBoard[7, 0].Name == ChessPieceName.Rook &&
                   !GameBoard[7, 0].WasAlreadyMoved &&
                   GameBoard[7, 3] != null &&
                   GameBoard[7, 3].Name == ChessPieceName.King &&
                   !GameBoard[7, 3].WasAlreadyMoved &&
                   GameBoard[7, 1] == null &&
                   GameBoard[7, 2] == null)
                {
                    GameBoard[7, 2] = GameBoard[7, 0];
                    GameBoard[7, 1] = GameBoard[7, 3];
                    GameBoard[7, 0] = null;
                    GameBoard[7, 3] = null;

                    ToMove = Color.White;


                }
            }
        }

        public Color? FindCheckmate(Color color)
        {
            ChessPiece[,] boardCopy = Copy2DArray(GameBoard);

            int kingX = 0;
            int kingY = 0;

            for (int i = 0; i < boardCopy.GetLength(0); i++)
            {
                for (int j = 0; j < boardCopy.GetLength(1); j++)
                {
                    if (boardCopy[i, j] != null && boardCopy[i, j].Name == ChessPieceName.King && boardCopy[i, j].Color == color)
                    {
                        kingX = i;
                        kingY = j;

                        break;
                    }
                }
            }

            bool inCheck = IsKingInCheck(color, boardCopy);

            if (!inCheck)
            {
                return null;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (boardCopy[i, j] != null && boardCopy[i, j].Color == color)
                    {
                        for (int k = 0; k < 8; k++)
                        {
                            for (int l = 0; l < 8; l++)
                            {
                                if (boardCopy[i, j].IsMoveLegal(i, j, k, l, boardCopy, color, true))
                                {
                                    ChessPiece[,] tmpBoard = Copy2DArray(boardCopy);
                                    tmpBoard[k, l] = tmpBoard[i, j];
                                    tmpBoard[i, j] = null;

                                    if (!IsKingInCheck(color, tmpBoard))
                                    {
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return color;
        }
        private bool IsKingInCheck(Color color, ChessPiece[,] board)
        {
            int kingX = -1, kingY = -1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].Name == ChessPieceName.King && board[i, j].Color == color)
                    {
                        kingX = i;
                        kingY = j;
                        break;
                    }
                }
            }
            if (kingX == -1 || kingY == -1)
                return false;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null && board[i, j].Color != color)
                    {
                        if (board[i, j].IsMoveLegal(i, j, kingX, kingY, board, board[i, j].Color, true))


                            return true;
                    }
                }
            }
            return false;
        }

    }
}