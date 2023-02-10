using TrinagleTestTask.Exceptions;

namespace TrinagleTestTask.Shapes;

/// <summary>
/// Circle shape with IShape interface implementation
/// </summary>
public class Circle : IShape
{
    /// <summary>
    /// Radius of circle
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Constructor for circle with given radius
    /// </summary>
    /// <param name="radius"></param>
    public Circle(double radius)
    {
        Radius = radius;
        CheckIfCircle();
    }

    /// <summary>
    /// Constructor for circle with radius from parameters array
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="ShapeCreationException">Throws if can't create circle with given parameters</exception>
    public Circle(params double[] parameters)
    {
        if (parameters.Length != 1)
            throw new ShapeCreationException($"Circle must have 1 parameter, but {parameters.Length} were provided");
        Radius = parameters[0];
        CheckIfCircle();
    }

    /// <summary>
    /// Implementation of IShape interface method for getting area of circle
    /// </summary>
    /// <returns></returns>
    public double GetArea() => Math.PI * Radius * Radius;
    
    private void CheckIfCircle()
    {
        if (Radius <= 0)
            throw new ShapeCreationException("Radius must be positive");
    }
}