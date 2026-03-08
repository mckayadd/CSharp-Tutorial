using System;
using System.Collections.Generic;
using System.Text;

namespace GatewayMessagingForms;

public class FieldbusGateway
{
    private readonly LoggerService _logger;
    private readonly RobotController _robot;

    public FieldbusGateway(LoggerService logger, RobotController robot)
    {
        _logger = logger;
        _robot = robot;
    }

    public void HandleData(double mmValue)
    {
        double inchValue = mmValue * 0.0393701;
        _logger.Log($"Converting {mmValue:F2}mm to {inchValue:F4}in", LogCategory.Connector);

        _robot.ProcessCommand(inchValue);
    }

    public void RouteFeedback(string status)
    {
        _logger.Log($"Routing Status Back: {status}", LogCategory.Connector);
    }
}
