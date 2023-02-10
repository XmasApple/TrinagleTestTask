namespace TrinagleTestTask.Exceptions;

/// <summary>
/// Should be thrown when error occurs while creating shape
/// </summary>
public class ShapeCreationException : Exception
{
    public ShapeCreationException(string message) : base(message)
    {
    }
}