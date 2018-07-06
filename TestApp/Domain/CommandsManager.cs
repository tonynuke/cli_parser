using System.Collections.Generic;
using System.IO;
using TestApp.Domain.CommandTemplates;
using TestApp.Domain.Configurations;

namespace TestApp.Domain
{
    /// <summary>
    /// Менеджер команд
    /// </summary>
    public class CommandsManager
    {
        /// <summary>
        /// Коллекция известных шаблонов команд
        /// </summary>
        private readonly List<ICommandTemplate> commandTemplates = new List<ICommandTemplate>();

        public OutputConfiguration Configuration { get; protected set; }

        /// <summary>
        /// Инициализирует новый экземпляр класс <see cref="CommandsManager"/>
        /// </summary>
        public CommandsManager()
        {
            this.Configuration = new OutputConfiguration();

            this.commandTemplates.Add(new SetApplicationDestinationPortCommandTemplate());
            this.commandTemplates.Add(new SetApplicationSourcePortCommandTemplate());
            this.commandTemplates.Add(new SetApplicationProtocolCommandTemplate());
            this.commandTemplates.Add(new SetApplicationDescriptionCommandTemplate());

            this.commandTemplates.Add(new SetApplicationSetCommandTemplate());
            this.commandTemplates.Add(new SetApplicationSetGroupCommandTemplate());
        }

        /// <summary>
        /// Парсит cli команду
        /// </summary>
        /// <param name="cli">CLI команда</param>
        /// <returns>Конфигурация</returns>
        public AbstractConfig Parse(string cli)
        {
            AbstractConfig application = null;

            foreach (var commandTemplate in this.commandTemplates)
            {
                application = commandTemplate.Parse(cli);

                if (application != null)
                {
                    break;
                }
            }

            return application;
        }

        /// <summary>
        /// Парсит файл на cli команды
        /// </summary>
        /// <param name="fileName">Путь к файлу с командами</param>
        /// <returns>Конфигурация</returns>
        public void ParseFile(string fileName)
        {
            foreach (string line in File.ReadLines(fileName))
            {
                var config = this.Parse(line);

                if (config != null)
                {
                    this.Configuration.UpdateConfig(config);
                }
            }
        }
    }
}