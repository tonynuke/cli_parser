namespace TestApp.Views
{
    public class ViewAttribute : System.Attribute
    {
        public int ColumnNumber { get; protected set; }
        public int Width { get; protected set; }
        public string Name { get; protected set; }

        public ViewAttribute(int columnNumber, int width, string name)
        {
            this.ColumnNumber = columnNumber;
            this.Width = width;
            this.Name = name;
        }
    }
}