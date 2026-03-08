using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayMessagingForms;

public enum LogCategory { Camera, Connector, Robot }
public class LoggerService
{
    public event Action<string, LogCategory> OnLogRequest;

    public void Log(string message, LogCategory category)
    {  
        OnLogRequest?.Invoke(message, category);
    }

}
