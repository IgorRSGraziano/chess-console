namespace Chess.Board
{
    public class Position
    {
        public int Row { get; set; }
        public int Collum { get; set; }

        public Position(int row, int collum)
        {
            Row = row;
            Collum = collum;
        }

        public void SetValues(int row, int collum)
        {
            Row = row;
            Collum = collum;
        }

        public override string ToString()
        {
            return $"{Row}, {Collum}";
        }
    }
}