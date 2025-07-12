using System;

namespace Staff.EmployeeException
{
  /// <summary>
  /// Базовый класс исключений для операций над сотрудниками.
  /// </summary>
  internal class EmployeeException : Exception
  {
    /// <summary>
    /// Уникальный индификатор сотрудника.
    /// Используется в системе как табельный номер.
    /// </summary>
    public int? personId { get; }

    /// <summary>
    /// Инициализирует новый экземпляр исключения EmployeeException
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    /// <param name="message">Сообщение об ошибке.</param>
    protected EmployeeException(int? personId, string message) : base(message)
    {

      this.personId = personId;

    }
  }
}
