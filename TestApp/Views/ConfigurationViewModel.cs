namespace TestApp.Views
{
    /// <summary>
    /// View модель для конфигурации
    /// </summary>
    public class ConfigurationViewModel
    {
        /// <summary>
        /// Название
        /// </summary>
        [View(0, 100, "Название")]
        public string Name { set; get; }

        /// <summary>
        /// Тип
        /// </summary>
        [View(1, 50, "Тип")]
        public string Type { set; get; }

        /// <summary>
        /// Протокол
        /// </summary>
        [View(2, 40, "Протокол")]
        public string Protocol { set; get; }

        /// <summary>
        /// Исходный порт
        /// </summary>
        [View(3, 70, "Порт 1")]
        public string SourcePort { set; get; }

        /// <summary>
        /// Порт назначения
        /// </summary>
        [View(4, 40, "Порт 2")]
        public string DestinationPort { set; get; }

        /// <summary>
        /// Члены коллекции конфигураций
        /// </summary>
        [View(5, 200, "Члены")]
        public string Members { set; get; }
    }
}