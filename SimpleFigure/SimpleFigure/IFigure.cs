namespace SimpleFigure
{
    public interface IFigure
    {
        /// <summary>
        /// Площадь
        /// </summary>
        double Square { get; set; }

        /// <summary>
        /// Вычисление площади фигуры без знания типа фигуры в compile-time.
        /// </summary>
        /// <param name="prm">Входные данные.</param>
        /// <returns>True - площадь вычислена. False - не удалось вычислить площадь.</returns>
        bool СalculateSquare(params double[] prm);
    }
}
