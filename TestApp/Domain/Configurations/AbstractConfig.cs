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
        /// <summary>
        /// Название корневого элемента
        /// </summary>
        [XmlIgnore]
        public string Root { set; get; }

        /// <summary>
        /// Название элемента
        /// </summary>
        [XmlElement("name")]
        public string Name { set; get; }

        /// <summary>
        /// Выполняет слияние конфигураций
        /// </summary>
        /// <param name="config">Конфигурация для слияния</param>
        public abstract void Merge(AbstractConfig config);
    }
}