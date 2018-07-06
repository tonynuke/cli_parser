using System.Text.RegularExpressions;
using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Команда установки протокола
    /// </summary>
    public class SetApplicationProtocolCommandTemplate : ICommandTemplate
    {
        /// <summary>
        /// Паттерн команды
        /// </summary>
        private readonly string pattern =
            $"^{CommandDictionary.Set} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.CliApplication} " +
            $"{CommandDictionary.Word} " +
            $"{CommandDictionary.Protocol} " +
            $"{CommandDictionary.TCP}|{CommandDictionary.UDP}";

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
                var result = this.SetupApplicationConfig(commandLine);
                return result;
            }

            return null;
        }

        /// <summary>
        /// Выполняет настройку конфигурации
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Конфигурация приложения</returns>
        private ApplicationConfig SetupApplicationConfig(string commandLine)
        {
            var separator = ' ';
            var args = commandLine.Split(separator);

            var application = new ApplicationConfig();

            var root = args[1];
            var appName = args[3];
            var protocol = args[5];

            application.Root = root;
            application.Name = appName;
            application.Protocol = protocol;
            ////application.TrySetProtocol(protocol);

            return application;
        }
    }
}