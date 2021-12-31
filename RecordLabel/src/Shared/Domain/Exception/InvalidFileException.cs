
namespace RecordLabel.src.Shared.Domain.Exception
{
    public class InvalidFileException : ValidationException
    {
        public InvalidFileException(string message) : base(message)
        {
        }

        public static InvalidFileException FromFormat()
        {
            return new InvalidFileException("Only Excel file format is allowed");
        }

        public static InvalidFileException FromEmpty()
        {
            return new InvalidFileException("Please choose Excel file");
        }
    }
}
