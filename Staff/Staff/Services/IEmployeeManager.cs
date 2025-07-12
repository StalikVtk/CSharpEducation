namespace Staff
{
  /// <summary>
  /// Управление сотрудникми в системе.
  /// </summary>
  /// <typeparam name="T"> Тип сотрудника наследуюмый от Employee.</typeparam>
  internal interface IEmployeeManager <T>
  {
    /// <summary>
    /// Добавляет нового сотрудника в систему.
    /// </summary>
    /// <param name="employee">Экземпляр сотрудника в системе.</param>
    void Add(T employee);

    /// <summary>
    /// Получает сотрудника по индификатору
    /// </summary>
    /// <param name="id">Уникальный индификатор сотрудника (Табельный номер).</param>
    /// <returns></returns>
    T Get(int id);

    /// <summary>
    /// Обновляет данные существующего сотрудника в системе.
    /// </summary>
    /// <param name="employee">Экземпляр сотрудника с новыми данными.</param>
    void Update(T employee);

    /// <summary>
    /// Удаляет сотрудника из системы.
    /// </summary>
    /// <param name="employee">Экземпляр сотрудника в системе.</param>
    void Delete(T employee);
  }
}
