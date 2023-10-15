namespace TestCaseRestApi.CustomException
{
    public class HolePointRepositoryException : Exception
    {
        public HolePointRepositoryException()
        {
        }

        public HolePointRepositoryException(string message)
            : base(message)
        {
        }

        public HolePointRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
