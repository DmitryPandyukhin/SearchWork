using System.Configuration;
using System.Collections.Specialized;

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

    public class StaticFigure
    {
        public static IFigure? Figure { get; }
        public static double Radius { get; }
        static double A { get; }
        static double B { get; }
        static double C { get; }

        static StaticFigure()
        {
            string? settingValue = ConfigurationManager.AppSettings.Get("Radius");
            if (settingValue != null)
            {
                Radius = double.Parse(settingValue);
            }

            settingValue = ConfigurationManager.AppSettings.Get("A");
            if (settingValue != null)
            {
                A = double.Parse(settingValue);
            }

            settingValue = ConfigurationManager.AppSettings.Get("B");
            if (settingValue != null)
            {
                A = double.Parse(settingValue);
            }

            settingValue = ConfigurationManager.AppSettings.Get("C");
            if (settingValue != null)
            {
                A = double.Parse(settingValue);
            }

            settingValue = ConfigurationManager.AppSettings.Get("FigureType")?.Trim().ToLower();

            Figure = settingValue switch
            {
                "circle" => new Circle(Radius),
                "triangle" => new Triangle(A, B, C),
                _ => null,
            };

            Figure?.СalculateSquare();
        }
    }

    

    

    
}
    