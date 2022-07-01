using System;
using System.Collections.Generic;
using Chess.Board;
using Chess.Game;

namespace Chess.Board
{
    public class Screen
    {
        public static void PrintChessboard(Chessboard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Collums; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("* A B C D E F G H");
        }

        public static void PrintMatch(ChessGame match)
        {
            PrintChessboard(match.Chessboard);
            Console.WriteLine();
            printCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn);
            Console.WriteLine("Player: " + match.ActualPlayer);
            Console.WriteLine();
        }

        public static void printCapturedPieces(ChessGame match)
        {
            Console.WriteLine("Captured pieces: ");
            Console.Write("White: ");
            PrintGroup(match.CapturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black: ");
            PrintGroup(match.CapturedPieces(Color.Black));
            Console.WriteLine();
        }

        public static void PrintGroup(HashSet<Piece> group)
        {
            Console.Write("[");
            foreach (Piece p in group)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }


        public static void PrintChessboard(Chessboard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.Collums; j++)
                {
                    if (possiblePositions[i, j] == true)
                        Console.BackgroundColor = changedBackground;
                    else
                        Console.BackgroundColor = originalBackground;

                    PrintPiece(board.Piece(i, j));
                }

                Console.BackgroundColor = originalBackground;
                Console.WriteLine("");
            }
            Console.WriteLine("* A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("-");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                else if (piece.Color == Color.Black)
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
            }
            Console.Write(" ");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();
            char collum = s[0];
            int row = int.Parse($"{s[1]}");

            return new ChessPosition(collum, row);
        }
    }
}