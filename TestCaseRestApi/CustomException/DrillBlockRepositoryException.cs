namespace TestCaseRestApi.CustomException
{
    public class DrillBlockRepositoryException : Exception
    {
        public DrillBlockRepositoryException()
        {
        }

        public DrillBlockRepositoryException(string message)
            : base(message)
        {
        }

        public DrillBlockRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
