using Microsoft.Data.Sqlite; // Yeni kütüphane
using System.IO;

public class DatabaseManager
{
    private string _dbPath = "SystemLogs.db";
    private string _connectionString => $"Data Source={_dbPath};"; // "Version=3"e gerek yok

    public DatabaseManager()
    {
        if (!File.Exists(_dbPath))
        {
            // Microsoft.Data.Sqlite dosyayı bağlantı açıldığında otomatik oluşturur
            using (var conn = new SqliteConnection(_connectionString))
            {
                conn.Open();
                string sql = @"CREATE TABLE Logs (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Timestamp DATETIME DEFAULT CURRENT_TIMESTAMP,
                                Category TEXT,
                                Message TEXT
                             )";
                using (var cmd = new SqliteCommand(sql, conn)) { cmd.ExecuteNonQuery(); }
            }
        }
    }

    public void SaveLog(string message, string category)
    {
        using (var conn = new SqliteConnection(_connectionString))
        {
            conn.Open();
            string sql = "INSERT INTO Logs (Category, Message) VALUES (@cat, @msg)";
            using (var cmd = new SqliteCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@cat", category);
                cmd.Parameters.AddWithValue("@msg", message);
                cmd.ExecuteNonQuery();
            }
        }
    }
}