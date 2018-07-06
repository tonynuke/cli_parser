using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Интерфейс шаблона для cli команд
    /// </summary>
    public interface ICommandTemplate
    {
        /// <summary>
        /// Преобразует cli команду в конфигурацию
        /// </summary>
        /// <param name="commandLine"></param>
        /// <returns>Конфигурация</returns>
        AbstractConfig Parse(string commandLine);
    }
}