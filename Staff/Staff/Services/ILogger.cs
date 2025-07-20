namespace Staff
{
  /// <summary>
  /// Уровень важности сообщения для логирования. 
  /// </summary>
  public enum LogLevel
  {
    /// <summary>
    /// Информационное сообщение об обновлении данных.
    /// </summary>
    UpdateInfo,

    /// <summary>
    /// Сообщение об ошибке в работе приложения.
    /// </summary>
    Error
  }

  /// <summary>
  /// Интерфейс системы логирования.
  /// </summary>
  public interface ILogger
  {
    void WrieLogFile(string messsage, LogLevel level);
  }
}
