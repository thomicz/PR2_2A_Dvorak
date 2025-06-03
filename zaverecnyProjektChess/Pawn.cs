namespace zaverecnyProjektChess
{
    internal class Pawn : ChessPiece
    {
        private Color _color;

        public Pawn(Color color)
        {
            _color = color;
        }

        public override ChessPieceName Name { get => ChessPieceName.Pawn; }
        public override Color Color => _color;
        public  bool WasAlreadyMoved = false;

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;
        }

        public override ChessPiece Clone()
        {
            Pawn cloned = new Pawn(this.Color);
            cloned.WasAlreadyMoved = this.WasAlreadyMoved;
            return cloned;
        }

        public void TryPromote(int x, int y, ChessPiece[,] board)
        {
            if ((Color == Color.White && x == 7) || (Color == Color.Black && x == 0))
            {
                board[x, y] = new Queen(this.Color);
            }
        }

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board, Color ToMove, bool ignoreCheck)
        {
            if ((ToMove == Color.White && this.Color == Color.Black) || (ToMove == Color.Black && this.Color == Color.White))
            {
                return false;
            }

            if (!ignoreCheck)
            {
                Board b = new Board();

                if (board[fx, fy] != null && board[fx, fy].Color == Color.White)
                {
                    if (b.IsWhiteKingInCheck(fx, fy, sx, sy, board))
                    {
                        return false;
                    }
                }
                else if (board[fx, fy] != null && board[fx, fy].Color == Color.Black)
                {
                    if (b.IsBlackKingInCheck(fx, fy, sx, sy, board))
                    {
                        return false;
                    }
                }
            }

            if (Color == Color.White)
            {
                //Tohle zkontroluje, zda lze chytit figurku
                if ((fx == sx - 1 && (fy == sy - 1 || fy == sy + 1)) && board[sx, sy] != null && board[sx, sy].Color != Color.White)
                {
                    return true;
                }


                if (WasAlreadyMoved == false)
                {
                    if (fy == sy && (fx == sx - 1 || fx == sx - 2) && board[sx, sy] == null)
                    {
                        WasAlreadyMoved = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (fy == sy && fx == sx - 1 && board[sx, sy] == null)
                    {
                        WasAlreadyMoved = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                //Tohle zkontroluje, zda lze chytit figurku
                if ((fx == sx + 1 && (fy == sy - 1 || fy == sy + 1)) && board[sx, sy] != null && board[sx, sy].Color != Color.Black)
                {
                    return true;
                }

                if (WasAlreadyMoved == false)
                {
                    if (fy == sy && (fx == sx + 1 || fx == sx + 2) && board[sx, sy] == null)
                    {
                        WasAlreadyMoved = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (fy == sy && fx == sx + 1 && board[sx, sy] == null)
                    {
                        WasAlreadyMoved = true;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}