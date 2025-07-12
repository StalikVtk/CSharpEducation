
namespace Staff.EmployeeException
{
  /// <summary>
  /// Исключение, возникающие, если ФИО указано некорректно.
  /// </summary>
  internal class EmployeeValidPersonNameException : EmployeeException
  {
    /// <summary>
    /// Инициализирует новый экземпляр исключения с сообщением об ошибке если: ФИО пустое, ФИО введено не полностью.
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер). Принимает Null.</param>
    public EmployeeValidPersonNameException(int? personId, string message) : base(personId, message)
    { }
  }
}
