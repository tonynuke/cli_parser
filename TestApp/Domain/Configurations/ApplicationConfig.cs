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
        [XmlElement("description")]
        public string Description { set; get; }

        [XmlElement("destination-port")]
        public string DestinationPort { set; get; }

        [XmlElement("source-port")]
        public string SourcePort { set; get; }

        [XmlElement("protocol")]
        public string Protocol { set; get; }

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

        ////public void TrySetProtocol(string value)
        ////{
        ////    try
        ////    {
        ////        var savingValue = (Protocol)Enum.Parse(typeof(Protocol), value, true);
        ////        this.Protocol = savingValue;
        ////    }
        ////    catch (Exception exception)
        ////    {
        ////        throw exception;
        ////    }
        ////}

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