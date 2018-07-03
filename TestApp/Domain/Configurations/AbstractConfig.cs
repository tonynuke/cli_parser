using System;
using System.Xml.Serialization;

namespace TestApp.Domain.Configurations
{
    /// <summary>
    /// Абстрактная конфигурация
    /// </summary>
    [Serializable(), XmlInclude(typeof(ApplicationConfig)), XmlInclude(typeof(ApplicationSetConfig))]
    public abstract class AbstractConfig
    {
        [XmlIgnore]
        public string Root { set; get; }

        [XmlElement("name")]
        public string Name { set; get; }

        public abstract void Merge(AbstractConfig config);
    }
}