using System.Collections.ObjectModel;
using System.Linq;
using TestApp.Domain;
using TestApp.Domain.Configurations;

namespace TestApp.Views
{
    public class ViewModel
    {
        public CommandsManager CommandsManager { get; set; }

        public ObservableCollection<ConfigurationViewModel> Configurations { set; get; } = new ObservableCollection<ConfigurationViewModel>();

        public void Read(string fileName)
        {
            this.CommandsManager.ParseFile(@"C:\Users\Anton\Source\Repos\TestApp\TestApp\Src\test.txt");

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
                        Members = abstractConfig.Configurations.Select(c => c.Name).
                            Aggregate((x, y) => $"{x};{y}"),
                    };
                }

                this.Configurations.Add(viewModel);
            }
        }

        public ViewModel()
        {
            this.CommandsManager = new CommandsManager();
        }
    }
}