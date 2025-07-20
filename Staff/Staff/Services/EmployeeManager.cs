using System.Collections.Generic;
using Staff.EmployeeException;

namespace Staff
{
  /// <summary>
  /// Менеджер для управления списком сотрудников в системе.
  /// </summary>
  /// <typeparam name="T">Тип сотрудника (FullTime, PartTime).</typeparam>
  internal class EmployeeManager<T>: IEmployeeManager<T> where T : Employee
  {
    /// <summary>
    /// Коллекция сотрудников, для хранения в памяти.
    /// </summary>
    private readonly Dictionary<int, T> Employees = new Dictionary<int, T>();

    public void Add(T employee) 
    {
      if (Employees.ContainsKey(employee.Id))
        throw new EmployeeAlreadyListException(employee.Id);
      Employees.Add(employee.Id, employee);
    }

    public T Get(int personId) 
    {
      if (Employees.TryGetValue(personId, out T employee))
        return employee;
      throw new EmployeeNotFoundException(personId);
    }

    public void Update(T employee) 
    {
      Employees[employee.Id] = employee;
    }

    public void Delete(T employee) 
    {
      Employees.Remove(employee.Id);
    }
  }
}