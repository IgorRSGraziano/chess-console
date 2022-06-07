using System;
using Chess.Board;

namespace Chess.Rules
{
    public class Rules
    {
      private Chessboard _chessboard;
      private int _turn;
      private Color _actualPlayer; 

      public Rules()
      {
          _chessboard = new Chessboard(8, 8);
          _turn = 1;
          _actualPlayer = Color.White;
      }

      public void MovePiece(Position origin, Position destiny)
      {
          Piece p = _chessboard.RemovePiece(origin);
          p.IncrementMovementsPerformed();
          Piece capturedPiece = _chessboard.RemovePiece(destiny);
          _chessboard.PutPiece(p, destiny);

      }
    }
}