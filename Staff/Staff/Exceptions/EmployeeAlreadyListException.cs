namespace Staff.EmployeeException
{
  /// <summary>
  /// Исключение, возникающие при добавлении уже существующего сотрудника.
  /// </summary>
  internal class EmployeeAlreadyListException : EmployeeException
  {
    /// <summary>
    /// Инициализирует новый экземпляр исключения с сообщением об ошибке.
    /// Сообщение: Сотрудник с табельным __, уже существует!
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    public EmployeeAlreadyListException(int personId) : base(personId, $"Сотрудник с табельным {personId}, уже существует!") { }
  }
}
