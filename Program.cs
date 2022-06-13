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
                try
                {
                    Console.Clear();
                    Screen.PrintChessboard(match.Chessboard);

                    Console.WriteLine();
                    Console.WriteLine("Turn: " + match.Turn);
                    Console.WriteLine("Player: " + match.ActualPlayer);
                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    match.ValidityOriginPosition(origin);

                    bool[,] possiblePositions = match.Chessboard.Piece(origin).PossibleMoves();

                    Console.Clear();
                    Screen.PrintChessboard(match.Chessboard, possiblePositions);

                    Console.WriteLine();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.MakeAPlay(origin, destiny);
                }
                catch (ChessboardException e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}