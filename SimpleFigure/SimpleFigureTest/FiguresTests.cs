using SimpleFigure;

namespace SimpleFigureTest
{
    [TestClass]
    public class FiguresTests
    {
        /// <summary>
        /// ���� �� ��������������� ������� ������.
        /// </summary>
        [TestMethod]
        public void TestNegativeArguments()
        {
            // ����
            double radius = -5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(radius));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().�alculateSquare(radius));

            // �����������
            double a = -5;
            double b = 5;
            double c = 5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().�alculateSquare(a, b, c));
            a = 5;
            b = -5;
            c = 5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().�alculateSquare(a, b, c));
            a = 5;
            b = 5;
            c = -5;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(a, b, c));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Figure().�alculateSquare(a, b, c));
        }

        /// <summary>
        /// ���� �� ������������ ���������� ������� �����.
        /// </summary>
        [TestMethod]
        public void Test�alculateCircleArea()
        {
            double radius = 5;
            double expected = Math.PI * (Math.Pow(radius, 2));

            // ������� �����.
            Circle circle = new(radius);
            circle.�alculateSquare();
            Assert.AreEqual(expected, circle.Square);

            Figure figure = new Figure();
            figure.�alculateSquare(radius);
            Assert.AreEqual(expected, figure.Square);
        }

        /// <summary>
        /// ���� �� ������������ ���������� ������� ������������.
        /// </summary>
        [TestMethod]
        public void Test�alculateTriangleArea()
        {
            double a = 5;
            double b = 6;
            double c = 2.2;
            double s = 5.28;

            Triangle triangle = new(a, b, c);
            triangle.�alculateSquare();
            Assert.AreEqual(s, Math.Round(triangle.Square, 2));

            Figure figure = new Figure();
            figure.�alculateSquare(a, b, c);
            Assert.AreEqual(s, Math.Round(figure.Square, 2));
        }

        /// <summary>
        /// ���� �������� �� ��, �������� �� ����������� �������������.
        /// </summary>
        [TestMethod]
        public void TestCheckRightTriangle()
        {
            double a = 6;
            double b = 8;
            double c = 10;

            // ����������� �������������.
            Triangle circle = new(a, b, c);
            bool? result = circle.CheckRightTriangle();
            Assert.AreEqual(true, result);

            a = 6;
            b = 8;
            c = 11;
            circle = new(a, b, c);
            result = circle.CheckRightTriangle();
            // ����������� ���������������.
            Assert.AreEqual(false, result);
        }
    }
}