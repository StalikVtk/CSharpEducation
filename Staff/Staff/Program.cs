using System;
using System.Reflection;
using Staff.EmployeeException;

namespace Staff
{
  /// <summary>
  /// Главная страница
  /// </summary>
  /// <remarks>
  /// Консольный интерфейс для управления сотрудниками в системе КОСА.
  /// Функционла системы:
  /// - Добавление сотрудников
  /// - Просмотр информации о сотруднике
  /// - Обновление данных сотрудника
  /// - Увольнение сотрудника
  /// - Расчет зарплаты сотрудника
  /// </remarks>
  internal class Program
  {
    private static EmployeeManager<Employee> Person = new EmployeeManager<Employee>();
    
    static byte InputItemUserMenu;
    const byte FullEmploymentType = 1;
    const byte PartEmploymentType = 2;

    #region Меню

    static void Main(string[] args)
    {
      bool ExitProgram = false;

      while (!ExitProgram)
      {
        try
        {
          ShowItemUserMenu();

          #region Пункты меню

          switch (InputItemUserMenu)
          {
            case 1:
              {
                EmpoyeeAdd();
                break;
              }
            case 2:
              {
                ShowEmployeeInfo();
                break;
              }
            case 3:
              {
                EmployeeUpdate();
                break;
              }
            case 4:
              {
                EmployeeDelete();
                break;
              }
            case 5:
              {
                CalculationEmployeeSalary();
                break;
              }
            case 6:
              {
                ExitProgram = true;
                Console.Clear();
                break;
              }
          }

          #endregion

        }
        catch (EmployeeAlreadyListException ex)
        {
          Console.WriteLine(ex.Message);
          Console.ReadKey();
        }
        catch (EmployeeNotFoundException ex)
        {
          Console.WriteLine(ex.Message);
          Console.ReadKey();
        }
        catch (Exception ex)
        {
          Logger StaffLogger = new Logger(MethodBase.GetCurrentMethod());
          StaffLogger.WrieLogFile(ex.Message, LogLevel.Error);
          Console.WriteLine(ex.Message);
        }
        Console.Clear();
      }
      Console.WriteLine("Успешно! Выход из программы осуществелен.");
      Console.ReadKey();

     
    }
    #endregion

    #region Методы меню

    /// <summary>
    /// Отображает главное меню системы.
    /// </summary>
    public static void ShowItemUserMenu()
    {
      byte MinItemMenu = 1;
      byte MaxItemMenu = 6;

      Console.WriteLine(@"КОСА - Кадровая общая система автоматизации
          Меню:
            1. Добавить сотрудника
            2. Информация о сотруднике
            3. Обновить данные сотрудника
            4. Уволить сотрудника
            5. Расчитать зп 
            6. Выход");
      do
      {
        InputItemUserMenu = UserInputData.GetMenuUser(MaxItemMenu);
        Console.Clear();
      }
      while ((InputItemUserMenu < MinItemMenu) || (InputItemUserMenu > MaxItemMenu));
    }

    /// <summary>
    /// Добавляет нового сотрудника в систему.
    /// </summary>
    public static void EmpoyeeAdd()
    {
      byte MaxItemMenu = 2;
      byte EmploymentType;

      Console.Clear();
      Console.WriteLine(@"Добавление сотрудника.
                Ставка сотрудника: 
                  1. Полная
                  2. Частичная");

      EmploymentType = UserInputData.GetMenuUser(MaxItemMenu); 
      if (EmploymentType == FullEmploymentType)
      {
        Person.Add(new FullTimeEmployee(UserInputData.GetIdPerson(), UserInputData.GetFullNamePerson(), UserInputData.GetBirthDatePerson(),
          UserInputData.GetSalaryPerson(EmploymentType)));
      }
      else if (EmploymentType == PartEmploymentType)
      {
        Console.Write("Укажите количество часов: ");
        int.TryParse(Console.ReadLine(), out int hours);
        Person.Add(new PartTimeEmployee(UserInputData.GetIdPerson(), UserInputData.GetFullNamePerson(), UserInputData.GetBirthDatePerson(),
          UserInputData.GetSalaryPerson(EmploymentType), hours));
      }

      Console.Clear();
    }

    /// <summary>
    /// Выводит информацию о сотруднике.
    /// </summary>
    public static void ShowEmployeeInfo()
    {
      Console.Clear();
      Console.WriteLine("Информация о сотруднике");

      try
      {
        var SearchPerson = Person.Get(UserInputData.GetIdPerson());
        SearchPerson.WriteInfo(SearchPerson);
        Console.ReadKey();
        Console.Clear();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadKey();
        Console.Clear();
      }
    }

    /// <summary>
    /// Обновляет данные сотрудника.
    /// </summary>
    public static void EmployeeUpdate()
    {
      Logger UpdatePersonLogger = new Logger(MethodBase.GetCurrentMethod());

      byte MinItemMenu = 1;
      byte MaxItemMenu = 4;

      Console.Clear();
      Console.WriteLine("Обновление данных о сотруднике");

      var SearchPerson = Person.Get(UserInputData.GetIdPerson());
      Console.Clear();

      do
      {
        Console.WriteLine($"Обновлние данных сотрудника: {SearchPerson.Name} c табельным  {SearchPerson.Id}");
        Console.WriteLine(" 1. ФИО \n 2. Дата рождения \n 3. Размер оклада \n 4. Выход");

        InputItemUserMenu = UserInputData.GetMenuUser(MaxItemMenu);
        if (InputItemUserMenu == MaxItemMenu)
        {
          Console.Clear();
          break;
        }
        Console.Clear();
      }
      while ((InputItemUserMenu < MinItemMenu) || (InputItemUserMenu > MaxItemMenu));

      var UpdatePerson = new FullTimeEmployee(SearchPerson.Id, SearchPerson.Name, SearchPerson.BirthDay, SearchPerson.BaseSalary);

      switch (InputItemUserMenu)
      {
        case 1:
          {
            UpdatePerson.Name = UserInputData.GetFullNamePerson();
            UpdatePersonLogger.WrieLogFile($"Обновление имени у: {SearchPerson.Id} ", LogLevel.UpdateInfo, SearchPerson.Name, UpdatePerson.Name);
            break;
          }
        case 2:
          {
            UpdatePerson.BirthDay = UserInputData.GetBirthDatePerson();
            UpdatePersonLogger.WrieLogFile($"Обновление даты рождения у: {SearchPerson.Id}", LogLevel.UpdateInfo, SearchPerson.BirthDay, UpdatePerson.BirthDay);
            break;
          }
        case 3:
          {
            UpdatePerson.BaseSalary = UserInputData.GetSalaryPerson(SearchPerson is FullTimeEmployee ? FullEmploymentType : PartEmploymentType);
            UpdatePersonLogger.WrieLogFile($"Обновление зарплаты у: {SearchPerson.Id}", LogLevel.UpdateInfo, SearchPerson.BaseSalary, UpdatePerson.BaseSalary);
            break;
          }
      }
      Person.Update(UpdatePerson);
      Console.Clear();
    }

    /// <summary>
    /// Удаляет сотрудника из системы.
    /// </summary>
    public static void EmployeeDelete()
    {
      Console.Clear();
      Console.WriteLine("Увольнение сотрудника");

      Person.Delete(Person.Get(UserInputData.GetIdPerson()));

      Console.Clear();
    }

    /// <summary>
    /// Расчитывает зарплату сотрудника.
    /// </summary>
    public static void CalculationEmployeeSalary()
    {
      Console.Clear();
      Console.WriteLine("Расчет зарплаты");

      var SearchPerson = Person.Get(UserInputData.GetIdPerson());

      Console.WriteLine(SearchPerson.CalculateSalary());
      Console.ReadKey();
      Console.Clear();
    }

    #endregion

  }
}
