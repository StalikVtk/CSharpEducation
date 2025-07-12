using System;

namespace Staff
{
  /// <summary>
  /// Сотрудник с частичной занятостью. 
  /// </summary>
  internal class PartTimeEmployee : Employee
  {
    public override int Id {get; set;}

    public override string Name {get; set;}

    public override DateTime BirthDay {get; set;}

    public override decimal BaseSalary {get; set;}

    /// <summary>
    /// Количество отработанных часов.
    /// </summary>
    public int hours { get; set; }

    public PartTimeEmployee(int personId, string name, DateTime birthDay, decimal baseSalary, int hours) : base(personId, name, birthDay, baseSalary)
    {
      this.hours = hours;
    }

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
  }
}
