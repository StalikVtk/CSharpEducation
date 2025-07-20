using System;

namespace Staff
{
  /// <summary>
  /// Сотрудник.
  /// Содержит общие свойства и методы для всех типов сотрудников.
  /// Должен быть унаследован для конкретного типа сотрудника (FullTime, PartTime).
  /// </summary>
  internal abstract class Employee
  {
    #region Свойства

    /// <summary>
    /// Уникальный индификатор сотрудника.
    /// Используется в системе как табельный номер.
    /// </summary>
    public abstract int Id { get; set; }

    /// <summary>
    /// Полное имя сотрудника. 
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Дата рождения сотрудника.
    /// </summary>
    public abstract DateTime BirthDay { get; set; }

    /// <summary>
    /// Базовая зарплата сотрудника.
    /// </summary>
    public abstract decimal BaseSalary { get; set; }

    #endregion

    #region Методы

    /// <summary>
    /// Выводит информацию о сотруднике.
    /// </summary>
    /// <param name="person">Экземпляр сотрудника в системе.</param>
    public abstract void WriteInfo(Employee person);

    /// <summary>
    /// Вычисляет зарплату сотрудника.
    /// </summary>
    /// <returns>Рассчитанная заработная плата сотрудника в виде десятичного числа.</returns>
    public abstract decimal CalculateSalary();

    #endregion

    #region Конструктор класса

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="personId">Уникальный индификатор сотрудника (Табельный номер).</param>
    /// <param name="name">Полное имя сотрудника.</param>
    /// <param name="birthDay">Дата рождения сотрудника.</param>
    /// <param name="baseSalary">Базовая зарплата.</param>
    public Employee(int personId, string name, DateTime birthDay, decimal baseSalary)
    {
      this.Id = personId;
      this.Name = name;
      this.BirthDay = birthDay;
      this.BaseSalary = baseSalary;
    }

    #endregion
  }
}
