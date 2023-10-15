namespace TestCaseRestApi.CustomException
{
    public class HoleRepositoryException : Exception
    {
        public HoleRepositoryException()
        {
        }

        public HoleRepositoryException(string message)
            : base(message)
        {
        }

        public HoleRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
