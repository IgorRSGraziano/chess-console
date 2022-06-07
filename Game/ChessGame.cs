using System;
using Chess.Board;
using Chess.Pieces;

namespace Chess.Game
{
    public class ChessGame
    {
        public Chessboard Chessboard { get; private set; }
        private int _turn;
        private Color _actualPlayer;
        public bool HasEnded { get; private set; }


        public ChessGame()
        {
            Chessboard = new Chessboard(8, 8);
            _turn = 1;
            _actualPlayer = Color.White;
            HasEnded = false;
            PutPieces();
        }

        public void MovePiece(Position origin, Position destiny)
        {
            Piece p = Chessboard.RemovePiece(origin);
            p.IncrementMovementsPerformed();
            Piece capturedPiece = Chessboard.RemovePiece(destiny);
            Chessboard.PutPiece(p, destiny);

        }

        private void PutPieces()
        {
            Chessboard.PutPiece(new Tower(Chessboard, Color.White), new ChessPosition('c', 1).ToPosition());
            Chessboard.PutPiece(new Tower(Chessboard, Color.White), new ChessPosition('b', 1).ToPosition());

            Chessboard.PutPiece(new Tower(Chessboard, Color.Black), new ChessPosition('c', 8).ToPosition());
            Chessboard.PutPiece(new King(Chessboard, Color.Black), new ChessPosition('e', 5).ToPosition());
            Chessboard.PutPiece(new Tower(Chessboard, Color.Black), new ChessPosition('b', 8).ToPosition());
        }
    }
}