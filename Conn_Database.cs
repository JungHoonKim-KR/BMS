using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.IO;

namespace BMSmonitoring
{
    public sealed class Conn_Database
    {
        private static readonly Conn_Database instance = new Conn_Database();
        private readonly SQLiteConnection conn;

        private Conn_Database()
        {
            string connectionString = @"Data Source=C:\Users\neotek\Desktop\BMS\bin\Debug\NEOTEK_BMS.db";
            conn = new SQLiteConnection(connectionString);

            try
            {

                // 데이터베이스 파일 존재 확인 및 생성
                if (!File.Exists(connectionString.Split('=')[1].Trim()))
                {
                    SQLiteConnection.CreateFile(connectionString.Split('=')[1].Trim());
                    Console.WriteLine("파일생성");

                    conn.Open();

                    string createTable1 = "CREATE TABLE SerialPort (portName TEXT, baudRate INTEGER, dataBits INTEGER, parity TEXT, stopBits INTEGER, flowControl TEXT)";
                    string createTable2 = "CREATE TABLE BatteryData (no INTEGER PRIMARY KEY, time TEXT not null DEFAULT (datetime('now', '+9 hours')), voltage FLOAT, current FLOAT, SOC FLOAT, SOH FLOAT, avgCellVolt FLOAT, maxCellVolt FLOAT,"
                            + "moduleMaxVolt INT, minCellVolt FLOAT, moduleMinVolt INT, avgCellTemp FLOAT, maxCellTemp FLOAT, moduleMaxTemp INT, minCellTemp FLOAT, moduleMinTemp INT)";
                    string createTable3 = "CREATE TABLE EventLog (no INTEGER PRIMARY KEY, event TEXT, status TEXT, time TEXT not null DEFAULT (datetime('now', '+9 hours')))";
                    string createTable4 = "CREATE TABLE CellLog (time TEXT not null DEFAULT (datetime('now', '+9 hours')), module INTERGER not null, cell1 FLOAT, cell2 FLOAT, cell3 FLOAT, cell4 FLOAT, cell5 FLOAT, cell6 FLOAT,"
                            + "cell7 FLOAT, cell8 FLOAT, cell9 FLOAT, cell10 FLOAT, cell11 FLOAT, cell12 FLOAT, temp1 FLOAT, temp2 FLOAT, temp3 FLOAT, temp4 FLOAT, temp5 FLOAT, temp6 FLOAT)";

                    CreateTable(createTable1);
                    CreateTable(createTable2);
                    CreateTable(createTable3);
                    CreateTable(createTable4);

                    var data = new Dictionary<string, object>
                    {
                        {"portName", "COM1"},
                        {"baudRate", 38400 },
                        {"dataBits", 8 },
                        {"parity", "None" },
                        {"stopBits", 1},
                        {"flowControl", "None" }
                    };
                    InsertData("SerialPort", data);
                }
                else
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static Conn_Database Instance => instance;

        public void Close()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetDataTable(string sql)
        {
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            return dt;
        }

        public void CreateTable(string sql)
        {
            using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public void InsertData(string tableName, Dictionary<string, object> data)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"INSERT INTO {tableName} ({string.Join(",", data.Keys)}) VALUES ({string.Join(",", data.Keys.Select(v => $"@{v}"))})", conn))
            {
                foreach (var item in data)
                {
                    cmd.Parameters.AddWithValue($"@{item.Key}", item.Value);
                }

                cmd.ExecuteNonQuery();
            }

        }

        public List<T> SelectData<T>(string tableName, Func<SQLiteDataReader, T> mapFunction)
        {
            List<T> resultList = new List<T>();
            if (conn.State == ConnectionState.Closed)
            {

                conn.Open();  // 연결 열'
            }
            string query = $"SELECT * FROM {tableName}";
            // using 블록을 통해 연결을 안전하게 열고 닫도록 처리
            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T obj = mapFunction(reader);
                        resultList.Add(obj);
                    }
                }
            }
            return resultList;
        }


        public void UpdateData(string tableName, Dictionary<string, object> data, string whereClause)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"UPDATE {tableName} SET {string.Join(",", data.Select(d => $"{d.Key} = @{d.Key}"))} WHERE {whereClause}", conn))
            {
                foreach (var item in data)
                {
                    cmd.Parameters.AddWithValue($"@{item.Key}", item.Value);
                }
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteData(string tableName, string whereClause)
        {
            using (SQLiteCommand cmd = new SQLiteCommand($"DELETE FROM {tableName} WHERE {whereClause}", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
