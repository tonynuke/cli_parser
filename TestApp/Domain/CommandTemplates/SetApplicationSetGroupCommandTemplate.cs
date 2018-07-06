using System.Text.RegularExpressions;
using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Команда установки группы конфигураций для групп приложений
    /// </summary>
    public class SetApplicationSetGroupCommandTemplate : ICommandTemplate
    {
        /// <summary>
        /// Паттерн команды
        /// </summary>
        private readonly string pattern =
            $"^{CommandDictionary.Set} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplicationSet} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplicationSet} " +
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
                var result = this.SetupApplicationSetConfig(commandLine);
                return result;
            }

            return null;
        }

        /// <summary>
        /// Выполняет настройку конфигурации
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Конфигурация группы приложений</returns>
        private ApplicationSetConfig SetupApplicationSetConfig(string commandLine)
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
    }
}