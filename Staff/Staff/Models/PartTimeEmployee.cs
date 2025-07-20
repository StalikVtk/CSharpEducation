using System;

namespace Staff
{
  /// <summary>
  /// Сотрудник с частичной занятостью. 
  /// </summary>
  internal class PartTimeEmployee : Employee
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
    /// Количество отработанных часов.
    /// </summary>
    public int hours { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Рассчитывает заработную плату сотрудника.
    /// </summary>
    /// <returns>Рассчитанная заработная плата (базовая ставка * отработанные часы).</returns>
    public override decimal CalculateSalary()
    {
      return BaseSalary * hours;
    }

    /// <summary>
    /// Выводит информацию о сотруднике.
    /// Указывате тип занятости сотрудника.
    /// Вызывает класс InfoPerson для вывода информации в консоль.
    /// </summary>
    /// <param name="person">Экземпляр сотрудника в системе.</param>
    public override void WriteInfo(Employee person)
    {
      string PartlTime = "Частичная";

      WriteInfoPerson.WriteConsole(person, PartlTime);
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
    /// <param name="hours">Количество отработанных часов.</param>
    public PartTimeEmployee(int personId, string name, DateTime birthDay, decimal baseSalary, int hours) : base(personId, name, birthDay, baseSalary)
    {
      this.hours = hours;
    }

    #endregion

  }
}
