using System;
using System.Collections.Generic;
using Chess.Board;
using Chess.Pieces;

namespace Chess.Game
{
    public class ChessGame
    {
        public Chessboard Chessboard { get; private set; }
        public int Turn { get; private set; }
        public Color ActualPlayer { get; private set; }
        public bool HasEnded { get; private set; }
        private HashSet<Piece> _pieces = new HashSet<Piece>();
        private HashSet<Piece> _capturedPieces = new HashSet<Piece>();


        public ChessGame()
        {
            Chessboard = new Chessboard(8, 8);
            Turn = 1;
            ActualPlayer = Color.White;
            HasEnded = false;
            PutPieces();

            _pieces = new HashSet<Piece>();
            _capturedPieces = new HashSet<Piece>();
        }

        public void MovePiece(Position origin, Position destiny)
        {
            Piece p = Chessboard.RemovePiece(origin);
            p.IncrementMovementsPerformed();
            Piece capturedPiece = Chessboard.RemovePiece(destiny);
            Chessboard.PutPiece(p, destiny);

            if (capturedPiece != null)
                _capturedPieces.Add(capturedPiece);

        }

        public void MakeAPlay(Position origin, Position destiny)
        {
            MovePiece(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidityDestinyPosition(Position origin, Position destiny)
        {
            if (!Chessboard.Piece(origin).CanMoveTo(destiny))
                throw new ChessboardException("Invalid destiny position");
        }

        public void ChangePlayer()
        {
            if (ActualPlayer == Color.White)
                ActualPlayer = Color.Black;
            else
                ActualPlayer = Color.White;
        }

        public void ValidityOriginPosition(Position origin)
        {
            if (Chessboard.Piece(origin) == null)
                throw new ChessboardException("There is no piece in the selected position!");

            if (Chessboard.Piece(origin).Color != ActualPlayer)
                throw new ChessboardException("The selected piece is not yours!");


            if (!Chessboard.Piece(origin).HasPossibleMoves())
                throw new ChessboardException("The selected piece has no possible moves!");
        }

        public void PutNewPiece(char collum, int row, Piece piece)
        {
            Chessboard.PutPiece(piece, new ChessPosition(collum, row).ToPosition());
            _pieces.Add(piece);
        }

        public HashSet<Piece> CapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in _capturedPieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            return aux;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in _pieces)
            {
                if (x.Color == color)
                    aux.Add(x);
            }
            aux.ExceptWith(CapturedPieces(color));

            return aux;
        }

        private void PutPieces()
        {
            PutNewPiece('c', 1, new Tower(Chessboard, Color.White));
            PutNewPiece('b', 1, new Tower(Chessboard, Color.White));
            PutNewPiece('c', 8, new Tower(Chessboard, Color.Black));
            PutNewPiece('e', 8, new Tower(Chessboard, Color.Black));
            PutNewPiece('b', 8, new Tower(Chessboard, Color.Black));
        }
    }
}