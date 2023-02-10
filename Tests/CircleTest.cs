using TrinagleTestTask.Exceptions;
using TrinagleTestTask.Shapes;

namespace Tests;

public class CircleTest
{
    [Test]
    public void Creation()
    {
        {
            var circle = new Circle(5);
            Assert.That(circle.Radius, Is.EqualTo(5));
        }
        {
            var parameters = new double[] { 5 };
            var circle = new Circle(parameters);
            Assert.That(circle.Radius, Is.EqualTo(5));
        }
    }

    [Test]
    public void CreationWithWrongParameters()
    {
        Assert.Throws<ShapeCreationException>(() => new Circle(1, 2));

        Assert.Throws<ShapeCreationException>(() => new Circle());
    }

    [Test]
    public void Area()
    {
        {
            var circle = new Circle(5);
            Assert.That(circle.GetArea(), Is.EqualTo(25 * Math.PI));
        }
    }

    [Test]
    public void AreaWithWrongParameters()
    {
        Assert.Throws<ShapeCreationException>(() => new Circle(-1));
    }
}