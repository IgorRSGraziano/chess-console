using Chess.Pieces;

using Chess.Board;

namespace Chess
{
    public class Program
    {
        public static void Main()
        {
            Chessboard board = new Chessboard(8, 8);

            board.PutPiece(new King(board, Color.Black), new Position(1, 1));
            board.PutPiece(new King(board, Color.White), new Position(3, 1));
            board.PutPiece(new Tower(board, Color.Black), new Position(2, 3));


            Screen.PrintChessboard(board);
        }
    }
}