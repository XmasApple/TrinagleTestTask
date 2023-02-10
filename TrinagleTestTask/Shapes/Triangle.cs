using TrinagleTestTask.Exceptions;

namespace TrinagleTestTask.Shapes;

/// <summary>
/// Triangle shape with IShape interface implementation
/// </summary>
public class Triangle : IShape
{
    /// <summary>
    /// A side of triangle
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// B side of triangle
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// C side of triangle
    /// </summary>
    public double SideC { get; }

    /// <summary>
    /// Constructor for triangle with given sides A, B and C
    /// </summary>
    /// <param name="sideA">A side</param>
    /// <param name="sideB">B side</param>
    /// <param name="sideC">C side</param>
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
        CheckIfTriangle();
    }

    /// <summary>
    /// Constructor for triangle with sides A, B and C from parameters array
    /// </summary>
    /// <param name="parameters"></param>
    /// <exception cref="ShapeCreationException">Throws if can't create triangle with given parameters</exception>
    public Triangle(params double[] parameters)
    {
        if (parameters.Length != 3)
            throw new ShapeCreationException($"Triangle must have 3 parameters, but {parameters.Length} were provided");

        SideA = parameters[0];
        SideB = parameters[1];
        SideC = parameters[2];
        CheckIfTriangle();
    }

    /// <summary>
    /// Implementation of IShape interface method for getting area of triangle
    /// </summary>
    /// <returns>The area of triangle</returns>
    public double GetArea() => IsRightTriangle() ? RightTriangleFormula() : HeronFormula();

    /// <summary>
    /// Method for getting area of right triangle using formula A * B / 2
    /// </summary>
    /// <returns>The area of right triangle</returns>
    /// <exception cref="Exception">Throws if triangle is not right, never happens</exception>
    private double RightTriangleFormula()
    {
        var maxSide = Math.Max(SideA, Math.Max(SideB, SideC));
        const double tolerance = 1e-6;
        return maxSide switch
        {
            _ when Math.Abs(maxSide - SideA) < tolerance => SideB * SideC / 2,
            _ when Math.Abs(maxSide - SideB) < tolerance => SideA * SideC / 2,
            _ when Math.Abs(maxSide - SideC) < tolerance => SideA * SideB / 2,
            _ => throw new Exception()
        };
    }

    /// <summary>
    /// Method for getting area of triangle using Heron's formula
    /// </summary>
    /// <returns>The area of triangle</returns>
    private double HeronFormula()
    {
        var p = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
    }

    /// <summary>
    /// Checks if triangle can be created with given sides
    /// </summary>
    /// <exception cref="ShapeCreationException">Throws if triangle can't be created with given sides</exception>
    private void CheckIfTriangle()
    {
        var isTriangle = SideA + SideB > SideC && SideA + SideC > SideB && SideB + SideC > SideA;
        if (!isTriangle)
            throw new ShapeCreationException("Provided sides do not form a triangle");
    }

    /// <summary>
    /// Checks if triangle is right
    /// </summary>
    /// <returns>True if triangle is right, false otherwise</returns>
    private bool IsRightTriangle()
    {
        const double tolerance = 1e-6;
        return Math.Abs(Math.Pow(SideA, 2) + Math.Pow(SideB, 2) - Math.Pow(SideC, 2)) < tolerance ||
               Math.Abs(Math.Pow(SideA, 2) + Math.Pow(SideC, 2) - Math.Pow(SideB, 2)) < tolerance ||
               Math.Abs(Math.Pow(SideB, 2) + Math.Pow(SideC, 2) - Math.Pow(SideA, 2)) < tolerance;
    }
}