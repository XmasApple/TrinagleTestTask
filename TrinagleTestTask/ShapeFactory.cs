using TrinagleTestTask.Exceptions;
using TrinagleTestTask.Shapes;

namespace TrinagleTestTask;

/// <summary>
/// Factory for shapes creation that can create shapes by name
/// </summary>
public class ShapeFactory
{
    /// <summary>
    /// Singleton instance of the factory
    /// </summary>
    public static ShapeFactory Instance { get; } = new ShapeFactory();

    /// <summary>
    /// Method for getting shape by name with given parameters
    /// </summary>
    /// <param name="shapeName">name of shape to create</param>
    /// <param name="parameters">can represent sides, radius or other given parameters of shape</param>
    /// <returns></returns>
    /// <exception cref="ShapeNotFoundException">Throws if can't create shape with given shapeName</exception>
    public IShape GetShape(string shapeName, params double[] parameters)
    {
        return shapeName switch
        {
            "Triangle" => new Triangle(parameters),
            "Circle" => new Circle(parameters),
            _ => throw new ShapeNotFoundException($"Shape with name {shapeName} was not found")
        };
    }
}