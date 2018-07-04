using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
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
        private readonly ViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();

            this.viewModel = new ViewModel();
            this.ConfigsGrid.DataContext = this.viewModel;
        }

        private void ImportCli(object sender, RoutedEventArgs e)
        {
            this.viewModel.Read(this.FileName.Text);
        }

        private void ExportToXml(object sender, RoutedEventArgs e)
        {
            this.viewModel.Export("");
        }
    }
}
