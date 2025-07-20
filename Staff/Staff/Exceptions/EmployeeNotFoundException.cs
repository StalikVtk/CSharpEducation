namespace Staff.EmployeeException
{
  /// <summary>
  /// Исключение, возникающие, если сотрудник под табельным номером не найден.
  /// </summary>
  internal class EmployeeNotFoundException : EmployeeException
  {
    /// <summary>
    /// Конструктор
    /// Сообщение: Сотрудник с табельным __, не найден!
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    public EmployeeNotFoundException(int? personId) 
      : base(personId, $"Сотрудник с табельным {personId}, не найден!") 
    { }
  }
}
