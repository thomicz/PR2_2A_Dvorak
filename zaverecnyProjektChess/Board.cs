namespace zaverecnyProjektChess
{
    internal class Board
    {
        public ChessPiece[,] GameBoard { get; set; }

        public Board()
        {
            GameBoard = new ChessPiece[8, 8];
        }



        public void SetupBoard()
        {
            SetupWhite();
            SetupBlack();
        }

        public void SetupWhite()
        {
            GameBoard[0, 0] = new Rook(Color.White, 0, 0);
            GameBoard[0, 1] = new Knight(Color.White, 0, 1);
            GameBoard[0, 2] = new Bishop(Color.White, 0, 2);
            GameBoard[0, 3] = new King(Color.White, 0, 3);
            GameBoard[0, 4] = new Queen(Color.White, 0, 4);
            GameBoard[0, 5] = new Bishop(Color.White, 0, 5);
            GameBoard[0, 6] = new Knight(Color.White, 0, 6);
            GameBoard[0, 7] = new Rook(Color.White, 0, 7);

            for (int i = 0; i < 8; i++)
            {
                GameBoard[1, i] = new Pawn(Color.White, 1, i);
            }
        }

        public void SetupBlack()
        {
            GameBoard[7, 0] = new Rook(Color.Black, 7, 0);
            GameBoard[7, 1] = new Knight(Color.Black, 7, 1);
            GameBoard[7, 2] = new Bishop(Color.Black, 7, 2);
            GameBoard[7, 3] = new King(Color.Black, 7, 3);
            GameBoard[7, 4] = new Queen(Color.Black, 7, 4);
            GameBoard[7, 5] = new Bishop(Color.Black, 7, 5);
            GameBoard[7, 6] = new Knight(Color.Black, 7, 6);
            GameBoard[7, 7] = new Rook(Color.Black, 7, 7);

            for(int i = 0; i < 8; i++)
            {
                GameBoard[6, i] = new Pawn(Color.Black, 6, i);
            }
        }
    }
}
