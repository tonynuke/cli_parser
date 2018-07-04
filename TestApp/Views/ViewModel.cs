using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using TestApp.Annotations;
using TestApp.Domain;
using TestApp.Domain.Configurations;

namespace TestApp.Views
{
    public class ViewModel : INotifyPropertyChanged
    {
        public CommandsManager CommandsManager { get; set; }

        public ObservableCollection<ConfigurationViewModel> Configurations { set; get; }

        public ViewModel()
        {
            this.CommandsManager = new CommandsManager();
            this.Configurations = new ObservableCollection<ConfigurationViewModel>();
        }

        public void Export(string fileName)
        {
            var output = this.CommandsManager.Configuration.Export();
            File.WriteAllText(@"D:\Projects\Repos\TestApp\TestApp\Src\res.txt", output);
        }

        public void Read(string fileName)
        {
            this.CommandsManager.ParseFile(@"D:\Projects\Repos\TestApp\TestApp\Src\test.txt");

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

            OnPropertyChanged("Configurations");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}