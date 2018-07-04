namespace TestApp.Views
{
    public class ConfigurationViewModel
    {
        [View(0, 100, "Название")]
        public string Name { set; get; }

        [View(1, 50, "Тип")]
        public string Type { set; get; }

        [View(2, 40, "Протокол")]
        public string Protocol { set; get; }

        [View(3, 70, "Порт 1")]
        public string SourcePort { set; get; }

        [View(4, 40, "Порт 2")]
        public string DestinationPort { set; get; }

        [View(5, 200, "Члены")]
        public string Members { set; get; }
    }
}