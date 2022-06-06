using System;
using Chess.Board;

namespace Chess.Board
{
    public class Screen
    {
        public static void PrintChessboard(Chessboard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Collums; j++)
                {
                    Console.Write(board.Piece(i, j) == null ? "- " : board.Piece(i, j) + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}