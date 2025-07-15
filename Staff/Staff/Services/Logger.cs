using System;
using System.IO;
using System.Reflection;

namespace Staff
{
  /// <summary>
  /// Логгер.
  /// </summary>
  internal class Logger : ILogger
  {
    /// <summary>
    /// Наименование метода, который вызвал лог.
    /// </summary>
    private readonly string methodName;

    /// <summary>
    /// Путь к файлу для записи логов.
    /// </summary>
    private readonly string filePath;

    /// <summary>
    /// Запись в файл
    /// </summary>
    private readonly StreamWriter writer;

    /// <summary>
    /// Инициализирует новый экземпляр класса Logger для записи логов в файл.
    /// </summary>
    /// <param name="methodName">Информация о вызывающем методе.</param>
    /// <param name="filePath">Путь к файлу лога. По умолчанию "log.txt" в рабочей директории.</param>
    public Logger(MethodBase methodName, string filePath = "log.txt")
    {
      this.methodName = methodName.Name;

      this.filePath = filePath;

      string directory = Path.GetFileName(this.filePath);
      if (string.IsNullOrEmpty(directory))
      {
        File.Create(this.filePath);
      }

      this.writer = new StreamWriter(this.filePath, append: true)
        {
          AutoFlush = true
        };
    }

    /// <summary>
    /// Записывает сообещение в лог-файл.
    /// </summary>
    /// <param name="messsage">Текст сообщения.</param>
    /// <param name="level">Уровень важности сообщения.</param>
    public void WrieLogFile(string messsage, LogLevel level)
    {
      string messageLog = $"| {DateTime.Now} | {level} | {methodName} | {messsage} |";
      writer.WriteLine(messageLog);

      writer?.Dispose();
    }

    /// <summary>
    /// Записывает сообещение в лог-файл.
    /// </summary>
    /// <typeparam name="T">Тип нового значения.</typeparam>
    /// <typeparam name="K">Тип старого значения.</typeparam>
    /// <param name="messsage">Текст сообщения.</param>
    /// <param name="level">Уровень важности сообщения.</param>
    /// <param name="newValue">Новое значение.</param>
    /// <param name="oldValue">Старое значение.</param>
    public void WrieLogFile<T, K>(string messsage, LogLevel level, T newValue, K oldValue)
    {
      string messageLog = $"| {DateTime.Now} | {level} | {methodName} | {messsage} | OLD: {newValue} | NEW: {oldValue} |";
      writer.WriteLine(messageLog);

      writer?.Dispose();
    }
  }
}
