using System;
using System.Reflection;
using System.Xml.Serialization;

namespace TestApp.Domain.Configurations
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    [XmlType("application")]
    public class ApplicationConfig : AbstractConfig
    {
        /// <summary>
        /// Описание
        /// </summary>
        [XmlElement("description")]
        public string Description { set; get; }

        /// <summary>
        /// Порт назначения
        /// </summary>
        [XmlElement("destination-port")]
        public string DestinationPort { set; get; }

        /// <summary>
        /// Исходный порт
        /// </summary>
        [XmlElement("source-port")]
        public string SourcePort { set; get; }

        /// <summary>
        /// Протокол
        /// </summary>
        [XmlElement("protocol")]
        public string Protocol { set; get; }

        /// <summary>
        /// Выполняет слияние конфигураций
        /// </summary>
        /// <param name="config">Конфигурация для слияния</param>
        public override void Merge(AbstractConfig config)
        {
            if (config is ApplicationConfig)
            {
                var props = config.GetType().GetProperties();

                foreach (var prop in props)
                {
                    var value = prop.GetValue(config, null);

                    if (value != null)
                    {
                        this.GetType().GetProperty(prop.Name).SetValue(this, value);
                    }
                }
            }
        }

        /// <summary>
        /// Устанавливает значение атрибутов
        /// </summary>
        /// <param name="attributeName">Наименование атрибута</param>
        /// <param name="value">Значение</param>
        public void SetPropsFromString(string attributeName, string value)
        {
            PropertyInfo propertyInfo = this.GetType().
                GetProperty(attributeName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new NotSupportedException();
            }

            var type = propertyInfo.PropertyType;

            if (type.IsEnum)
            {
                object savingValue = Enum.Parse(type, value, true);
                propertyInfo.SetValue(this, savingValue, null);
                return;
            }

            propertyInfo.SetValue(this, Convert.ChangeType(value, type), null);
        }
    }
}