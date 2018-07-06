using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace TestApp.Views
{
    /// <summary>
    /// Behaviour для DataGrid
    /// </summary>
    public class DatagridBehaviour : Behavior<UIElement>
    {
        private DataGrid dataGrid;

        /// <summary>
        /// Срабатывает при присоединии поведения к элементу
        /// </summary>
        /// <remarks>Настраивает отображение при помощи атрибутов у <see cref="ConfigurationViewModel"/></remarks>
        protected override void OnAttached()
        {
            base.OnAttached();

            this.dataGrid = this.AssociatedObject as DataGrid;
            this.dataGrid.AutoGenerateColumns = false;

            var type = typeof(ConfigurationViewModel);
            var props = type.GetProperties();

            foreach (var prop in props)
            {
                object[] attributes = prop.GetCustomAttributes(true);
                foreach (object attribute in attributes)
                {
                    if (attribute is ViewAttribute viewAttribute)
                    {
                        var column = new DataGridTextColumn
                        {
                            Header = viewAttribute.Name,
                            Width = viewAttribute.Width,
                            DisplayIndex = viewAttribute.ColumnNumber,
                            Binding = new Binding(prop.Name)
                        };

                        this.dataGrid.Columns.Add(column);
                    }
                }
            }
        }
    }
}