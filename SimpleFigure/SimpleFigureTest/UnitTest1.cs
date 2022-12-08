using System.Numerics;
using SimpleFigure;

namespace SimpleFigureTest
{
    [TestClass]
    public class UnitTest1
    {
        /** которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
     * Дополнительно к работоспособности оценим:
     * - Юнит-тесты
     * - Легкость добавления других фигур
     * - Вычисление площади фигуры без знания типа фигуры в compile-time
     * - Проверку на то, является ли треугольник прямоугольным*/

        // Тест на правильность вычисления площади круга
        [TestMethod]
        public void TestСalculateCircleArea()
        {
            // Радиус круга
            double radius = 5;
            // Площадь круга
            double s = Math.PI * (Math.Pow(radius, 2));

            Circle circle = new(radius);

            if (circle.СalculateSquare())
                Assert.AreEqual(s, circle.Square);
        }

        // Тест на правильность вычисления площади треугольника
        [TestMethod]
        public void TestСalculateTriangleArea()
        {
            // Стороны треугольника
            double a = 5;
            double b = 6;
            double c = 2.2;
            // Площадь треугольника
            double s = 5.28;

            Triangle triangle = new(a, b, c);

            if (triangle.СalculateSquare())
                Assert.AreEqual(s, Math.Round(triangle.Square, 2));
        }

        // Тест проверки на то, является ли треугольник прямоугольным.
        [TestMethod]
        public void TestCheckRightTriangle()
        {
            double a = 6;
            double b = 8;
            double c = 10;

            Triangle circle = new(a, b, c);
            bool? result = circle.CheckRightTriangle();
            // Треугольник прямоугольный.
            Assert.AreEqual(true, result);

            a = 6;
            b = 8;
            c = 11;
            circle = new(a, b, c);
            result = circle.CheckRightTriangle();
            // Треугольник непрямоугольный.
            Assert.AreEqual(false, result);
        }

        // Тест на вычисление площади фигуры без знания типа фигуры в compile-time.
        [TestMethod]
        /*public void TestСalculateFigureArea()
        {
            _ = new StaticFigure();
            double expected = Math.PI * (StaticFigure.Radius)
            double Square = StaticFigure.Figure.Square;


        }*/
    }
}