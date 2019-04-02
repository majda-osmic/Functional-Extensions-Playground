namespace DefensiveProgramming.Option
{
    public interface IDataAccessSample
    {
        void WriteOnlyValidToConsole(int key);

        void WriteAlwaysToConsole(int key);

        string RetrieveData(int key);
    }
}