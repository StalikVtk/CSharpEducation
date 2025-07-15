using System;

namespace Staff
{
  /// <summary>
  /// Сотрудник с полной занятостью. 
  /// </summary>
  internal class FullTimeEmployee : Employee
  {

    #region Свойства

    /// <summary>
    /// Уникальный индификатор сотрудника.
    /// Используется в системе как табельный номер.
    /// </summary>
    public override int Id {get; set;}

    /// <summary>
    /// Полное имя сотрудника. 
    /// </summary>
    public override string Name {get; set;}

    /// <summary>
    /// Дата рождения сотрудника.
    /// </summary>
    public override DateTime BirthDay {get; set;}

    /// <summary>
    /// Базовая зарплата сотрудника.
    /// </summary>
    public override decimal BaseSalary {get; set;}

    /// <summary>
    /// Рассчитывает заработную плату сотрудника.
    /// </summary>
    /// <returns>Рассчитанная заработная плата (базовая ставка).</returns>

    #endregion

    #region Методы

    public override decimal CalculateSalary()
    {
      return BaseSalary;
    }

    /// <summary>
    /// Выводит информацию о сотруднике.
    /// Указывате тип занятости сотрудника.
    /// Вызывает класс InfoPerson для вывода информации в консоль.
    /// </summary>
    /// <param name="person">Экземпляр сотрудника в системе.</param>
    public override void WriteInfo(Employee person)
    {
      string FullTime = "Полная";

      WriteInfoPerson.WriteConsole(person, FullTime);
    }

    #endregion

    #region Конструктор

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    /// <param name="name">Полное имя сотрудника.</param>
    /// <param name="birthDay">Дата рождения сотрудника.</param>
    /// <param name="baseSalary">Базовая зарплата.</param>
    public FullTimeEmployee(int personId, string name, DateTime birthDay, decimal baseSalary) : base(personId, name, birthDay, baseSalary)
    { }

    #endregion

  }
}
