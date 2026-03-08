using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayMessagingForms;

public enum LogCategory { Camera, Connector, Robot }

public class LoggerService
{
    public event Action<string, LogCategory> OnLogRequest;
    public DatabaseManager DbManager { get; }

    public LoggerService()
    {
        DbManager = new DatabaseManager();
    }
    public void Log(string message, LogCategory category)
    {  
        // Send message to the UI (Event)
        OnLogRequest?.Invoke(message, category);

        // Save message into the DB (saving in the background for improved performance)
        Task.Run(() => DbManager.SaveLog(message, category.ToString()));
    }

}
