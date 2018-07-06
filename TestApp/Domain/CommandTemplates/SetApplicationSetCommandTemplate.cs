using System.Text.RegularExpressions;
using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Команда установки группы конфигураций для приложения
    /// </summary>
    public class SetApplicationSetCommandTemplate : ICommandTemplate
    {
        /// <summary>
        /// Паттерн команды
        /// </summary>
        private readonly string pattern =
            $"^{CommandDictionary.Set} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplicationSet} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplication} " +
            $"{CommandDictionary.Word}";

        /// <summary>
        /// Преобразует cli команду в конфигурацию
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Конфигурация</returns>
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

        /// <summary>
        /// Выполняет настройку конфигурации
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Конфигурация группы приложений</returns>
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

            application.Configurations.Add(new ApplicationConfig() { Name = appName, Root = root });

            return application;
        }
    }
}