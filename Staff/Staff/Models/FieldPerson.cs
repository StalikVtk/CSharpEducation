namespace Staff
{
  /// <summary>
  /// Поля отображения информации о сотруднике.
  /// Используется для названия полей при выводе информации о сотруднике в классе WriteInfoPerson.
  /// </summary>
  public enum FieldPerson
  { 
    /// <summary>
    /// Табельный номер.
    /// </summary>
    PersonNumber,

    /// <summary>
    /// Фамилия.
    /// </summary>
    Surname,

    /// <summary>
    /// Имя.
    /// </summary>
    Name,

    /// <summary>
    /// Отчество.
    /// </summary>
    Patronymic,

    /// <summary>
    /// Дата рождения.
    /// </summary>
    BirthDate,

    /// <summary>
    /// Зарплата.
    /// </summary>
    Salary,

    /// <summary>
    /// Занятость.
    /// </summary>
    Employment
  }
}
