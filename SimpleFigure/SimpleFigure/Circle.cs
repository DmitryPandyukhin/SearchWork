using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigure
{
    internal interface ICircle
    {
        double Radius { get; }
    }

    public class Circle : IFigure, ICircle
    {
        public double Square { get; set; }
        // Радиус круга.
        public double Radius { get; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public bool СalculateSquare()
        {
            try
            {
                Square = Math.PI * Math.Pow(Radius, 2);

                return true;
            }
            catch
            {
                Square = 0;

                return false;
            }
        }
    }
}
