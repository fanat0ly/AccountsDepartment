using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace UIProject
{
    /// <summary>
    /// Тип зарплаты
    /// </summary>
    public enum SalaryTypes
    {
        Average = 0, // средняя
        Maximum = 1  // максимальная
    }

    /// <summary>
    /// Класс, реализующий взаимодействие с базой данных
    /// </summary>
    class DbContext
    {
        /// <summary>
        /// Cтрока подключения
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Таблица-результат запроса
        /// </summary>
        public DataTable DataTable { get; set; }
        /// <summary>
        /// Исключение, возникшее при работе с БД 
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="connectionString">строка подключения</param>
        public DbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
            this.DataTable = new DataTable();
        }

        #region retrive
        /// <summary>
        /// Получить таблицу сотрудников
        /// </summary>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool RetriveEmployees()
        {
            string sqlQuery = "SELECT * FROM [Employees]";
            DataTable = new DataTable();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();
                    
                    var adapter = new SqlDataAdapter(sqlQuery, sqlConn);
                    
                    adapter.Fill(DataTable);                    
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
        /// <summary>
        /// Получить таблицу выплат
        /// </summary>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool RetrivePayments()
        {
            string sqlQuery = "SELECT * FROM [Payments]";
            DataTable = new DataTable();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();
                    
                    var adapter = new SqlDataAdapter(sqlQuery, sqlConn);
                    
                    adapter.Fill(DataTable);
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
         /// <summary>
        /// Получить сводную таблицу истории выплат
        /// </summary>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool RetrivePaymentsHistory()
        {
            string sqlQuery = "SELECT * FROM [PaymentsHistory]";
            DataTable = new DataTable();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();

                    var adapter = new SqlDataAdapter(sqlQuery, sqlConn);

                    adapter.Fill(DataTable);
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
        /// <summary>
        /// Получить сводную таблицу зарплат каждого сотрудника за определенный период
        /// </summary>
        /// <param name="beginDate">начальная дата</param>
        /// <param name="endDate">конечная дата</param>
        /// <param name="salaryType">тип зарплаты</param>
        /// <param name="showAll">все сотрудники (в т.ч. уволенные)</param>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool RetrieveEmployeeSalaries(DateTime beginDate, DateTime endDate, SalaryTypes salaryType, bool showAll)
        {
            this.DataTable = new DataTable();
            
            // выбор столбца зарплаты в зависимости от ее типа
            string selectSalaryColumn = salaryType switch
            {
                SalaryTypes.Average => "[f].[AvgSalary] AS [Salary]",
                SalaryTypes.Maximum => "[f].[MaxSalary] AS [Salary]",
                _=> throw new ArgumentException("Недопустимый параметр запроса")
            };
            // фильтровать уволенных сотрудников
            string whereShowAllCond = showAll ? "" : "WHERE [f].[Active] <> @all";
            // конструируем текст запроса
            string sqlQuery = $"SELECT [f].[EmployeeId], [f].[Name], {selectSalaryColumn} " +
                              $"FROM [fn_Empl_salaries_list](@dateBegin, @dateEnd) [f] {whereShowAllCond} " + 
                              $"ORDER BY [Salary] DESC, [f].[EmployeeId] ASC";
           
            try
            {
                // Создаем подключение
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    // Создаем команду и передаем ей необходимые параметры 
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, sqlConn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@dateBegin", SqlDbType.DateTime2, 7) { Value = beginDate });
                        cmd.Parameters.Add(new SqlParameter("@dateEnd", SqlDbType.DateTime2, 7) { Value = endDate });
                        cmd.Parameters.Add(new SqlParameter("@all", SqlDbType.Bit) { Value = showAll });

                        // если соединение не открыто - открыть
                        if (sqlConn.State != ConnectionState.Open)
                            sqlConn.Open();
                        
                        // выполняем запрос и заполняем таблицу результатами запроса
                        DataTable.Load(cmd.ExecuteReader());
                    }
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
        #endregion

        #region update
        /// <summary>
        /// Обновить таблицу сотрудников
        /// </summary>
        /// <param name="dt">таблица с новыми данными</param>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool UpdateEmployees(DataTable dt)
        {
            string sqlQuery = "SELECT * FROM [Employees]";
            
            try
            {
                // Создаем подключение
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    // открываем подключение
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();

                    // создаем адаптер
                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, sqlConn);
                    // для данного адаптера генерируем команды InsertCommand, UpdateCommand и DeleteCommand
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                    
                    /* Настраиваем команду InsertCommand 
                       ( передаем значения полей строки таблицы и возвращаем идентификатор, созданный базой данных)
                     */
                    adapter.InsertCommand = new SqlCommand("sp_CreateEmployee", sqlConn);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar, 50, "Name"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@active", SqlDbType.Bit, 0, "Active"));
                    var paramId = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");
                    paramId.Direction = ParameterDirection.Output;

                    // обновить значения в БД, выполнив команды объекта cmdBuilder
                    adapter.Update(dt);
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
        /// <summary>
        /// Обновить таблицу выплат
        /// </summary>
        /// <param name="dt">таблица с новыми данными</param>
        /// <returns>true - запрос выполнен без ошибок</returns>
        public bool UpdatePayments(DataTable dt)
        {
            string sqlQuery = "SELECT * FROM [Payments]";

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConnectionString))
                {
                    if (sqlConn.State != ConnectionState.Open)
                        sqlConn.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, sqlConn);
                    SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);

                    adapter.InsertCommand = new SqlCommand("sp_CreatePayment", sqlConn);
                    adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@salary", SqlDbType.Money, 0, "Salary"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@datetime", SqlDbType.DateTime2, 7, "Datetime"));
                    adapter.InsertCommand.Parameters.Add(new SqlParameter("@empId", SqlDbType.Int, 0, "EmployeeId"));
                    var paramId = adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "Id");
                    paramId.Direction = ParameterDirection.Output;

                    adapter.Update(dt);
                }

                Exception = null;
                return true;
            }
            catch (Exception ex)
            {
                Exception = ex;
                return false;
            }
        }
        #endregion

       
    }
}
