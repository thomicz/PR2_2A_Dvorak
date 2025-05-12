﻿namespace zaverecnyProjektChess
{
    internal class King : ChessPiece
    {
        private Color _color;
        private int _x;
        private int _y;

        public King(Color color, int x, int y)
        {
            _color = color;
            _x = x;
            _y = y;
        }

        public override int Value { get => 0; set => throw new NotImplementedException(); }
        public override ChessPieceName Name { get => ChessPieceName.King; set => throw new NotImplementedException(); }
        public override Color Color => _color;
        public override int X => _x;
        public override int Y => _y;

        public override bool IsMoveLegal(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            throw new NotImplementedException();
        }

        public override bool Move(int fx, int fy, int sx, int sy, ChessPiece[,] board)
        {
            ChessPiece destinationPiece = board[sx, sy];
            if (destinationPiece != null && destinationPiece.Color == this.Color)
                return false;

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
