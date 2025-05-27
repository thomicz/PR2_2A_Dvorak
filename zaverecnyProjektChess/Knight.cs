namespace zaverecnyProjektChess
{
    internal class Knight : ChessPiece
    {
        private Color _color;

        public Knight(Color color)
        {
            _color = color;
        }

        public override ChessPieceName Name { get => ChessPieceName.Knight; }
        public override Color Color => _color;

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {

            board[sx, sy] = board[fx, fy];
            board[fx, fy] = null;

            return true;

        }
        public override ChessPiece Clone()
        {
            Knight cloned = new Knight(this.Color);
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
