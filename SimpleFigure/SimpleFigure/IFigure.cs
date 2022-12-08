using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFigure
{
    public interface IFigure
    {
        /// <summary>
        /// Площадь
        /// </summary>
        double Square { get; set; }
        /// <summary>
        /// Вычисление площади фигуры.
        /// </summary>
        /// <returns>True - площадь вычислена. False - не удалось вычислить площадь.</returns>
        bool СalculateSquare();
    }
}
