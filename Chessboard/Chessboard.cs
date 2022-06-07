namespace Chess.Board
{
    public class Chessboard
    {
        private Piece[,] Pieces;


        public int Rows { get; set; }
        public int Collums { get; set; }


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

        public Piece Piece(Position pos)
        {
            return Pieces[pos.Row, pos.Collum];
        }

        public bool IsPieceInThePosition(Position pos)
        {
            ValidatePosition(pos);
            return Piece(pos) != null;
        }

        public void PutPiece(Piece p, Position pos)
        {
            if (IsPieceInThePosition(pos))
                throw new ChessboardException("There is already a piece in that position!");

            Pieces[pos.Row, pos.Collum] = p;
            p.Position = pos;
        }

        public Piece RemovePiece(Position pos)
        {
            if(Piece(pos) == null)
            {
                return null;
            }
            Piece aux = Piece(pos);
            Pieces[pos.Row, pos.Collum] = null;
            return aux;
        }


        public bool IsValidPosition(Position pos)
        {
            if (pos.Row > 0 || pos.Row <= Rows || pos.Collum > 0 || pos.Collum <= Collums)
                return false;
            else
                return true;
        }

        public void ValidatePosition(Position pos)
        {
            if (IsValidPosition(pos))
                throw new ChessboardException("Invalid Position!");
        }
    }
}