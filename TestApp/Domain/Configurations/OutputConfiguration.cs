using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace TestApp.Domain.Configurations
{
    /// <summary>
    /// Выходная конфигурация
    /// </summary>
    [XmlRoot]
    public class OutputConfiguration
    {
        /// <summary>
        /// Коллекция конфигураций
        /// </summary>
        [XmlElement("application", typeof(ApplicationConfig))]
        [XmlElement("application-set", typeof(ApplicationSetConfig))]
        public List<AbstractConfig> Configurations { protected set; get; }

        public OutputConfiguration()
        {
            this.Configurations = new List<AbstractConfig>();
        }

        /// <summary>
        /// Обновляет конфигурацию
        /// </summary>
        /// <param name="config"></param>
        public void UpdateConfig(AbstractConfig config)
        {
            var existingConfig = this.Configurations.
                SingleOrDefault(c => c.Root == config.Root &&
                                     c.Name == config.Name);

            if (existingConfig == null)
            {
                this.Configurations.Add(config);
                return;
            }

            existingConfig.Merge(config);
        }

        /// <summary>
        /// Преобразует конфигурацию в xml файл
        /// </summary>
        /// <returns></returns>
        public string Export()
        {
            StringWriter Output = new StringWriter(new StringBuilder());

            if (this.Configurations.Any() == false)
            {
                return null;
            }

            XmlRootAttribute xRoot = new XmlRootAttribute
            {
                ElementName = this.Configurations.First().Root
            };

            XmlSerializer xs = new XmlSerializer(typeof(OutputConfiguration), xRoot);

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            xs.Serialize(Output, this, ns);

            return Output.ToString();
        }
    }
}