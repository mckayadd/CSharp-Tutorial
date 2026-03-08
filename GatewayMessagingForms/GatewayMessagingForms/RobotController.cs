using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayMessagingForms;

public class RobotController
{
    private readonly LoggerService _logger;
    public event Action<string> OnFeedbackReady;

    public RobotController(LoggerService logger) => _logger = logger;

    public void ProcessCommand(double coordinateInInches)
    {
        _logger.Log($"Command Received: Move to {coordinateInInches:F4} in", LogCategory.Robot);

        // Simulate mechanical movement
        Thread.Sleep(1500);

        string statusUpdate = coordinateInInches > 5.0 ? "ERR_OUT_OF_REACH" : "SUCCESS_POS_REACHED";
        OnFeedbackReady?.Invoke(statusUpdate);
    }
}
