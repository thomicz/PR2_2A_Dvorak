namespace zaverecnyProjektChess
{
    internal class Knight : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public Knight(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public override int Value { get => 3; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Knight; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public override int X => _x;
        public override int Y => _y;

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {

            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;

        }
        public override ChessPiece Clone()
        {
            Knight cloned = new Knight(this.Color, this.X, this.Y);
            return cloned;
        }
        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board, bool ignoreCheck)
        {
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

            // Kontrola, že neútočí na vlastní figurku
            ChessPiece destinationPiece = board[sx, sy];
            if (destinationPiece != null && destinationPiece.Color == this.Color)
            {
                return false;
            }

            if (
               (fx == sx + 2 && fy == sy + 1) ||
               (fx == sx + 2 && fy == sy - 1) ||
               (fx == sx - 2 && fy == sy + 1) ||
               (fx == sx - 2 && fy == sy - 1) ||
               (fx == sx + 1 && fy == sy + 2) ||
               (fx == sx + 1 && fy == sy - 2) ||
               (fx == sx - 1 && fy == sy + 2) ||
               (fx == sx - 1 && fy == sy - 2)
               )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

