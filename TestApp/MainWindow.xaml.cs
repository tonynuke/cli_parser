using System.Windows;
using TestApp.Views;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel viewModel;

        /// <summary>
        /// Коллекция известных шаблонов команд
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = new ViewModel();
            this.ConfigsGrid.DataContext = this.viewModel;
        }

        /// <summary>
        /// Обработчик события импорта cli команд
        /// </summary>
        /// <param name="sender">Объект, пославший событие</param>
        /// <param name="e">Данные события</param>
        private void ImportCli(object sender, RoutedEventArgs e)
        {
            this.viewModel.Read(this.FileName.Text);
        }

        /// <summary>
        /// Обработчик события экспорта в XML
        /// </summary>
        /// <param name="sender">Объект, пославший событие</param>
        /// <param name="e">Данные события</param>
        private void ExportToXml(object sender, RoutedEventArgs e)
        {
            this.viewModel.Export("");
        }
    }
}
