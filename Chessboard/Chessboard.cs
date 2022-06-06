namespace Chess.Board
{
    public class Chessboard
    {
        public int Rows { get; set; }
        public int Collums { get; set; }
        private Piece[,] Pieces;

        public Chessboard(int rows, int collums)
        {
            Rows = rows;
            Collums = collums;
            Pieces = new Piece[rows, collums];
        }

        public Piece Piece(int row, int collum)
        {
            return Pieces[row, collum];
        }
    }
}