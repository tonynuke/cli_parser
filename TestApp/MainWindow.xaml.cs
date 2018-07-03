using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TestApp.Domain;
using TestApp.Domain.Configurations;
using TestApp.Views;

namespace TestApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = new ViewModel();
            DataContext = this.viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.viewModel.Read(this.FileName.Text);
        }
    }
}
