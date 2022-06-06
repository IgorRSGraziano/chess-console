namespace Chess.Board
{
    public class ChessPosition
    {
        public char Collum { get; set; }
        public int Row { get; set; }

        public ChessPosition(char collum, int row)
        {
            Collum = collum;
            Row = row;
        }

        public Position ToPosition()
        {
            return new Position(8 - Row, Collum - 'a');
        }

        public override string ToString()
        {
            return $"{Collum}{Row}";
        }
    }
}