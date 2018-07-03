using TestApp.Domain.Configurations;

namespace TestApp.Domain.CommandTemplates
{
    /// <summary>
    /// Интерфейс шаблона для cli команд
    /// </summary>
    public interface ICommandTemplate
    {
        AbstractConfig Parse(string commandLine);
    }
}