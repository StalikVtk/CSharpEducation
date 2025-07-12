using System;

namespace Staff
{
  /// <summary>
  /// Сотрудник с полной занятостью. 
  /// </summary>
  internal class FullTimeEmployee : Employee
  {
    public override int Id {get; set;}

    public override string Name {get; set;}

    public override DateTime BirthDay {get; set;}

    public override decimal BaseSalary {get; set;}

    public FullTimeEmployee(int personId, string name, DateTime birthDay, decimal baseSalary) : base(personId, name, birthDay, baseSalary)
    {

    }

    /// <summary>
    /// Рассчитывает заработную плату сотрудника.
    /// </summary>
    /// <returns>Рассчитанная заработная плата (базовая ставка).</returns>
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
  }
}
