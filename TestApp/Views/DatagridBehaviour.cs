using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;

namespace TestApp.Views
{
    public class DatagridBehaviour : Behavior<UIElement>
    {
        private DataGrid dataGrid;

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
                    if (attribute is ViewAttribute)
                    {
                        var viewAttribute = attribute as ViewAttribute;

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