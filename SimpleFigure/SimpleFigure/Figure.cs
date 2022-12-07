using System;

namespace SimpleFigure
{
    /*
     * Напишите на C# библиотеку для поставки внешним клиентам, 
     * которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам. 
     * Дополнительно к работоспособности оценим:
     * - Юнит-тесты
     * - Легкость добавления других фигур
     * - Вычисление площади фигуры без знания типа фигуры в compile-time
     * - Проверку на то, является ли треугольник прямоугольным
     */

    abstract class Figure<T>
    {
        bool СalculateArea(T figureType, out double result, params double[] parameters)
        {
            if (figureType?.GetType() == typeof(Circle) )
            {
                return new Circle(parameters[0]).СalculateArea(out result);
            }

            if (figureType?.GetType() == typeof(Triangle))
            {
                return new Triangle(parameters[0], parameters[1], parameters[2])
                    .СalculateArea(out result);
            }

            result = 0;
            return false;
        }
    }

    class Circle : Figure<Circle>
    {

        double radius;
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public bool СalculateArea(out double result, string? errorMessage = null)
        {
            try
            {
                // Проверка на переполнение
                checked
                {
                    result = Math.PI * Math.Pow(radius, 2);
                }

                errorMessage = null;
                return true;
            }
            catch (OverflowException e)
            {
                result = 0;
                errorMessage = e.Message;
                return false;
            }
        }
    }

    class Triangle : Figure<Triangle>
    {

        double a;
        double b;
        double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public bool СalculateArea(out double result, string? errorMessage = null)
        {
            try
            {
                // Проверка на переполнение
                checked
                {
                    double p = (a + b + c) / 2;

                    result = Math.Sqrt(p * (p-a) * (p-b) * (p-c));
                }

                errorMessage = null;
                return true;
            }
            catch (OverflowException e)
            {
                result = 0;
                errorMessage = e.Message;
                return false;
            }
        }

        /// <summary>
        /// Проверка на то, является ли треугольник прямоугольным
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public bool CheckRightTriangle(string? errorMessage = null)
        {
            try
            {
                bool result;
                // Проверка на переполнение
                checked
                {
                    // Проверяем теорему для прямоугольного треугольника:
                    // сумма квадратов катетов равна квадрату гипотенузы
                    result = (a * a) == (b * b) + (c * c);

                    if (!result) 
                        result = (b * b) == (a * a) + (c * c);

                    if (!result) 
                        result = (c * c) == (a * a) + (b * b);

                    return result;
                }
                
            }
            catch (OverflowException e)
            {
                errorMessage = e.Message;
                return false;
            }
        }
    }
}
    