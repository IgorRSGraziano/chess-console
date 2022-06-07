using Chess.Pieces;
using Chess.Game;
using Chess.Board;

namespace Chess
{
    public class Program
    {
        public static void Main()
        {
            ChessGame match = new ChessGame();

            while (!match.HasEnded)
            {
                Console.Clear();
                Screen.PrintChessboard(match.Chessboard);

                Console.Write("Origin: ");
                Position origin = Screen.ReadChessPosition().ToPosition();

                Console.Write("Destiny: ");
                Position destiny = Screen.ReadChessPosition().ToPosition();

                match.MovePiece(origin, destiny);
            }
        }
    }
}