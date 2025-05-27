namespace zaverecnyProjektChess
{
    internal class King : ChessPiece
    {
        private Color _color;

        public King(Color color)
        {
            _color = color;
        }

        public override ChessPieceName Name { get => ChessPieceName.King; }
        public override Color Color => _color;
        public bool WasAlreadyMoved = false;


        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;
        }

        public override ChessPiece Clone()
        {
            King cloned = new King(this.Color);
            return cloned;
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

            if (board[sx, sy] != null && board[sx, sy].Color == this.Color)
            {
                return false;
            }

            if (
                (fx == sx + 1 && fy == sy + 1) ||
                (fx == sx + 1 && fy == sy) ||
                (fx == sx + 1 && fy == sy - 1) ||
                (fx == sx && fy == sy + 1) ||
                (fx == sx && fy == sy - 1) ||
                (fx == sx - 1 && fy == sy + 1) ||
                (fx == sx - 1 && fy == sy) ||
                (fx == sx - 1 && fy == sy - 1)
            )
                return true;

            return false;
        }
    }
}