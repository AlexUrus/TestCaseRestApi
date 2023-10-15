namespace TestCaseRestApi.CustomException
{
    public class DrillBlockPointRepositoryException : Exception
    {
        public DrillBlockPointRepositoryException()
        {
        }

        public DrillBlockPointRepositoryException(string message)
            : base(message)
        {
        }

        public DrillBlockPointRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
