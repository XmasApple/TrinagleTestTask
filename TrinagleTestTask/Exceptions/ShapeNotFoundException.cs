namespace TrinagleTestTask.Exceptions;

/// <summary>
/// Should be thrown when shape is not found
/// </summary>
public class ShapeNotFoundException : Exception
{
    public ShapeNotFoundException(string message) : base(message)
    {
    }
}