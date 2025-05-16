namespace zaverecnyProjektChess
{
    abstract class ChessPiece
    {
        public abstract int Value { get; set; }
        public abstract ChessPieceName Name { get; set; }
        public abstract Color Color { get; }
        public abstract int X { get; }
        public abstract int Y { get; }
        public abstract bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board);
        public abstract bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board, bool ignoreCheck = false);
        public abstract ChessPiece Clone();

    }
}
