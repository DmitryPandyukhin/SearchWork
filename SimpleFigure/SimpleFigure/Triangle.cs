using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigure
{
    internal interface ITriangle
    {
        double A { get; }
        double B { get; }
        double C { get; }
        bool? CheckRightTriangle();
    }

    public class Triangle : IFigure, ITriangle
    {
        public double A { get; }
        public double B { get; }
        public double C { get; }

        public double Square { get; set; }

        public Triangle(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }

        public bool СalculateSquare()
        {
            try
            {
                double p = (A + B + C) / 2;
                Square = Math.Sqrt(p * (p - A) * (p - B) * (p - C));

                return true;
            }
            catch
            {
                Square = 0;

                return false;
            }
        }

        /// <summary>
        /// Проверка на то, является ли треугольник прямоугольным
        /// </summary>
        /// <returns>True - треугольник прямоугольный. False - треугольник непрямоугольный. Null - не удалось выполнить проверку.</returns>
        public bool? CheckRightTriangle()
        {
            try
            {
                bool result = false;

                // Проверяем теорему для прямоугольного треугольника:
                // сумма квадратов катетов равна квадрату гипотенузы.
                result = (A * A) == (B * B) + (C * C);

                if (!result)
                    result = (B * B) == (A * A) + (C * C);

                if (!result)
                    result = (C * C) == (A * A) + (B * B);

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
