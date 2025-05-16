namespace zaverecnyProjektChess
{
    internal class Pawn : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public Pawn(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public override int Value { get => 1; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.Pawn; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public bool WasAlreadyMoved = false;
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
            Pawn cloned = new Pawn(this.Color, this.X, this.Y);
            cloned.WasAlreadyMoved = this.WasAlreadyMoved;
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