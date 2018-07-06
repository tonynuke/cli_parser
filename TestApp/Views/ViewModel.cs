using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using TestApp.Domain;
using TestApp.Domain.Configurations;

namespace TestApp.Views
{
    /// <summary>
    /// View модель для <see cref="CommandsManager"/>
    /// </summary>
    public class ViewModel
    {
        /// <summary>
        /// Менеджер команд
        /// </summary>
        public CommandsManager CommandsManager { get; set; }

        /// <summary>
        /// Коллекция конфигурацтй для отображения
        /// </summary>
        public ObservableCollection<ConfigurationViewModel> Configurations { set; get; }

        /// <summary>
        /// Инициализирует новый экземпляр класс <see cref="ViewModel"/>
        /// </summary>
        public ViewModel()
        {
            this.CommandsManager = new CommandsManager();
            this.Configurations = new ObservableCollection<ConfigurationViewModel>();
        }

        /// <summary>
        /// Сохраняет конфигурацию в файл
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void Export(string fileName)
        {
            var output = this.CommandsManager.Configuration.Export();
            File.WriteAllText(fileName, output);
        }

        /// <summary>
        /// Считывает файл и создает конфигурацию на его основе
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public void Read(string fileName)
        {
            this.CommandsManager.ParseFile(fileName);

            foreach (var configuration in CommandsManager.Configuration.Configurations)
            {
                ConfigurationViewModel viewModel = null;

                if (configuration is ApplicationConfig)
                {
                    var abstractConfig = configuration as ApplicationConfig;

                    viewModel = new ConfigurationViewModel()
                    {
                        Name = abstractConfig.Name,
                        Type = "Service",
                        Protocol = abstractConfig.Protocol,
                        DestinationPort = abstractConfig.DestinationPort,
                        SourcePort = abstractConfig.SourcePort,
                    };
                }

                if (configuration is ApplicationSetConfig)
                {
                    var abstractConfig = configuration as ApplicationSetConfig;

                    viewModel = new ConfigurationViewModel()
                    {
                        Name = abstractConfig.Name,
                        Type = "Group",
                        Members = abstractConfig.Configurations.Select(c => c.Name).Aggregate((x, y) => $"{x},{y}"),
                    };
                }

                this.Configurations.Add(viewModel);
            }
        }
    }
}