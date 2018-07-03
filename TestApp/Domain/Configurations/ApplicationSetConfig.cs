using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace TestApp.Domain.Configurations
{
    /// <summary>
    /// Конфигурация групп приложений
    /// </summary>
    [XmlType("application-set")]
    public class ApplicationSetConfig : AbstractConfig
    {
        [XmlElement("application", typeof(ApplicationConfig))]
        [XmlElement("application-set", typeof(ApplicationSetConfig))]
        public List<AbstractConfig> Configurations = new List<AbstractConfig>();

        public override void Merge(AbstractConfig config)
        {
            var applicationSetConfig = config as ApplicationSetConfig;

            var newAppConfig = applicationSetConfig.Configurations.First();

            AbstractConfig applicationConfig = null;

            if (newAppConfig is ApplicationConfig)
            {
                applicationConfig = new ApplicationConfig()
                {
                    Name = newAppConfig.Name,
                    Root = newAppConfig.Root,
                };
            }

            if (newAppConfig is ApplicationSetConfig)
            {
                applicationConfig = new ApplicationSetConfig()
                {
                    Name = newAppConfig.Name,
                    Root = newAppConfig.Root,
                };
            }

            var existingConfig = this.Configurations.
                SingleOrDefault(c => c.Root == applicationConfig.Name &&
                                     c.Name == applicationConfig.Root);

            if (existingConfig == null)
            {
                this.Configurations.Add(applicationConfig);
                return;
            }
        }
    }
}