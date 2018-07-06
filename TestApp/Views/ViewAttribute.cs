namespace TestApp.Views
{
    /// <summary>
    /// Атрибут для конфигурирования отображения в представлении
    /// </summary>
    public class ViewAttribute : System.Attribute
    {
        /// <summary>
        /// Номер столбца
        /// </summary>
        public int ColumnNumber { get; protected set; }

        /// <summary>
        /// Ширина столбца
        /// </summary>
        public int Width { get; protected set; }

        /// <summary>
        /// Название столбца
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Инициализирует новый эксземпляр класса <see cref="ViewAttribute"/>
        /// </summary>
        /// <param name="columnNumber">Номер столбца</param>
        /// <param name="width">Ширина столбца</param>
        /// <param name="name">Название столбца</param>
        public ViewAttribute(int columnNumber, int width, string name)
        {
            this.ColumnNumber = columnNumber;
            this.Width = width;
            this.Name = name;
        }
    }
}