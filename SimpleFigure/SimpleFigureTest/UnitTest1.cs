using System.Numerics;
using SimpleFigure;

namespace SimpleFigureTest
{
    [TestClass]
    public class UnitTest1
    {
        /** ������� ����� ��������� ������� ����� �� ������� � ������������ �� ���� ��������.
     * ������������� � ����������������� ������:
     * - ����-�����
     * - �������� ���������� ������ �����
     * - ���������� ������� ������ ��� ������ ���� ������ � compile-time
     * - �������� �� ��, �������� �� ����������� �������������*/

        // ���� �� ������������ ���������� ������� �����
        [TestMethod]
        public void Test�alculateCircleArea()
        {
            // ������ �����
            double radius = 5;
            // ������� �����
            double s = Math.PI * (Math.Pow(radius, 2));

            Circle circle = new(radius);

            if (circle.�alculateSquare())
                Assert.AreEqual(s, circle.Square);
        }

        // ���� �� ������������ ���������� ������� ������������
        [TestMethod]
        public void Test�alculateTriangleArea()
        {
            // ������� ������������
            double a = 5;
            double b = 6;
            double c = 2.2;
            // ������� ������������
            double s = 5.28;

            Triangle triangle = new(a, b, c);

            if (triangle.�alculateSquare())
                Assert.AreEqual(s, Math.Round(triangle.Square, 2));
        }

        // ���� �������� �� ��, �������� �� ����������� �������������.
        [TestMethod]
        public void TestCheckRightTriangle()
        {
            double a = 6;
            double b = 8;
            double c = 10;

            Triangle circle = new(a, b, c);
            bool? result = circle.CheckRightTriangle();
            // ����������� �������������.
            Assert.AreEqual(true, result);

            a = 6;
            b = 8;
            c = 11;
            circle = new(a, b, c);
            result = circle.CheckRightTriangle();
            // ����������� ���������������.
            Assert.AreEqual(false, result);
        }

        // ���� �� ���������� ������� ������ ��� ������ ���� ������ � compile-time.
        [TestMethod]
        /*public void Test�alculateFigureArea()
        {
            _ = new StaticFigure();
            double expected = Math.PI * (StaticFigure.Radius)
            double Square = StaticFigure.Figure.Square;


        }*/
    }
}