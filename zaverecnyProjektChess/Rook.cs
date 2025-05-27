namespace zaverecnyProjektChess
{
    internal class Rook : ChessPiece
    {
        private Color _color;

        public Rook(Color color)
        {
            _color = color;
        }

        public override ChessPieceName Name { get => ChessPieceName.Rook; }
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
            Rook cloned = new Rook(this.Color);
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

            if (!((fx == sx && fy != sy) || (fy == sy && fx != sx)))
            {
                return false;
            }

            if (board[sx, sy] != null && board[sx, sy].Color == this.Color)
            {
                return false;
            }

            if (fx == sx)
            {
                int step = sy > fy ? 1 : -1;

                for (int y = fy + step; y != sy; y += step)
                {
                    if (board[fx, y] != null)
                    {
                        return false;
                    }
                }
            }
            else if (fy == sy)
            {
                int step = sx > fx ? 1 : -1;
                for (int x = fx + step; x != sx; x += step)
                {
                    if (board[x, fy] != null)
                    {
                        return false;
                    }
                }
            }

            return true;

        }
    }
}