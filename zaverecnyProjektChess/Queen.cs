namespace zaverecnyProjektChess
{
    internal class Queen : ChessPiece
    {
        private Color _color;

        public Queen(Color color)
        {
            _color = color;
        }

        public override int Value { get => 9; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Queen; set => throw new NotImplementedException(); }
        public override Color Color => _color;

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {

            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;

        }


        public override ChessPiece Clone()
        {
            Queen cloned = new Queen(this.Color);
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

            ChessPiece destinationPiece = board[sx, sy];
            if (destinationPiece != null && destinationPiece.Color == this.Color)
                return false;

            if (fx == sx && fy != sy)
            {
                int step = sy > fy ? 1 : -1;

                for (int y = fy + step; y != sy; y += step)
                {
                    if (board[fx, y] != null)
                    {
                        return false;
                    }
                }
                return true;
            }

            if (fy == sy && fx != sx)
            {
                int step = sx > fx ? 1 : -1;
                for (int x = fx + step; x != sx; x += step)
                {
                    if (board[x, fy] != null)
                        return false;
                }
                return true;
            }

            if (Math.Abs(fx - sx) == Math.Abs(fy - sy) && fx != sx)
            {
                int stepX = sx > fx ? 1 : -1;
                int stepY = sy > fy ? 1 : -1;
                int x = fx + stepX;
                int y = fy + stepY;

                while (x != sx && y != sy)
                {
                    if (board[x, y] != null)
                    {
                        return false;
                    }

                    x += stepX;
                    y += stepY;
                }

                return true;
            }

            return false;
        }
    }
}