using SimpleFigure;

namespace SimpleFigureTest
{
    [TestClass]
    public class FiguresTests
    {
        /// <summary>
        /// Тест на отрицательность входных данных.
        /// </summary>
        [TestMethod]
        public void TestNegativeArguments()
        {
            // круг
            double radius = -5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(radius));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().СalculateSquare(radius));

            // треугольник
            double a = -5;
            double b = 5;
            double c = 5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().СalculateSquare(a, b, c));
            a = 5;
            b = -5;
            c = 5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().СalculateSquare(a, b, c));
            a = 5;
            b = 5;
            c = -5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().СalculateSquare(a, b, c));
        }

        /// <summary>
        /// Тест на правильность вычисления площади круга.
        /// </summary>
        [TestMethod]
        public void TestСalculateCircleArea()
        {
            double radius = 5;
            double expected = Math.PI * (Math.Pow(radius, 2));

            // Площадь круга.
            Circle circle = new(radius);
            circle.СalculateSquare();
            Assert.AreEqual(expected, circle.Square);

            Figure figure = new Figure();
            figure.СalculateSquare(radius);
            Assert.AreEqual(expected, figure.Square);
        }

        /// <summary>
        /// Тест на правильность вычисления площади треугольника.
        /// </summary>
        [TestMethod]
        public void TestСalculateTriangleArea()
        {
            double a = 5;
            double b = 6;
            double c = 2.2;
            double s = 5.28;

            Triangle triangle = new(a, b, c);
            triangle.СalculateSquare();
            Assert.AreEqual(s, Math.Round(triangle.Square, 2));

            Figure figure = new Figure();
            figure.СalculateSquare(a, b, c);
            Assert.AreEqual(s, Math.Round(figure.Square, 2));
        }

        /// <summary>
        /// Тест проверки на то, является ли треугольник прямоугольным.
        /// </summary>
        [TestMethod]
        public void TestCheckRightTriangle()
        {
            double a = 6;
            double b = 8;
            double c = 10;

            // Треугольник прямоугольный.
            Triangle circle = new(a, b, c);
            bool? result = circle.CheckRightTriangle();
            Assert.AreEqual(true, result);

            a = 6;
            b = 8;
            c = 11;
            circle = new(a, b, c);
            result = circle.CheckRightTriangle();
            // Треугольник непрямоугольный.
            Assert.AreEqual(false, result);
        }
    }
}