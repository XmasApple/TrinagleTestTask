using TrinagleTestTask.Exceptions;
using TrinagleTestTask.Shapes;

namespace Tests;

public class TriangleTest
{
    [Test]
    public void Creation()
    {
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.Multiple(() =>
            {
                Assert.That(triangle.SideA, Is.EqualTo(3));
                Assert.That(triangle.SideB, Is.EqualTo(4));
                Assert.That(triangle.SideC, Is.EqualTo(5));
            });
        }
        {
            var sides = new double[] { 3, 4, 5 };
            var triangle = new Triangle(sides);
            Assert.Multiple(() =>
            {
                Assert.That(triangle.SideA, Is.EqualTo(3));
                Assert.That(triangle.SideB, Is.EqualTo(4));
                Assert.That(triangle.SideC, Is.EqualTo(5));
            });
        }
    }

    [Test]
    public void CreationWithWrongParameters()
    {
        
        Assert.Throws<ShapeCreationException>(() => new Triangle(1, 2, 3, 4));

        Assert.Throws<ShapeCreationException>(() => new Triangle(1, 2, 3));
    }

    [Test]
    public void Area()
    {
        {
            var triangleA = new Triangle(5, 3, 4);
            Assert.That(triangleA.GetArea(), Is.EqualTo(6));
            var triangleB = new Triangle(4, 5, 3);
            Assert.That(triangleB.GetArea(), Is.EqualTo(6));
            var triangleC = new Triangle(3, 4, 5);
            Assert.That(triangleC.GetArea(), Is.EqualTo(6));
        }
        {
            var triangle = new Triangle(3, 4, 6);
            Assert.That(triangle.GetArea(), Is.EqualTo(5.332682251925386));
        }
    }
}