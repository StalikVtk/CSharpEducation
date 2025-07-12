using Staff.EmployeeException;
using System;
using System.Globalization;

namespace Staff
{
  /// <summary>
  /// Пользовательские данные при вводе.
  /// Содержит методы для корректного ввода данных.
  /// </summary>
  internal class UserInputData
  {
    /// <summary>
    /// Получает из консоли корректный номер табельного номера.
    /// </summary>
    /// <returns>Табельный номер (Уникальный индификатор сотрудника).</returns>
    public static int GetIdPerson()
    {
      while (true)
      {
        Console.Write("Введите табельный номер сотрудника: ");
        if (int.TryParse(Console.ReadLine(), out int personId))
          return personId;
        Console.WriteLine("Ошибка! Введен неверный формат табельного номера. Он должен быть числовым!");
      }
    }

    /// <summary>
    /// Получает из консоли полное ФИО сотрудника. 
    /// </summary>
    /// <returns>Полное имя в формате 'Фамилия Имя Отчество'</returns>
    public static string GetFullNamePerson()
    {
      while(true)
      {
        try
        {
          Console.Write("Введите полное ФИО: ");
          string FullName = Console.ReadLine();
          if (!String.IsNullOrEmpty(FullName))
          {
            if (FullName.Split(' ').Length < 3)
              throw new EmployeeValidPersonNameException(null, "Ошибка! Введено не полное имя сотрудника! Повторите ввод в формате Фамилия Имя Отчество.");
            return FullName;
          }
          throw new EmployeeValidPersonNameException(null, "Ошибка! ФИО сотрудника не может быть пустым!");
        }
        catch (EmployeeValidPersonNameException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }
    }

    /// <summary>
    /// Получает из консоли дату рождения сотрудника
    /// </summary>
    /// <returns>Дата рождения в формате 'dd.MM.yyyy'</returns>
    public static DateTime GetBirthDatePerson()
    {
      while (true)
      {
        Console.Write("Введите дату рождения в формате 'дд.мм.гггг': ");
        if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime birthDay))
        {
          return birthDay;
        }
        else
        {
          Console.WriteLine("Ошибка! Некорректный ввод даты!");
        }
      }
    }

    /// <summary>
    /// Получает из консоли размер ставки сотрудника
    /// </summary>
    /// <param name="employmentType">Тип занятости (1 - Полная, 2 - Частичная)</param>
    /// <returns>Размер ставки</returns>
    public static decimal GetSalaryPerson(int employmentType)
    {
      string WriteMessage = employmentType == 1? "Введите оклад: " : "Введите часовую ставку: ";
      while (true)
      {
        Console.Write(WriteMessage);
        if (decimal.TryParse(Console.ReadLine(), out decimal salary) && (salary > 0))
          return salary;
        else
        {
          Console.WriteLine("Ошибка! Повторите ввод!");
        }
      }
    }

    /// <summary>
    /// Получает из консоли выбранный пункт меню системы.
    /// </summary>
    /// <param name="maxCountItem">Максимальный номер пункта меню.</param>
    /// <returns>Выбранный пункт меню.</returns>
    public static byte GetMenuUser(byte maxCountItem)
    {
      byte ItemUserMenu;
      while (true)
      {
        Console.Write("Укажите пункт меню: ");
        if (byte.TryParse(Console.ReadLine(), out ItemUserMenu) && (ItemUserMenu >= 1) && (ItemUserMenu <= maxCountItem))
        {
          return ItemUserMenu;
        }
        Console.WriteLine($"Ошибка! Нужно указать число (1-{maxCountItem})");
        Console.ReadKey();
      }
    }
  }
}
