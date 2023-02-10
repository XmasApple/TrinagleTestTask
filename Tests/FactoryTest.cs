using TrinagleTestTask;
using TrinagleTestTask.Exceptions;
using TrinagleTestTask.Shapes;

namespace Tests;

public class FactoryTest
{
    [Test]
    public void Creation()
    {
        {
            var circle = ShapeFactory.Instance.GetShape("Circle", 5);
            Assert.That(circle, Is.TypeOf<Circle>());
            Assert.That(circle.GetArea(), Is.EqualTo(25 * Math.PI));
        }
        {
            var triangle = ShapeFactory.Instance.GetShape("Triangle", 3, 4, 5);
            Assert.That(triangle, Is.TypeOf<Triangle>());
            Assert.That(triangle.GetArea(), Is.EqualTo(6));
        }
    }

    [Test]
    public void CreationWithWrongShapeName()
    {
        Assert.Throws<ShapeNotFoundException>(() => ShapeFactory.Instance.GetShape("WrongShapeName", 1, 2, 3));
    }
}