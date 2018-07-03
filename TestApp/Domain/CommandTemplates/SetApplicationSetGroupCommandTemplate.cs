using System.Text.RegularExpressions;
using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    public class SetApplicationSetGroupCommandTemplate : ICommandTemplate
    {
        private readonly string pattern =
            $"^{CommandDictionary.Set} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplicationSet} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplicationSet} " +
            $"{CommandDictionary.Word}";

        private ApplicationSetConfig SetupApplication(string commandLine)
        {
            var separator = ' ';
            var args = commandLine.Split(separator);

            var application = new ApplicationSetConfig();

            var root = args[1];
            var appSetName = args[3];
            var appName = args[5];

            application.Root = root;
            application.Name = appSetName;

            application.Configurations.Add(new ApplicationSetConfig() { Name = appName, Root = root });

            return application;
        }

        public AbstractConfig Parse(string commandLine)
        {
            bool isMathced = Regex.IsMatch(commandLine, this.pattern);

            if (isMathced == true)
            {
                var result = this.SetupApplication(commandLine);
                return result;
            }

            return null;
        }
    }
}