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
            if (Color == Color.White)
            {
                if (WasAlreadyMoved == false)
                {
                    if (fy == sy && (fx == sx - 1 || fx == sx - 2))
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

                    if (fy == sy && fx == sx - 1)
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
                if (WasAlreadyMoved == false)
                {
                    if (fy == sy && (fx == sx + 1 || fx == sx + 2))
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

                    if (fy == sy && fx == sx + 1)
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
