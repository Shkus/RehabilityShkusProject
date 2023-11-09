using DevExpress.Charts.Native;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;
using Dapper;
using DevExpress.Mvvm.Native;

namespace RehabilityApplication.CoreLib
{
    public static class SqliteManager
    {
        static string dbFilename = @"DB\Database.db";

        /// <summary>
        /// Создание БД.
        /// </summary>
        /// <param name="CreatingDatabaseFilename">Имя БД.</param>
        public static void CreateDatabaseLocal(string CreatingDatabaseFilename)
        {
            dbFilename = $@"DB\{CreatingDatabaseFilename}";
            CheckDirectory(dbFilename);

            string connectionString = $"Data Source={dbFilename};Version=3";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// Проверка существования папки для БД.
        /// </summary>
        /// <param name="path">Путь к БД.</param>
        public static void CheckDirectory(string path)
        {
            string folder = System.IO.Path.GetDirectoryName(path);
            if(!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
            }
        }

        /// <summary>
        /// Создание таблицы в БД.
        /// </summary>
        /// <param name="TableName">Имя таблицы.</param>
        /// <param name="SqlRequestColumnNames">Запрос.</param>
        public static void CreateTableInDatabase(string TableName, string SqlRequestColumnNames = "'Id' INTEGER PRIMARY KEY AUTOINCREMENT, 'Name' TEXT, 'Age' INTEGER, 'IsSelected' BOOLEAN")
        {
            string connectionString = $"Data Source={dbFilename};Version=3";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlRequest = $"CREATE TABLE IF NOT EXISTS '{TableName}' ({SqlRequestColumnNames});";

                    using(SQLiteCommand command = new SQLiteCommand(sqlRequest, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch { }
            }
        }

        /// <summary>
        /// Добавление записи в таблицу БД.
        /// </summary>
        /// <param name="TableName">Имя целевой таблицы.</param>
        /// <param name="SqlRequestColumnNames">Имена колонок.</param>
        /// <param name="SqlRequestValues">Значения.</param>
        public static void AddRecordToTable(string TableName, string SqlRequestColumnNames, string SqlRequestValues)
        {
            string connectionString = $"Data Source={dbFilename};Version=3";

            using(SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sqlRequest = $"INSERT INTO '{TableName}' ({SqlRequestColumnNames}) VALUES ({SqlRequestValues})";

                    using(SQLiteCommand command = new SQLiteCommand(sqlRequest, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }
                catch { }
            }
        }


        /// <summary>
        /// Получить данные для указанной таблицы.
        /// </summary>
        /// <param name="TableName">Имя таблицы.</param>
        /// <returns>Данные для отображения.</returns>
        public static object GetRecords(string TableName)
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string connectionUri = $@"URI=file:{dbFolderPath}\{dbFilename}";
            var connection = new SQLiteConnection(connectionUri);
            connection.Open();
            string sqlRequest = $"SELECT * FROM {TableName}";
            var command = new SQLiteCommand(sqlRequest, connection);
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        /// <summary>
        /// Удаление записи из указанной таблицы.
        /// </summary>
        /// <param name="TableName">Имя таблицы.</param>
        /// <param name="RecordId">Идентификатор записи.</param>
        public static void DeleteRecord(string TableName, dynamic RecordId)
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string connectionUri = $@"URI=file:{dbFolderPath}\{dbFilename}";
            var connection = new SQLiteConnection(connectionUri);
            connection.Open();

            string deleteQuery = $"DELETE FROM {TableName} WHERE Id = {RecordId};";

            using(SQLiteCommand cmd = new SQLiteCommand(deleteQuery, connection))
            {
                // Выполнить операцию DELETE
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        /// <summary>
        /// Обновление записи в таблице.
        /// </summary>
        /// <param name="TableName">Имя таблицы.</param>
        /// <param name="ColumnName">Имя колонки.</param>
        /// <param name="RecordId">Идентификатор записи.</param>
        /// <param name="NewValue">Новое значение.</param>
        public static void UpdateRecord(string TableName, string ColumnName, dynamic RecordId, dynamic NewValue)
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string connectionUri = $@"URI=file:{dbFolderPath}\{dbFilename}";
            var connection = new SQLiteConnection(connectionUri);
            connection.Open();

            if(NewValue is string)
            {
                NewValue = $"'{NewValue}'";
            }

            string updateQuery = $"UPDATE {TableName} SET {ColumnName} = {NewValue} WHERE Id = {RecordId};";

            using(SQLiteCommand cmd = new SQLiteCommand(updateQuery, connection))
            {
                // Выполнить операцию UPDATE
                cmd.ExecuteNonQuery();
            }

            connection.Close();
        }

        public static void SaveUpdateChange(string TableName, string ColumnName, dynamic RecordId, dynamic NewValue)
        {
            string sqlChangeFilename = CheckChangesFolder();

            if(NewValue is string)
            {
                NewValue = $"'{NewValue}'";
            }

            string sqlContent = $"UPDATE {TableName} SET {ColumnName} = {NewValue} WHERE Id = {RecordId};";
            System.IO.File.WriteAllText(sqlChangeFilename, sqlContent);
        }

        public static void SaveDeleteChange(string TableName, dynamic RecordId)
        {
            string sqlChangeFilename = CheckChangesFolder();
            string sqlContent = $"DELETE FROM {TableName} WHERE Id = {RecordId};";
            System.IO.File.WriteAllText(sqlChangeFilename, sqlContent);
        }

        public static void SaveAddRecordChange(string TableName, string SqlRequestColumnNames, string SqlRequestValues)
        {
            string sqlChangeFilename = CheckChangesFolder();
            string sqlContent = $"INSERT INTO '{TableName}' ({SqlRequestColumnNames}) VALUES ({SqlRequestValues})";
            System.IO.File.WriteAllText(sqlChangeFilename, sqlContent);
        }

        public static string CheckChangesFolder()
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string changesFolder = $@"{dbFolderPath}\Changes";
            if(!System.IO.Directory.Exists(changesFolder))
            {
                System.IO.Directory.CreateDirectory(changesFolder);
            }

            return $@"{changesFolder}\{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_ffffff")}.sql";
        }


        public static void Synchronize()
        {
            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string changesFolder = $@"{dbFolderPath}\Changes";

            string connectionUri = $@"URI=file:{dbFolderPath}\{dbFilename}";

            string[] sqlFiles = System.IO.Directory.GetFiles(changesFolder, "*.sql");

            foreach(string sqlFile in sqlFiles)
            {
                var connection = new SQLiteConnection(connectionUri);
                string sqlRequest = System.IO.File.ReadAllText(sqlFile);

                connection.Open();

                using(SQLiteCommand command = new SQLiteCommand(sqlRequest, connection))
                {
                    command.ExecuteNonQuery();
                }

                connection.Close();

                System.IO.File.Move(sqlFile, sqlFile + "_");
            }
        }

        //List<Persons> persons = new List<Persons>();
        public static List<dbCall> MapData(string TableName)
        {
            List<dbCall> pers = new List<dbCall>();    

            string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string dbFolderPath = System.IO.Path.GetDirectoryName(appPath);
            string connectionString = $"Data Source={dbFilename};Version=3;New=true";

            using(SQLiteConnection db = new SQLiteConnection(connectionString))
            {
                var list = db.Query<dbCall>($"SELECT * FROM {TableName}");
                list.ForEach(t=> pers.Add(t));
            }

            return pers;
        }
    }
}
