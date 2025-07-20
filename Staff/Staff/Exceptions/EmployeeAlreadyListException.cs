namespace Staff.EmployeeException
{
  /// <summary>
  /// Исключение, возникающие при добавлении уже существующего сотрудника.
  /// </summary>
  internal class EmployeeAlreadyListException : EmployeeException
  {
    /// <summary>
    /// Конструктор
    /// Сообщение: Сотрудник с табельным __, уже существует!
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    public EmployeeAlreadyListException(int personId) 
      : base(personId, $"Сотрудник с табельным {personId}, уже существует!") 
    { }
  }
}
