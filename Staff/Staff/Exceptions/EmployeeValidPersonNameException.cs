
namespace Staff.EmployeeException
{
  /// <summary>
  /// Исключение, возникающие, если ФИО указано некорректно.
  /// </summary>
  internal class EmployeeValidPersonNameException : EmployeeException
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер). Принимает Null.</param>
    /// <remarks>
    /// Исключение с сообщением об ошибке если: ФИО пустое, ФИО введено не полностью.
    /// </remarks>
    public EmployeeValidPersonNameException(int? personId, string message) : base(personId, message) 
    { }
  }
}
