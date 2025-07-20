using System;

namespace Staff
{
  /// <summary>
  /// Вывод ифнормации о сотруднике.
  /// </summary>
  internal class WriteInfoPerson
  {
    /// <summary>
    /// Выводит информацию с сотруднике в виде таблицы.
    /// </summary>
    /// <param name="person">Экземпляр сотрудника в системе.</param>
    /// <param name="employment">Тип занятости сотрудника.</param>
    public static void WriteConsole(Employee person, string employment)
    {
      string [] FullName = person.Name.Split(' ');
      Console.Clear();
      Console.WriteLine("+-------------+-------------+-------------+--------------+-------------+----------+-----------+");

      Console.WriteLine(
        $"|{FieldPerson.PersonNumber} " +
        $"|{FieldPerson.Surname}      " +
        $"|{FieldPerson.Name}         " +
        $"|{FieldPerson.Patronymic}    " +
        $"|{FieldPerson.BirthDate}    " +
        $"|{FieldPerson.Salary}    " +
        $"|{FieldPerson.Employment} |");

      Console.WriteLine("+-------------+-------------+-------------+--------------+-------------+----------+-----------+");

      Console.WriteLine("|" +
        person.Id.ToString().PadRight(13) + "|" +
        FullName[0].ToString().PadRight(13) + "|" +
        FullName[1].ToString().PadRight(13) + "|" +
        FullName[2].ToString().PadRight(14) + "|" + 
        person.BirthDay.ToString("dd.MM.yyyy").PadRight(13) + "|" +
        person.BaseSalary.ToString().PadRight(10) + "|" +
        employment.ToString().PadRight(11) + "|");

      Console.WriteLine("+-------------+-------------+-------------+--------------+-------------+----------+-----------+");
    }
  }
}
