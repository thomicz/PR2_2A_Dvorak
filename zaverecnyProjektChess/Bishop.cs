namespace zaverecnyProjektChess
{
    internal class Bishop : ChessPiece
    {
        private Color _color;

        public Bishop(Color color)
        {
            _color = color;
        }
        public override ChessPieceName Name { get => ChessPieceName.Bishop; }
        public override Color Color => _color;

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;

        }
        public override ChessPiece Clone()
        {
            Bishop cloned = new Bishop(this.Color);
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

            if (Math.Abs(fx - sx) == Math.Abs(fy - sy) && fx != sx)
            {
                ChessPiece destination = board[sx, sy];
                ChessPiece current = board[fx, fy];

                int dx = (sx - fx) > 0 ? 1 : -1;
                int dy = (sy - fy) > 0 ? 1 : -1;

                int x = fx + dx;
                int y = fy + dy;

                while (x != sx && y != sy)
                {
                    if (board[x, y] != null)
                    {
                        return false;
                    }

                    x += dx;
                    y += dy;
                }

                if (destination != null && destination.Color == current.Color)
                    return false;

                return true;
            }

            return false;
        }
    }
}