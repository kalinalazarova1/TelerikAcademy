namespace ComputersBuilder
{
    public interface ICpu
    {
        byte NumberOfCores { get; set; }

        string SquareNumber(int data);

        int RandomInRange(int min, int max);
    }
}
