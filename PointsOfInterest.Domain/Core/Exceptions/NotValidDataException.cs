namespace PointsOfInterest.Domain.Core.Exceptions
{
    public sealed class NotValidDataException : Exception
    {
        public NotValidDataException(string message) : base(message) { }
    }
}
