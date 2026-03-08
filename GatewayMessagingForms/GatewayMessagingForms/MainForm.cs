using System.ComponentModel;

namespace GatewayMessagingForms;

public partial class MainForm : Form
{
    private CancellationTokenSource _cts;
    private LoggerService _logger;
    private VisionSystem _vision;
    private RobotController _robot;
    private FieldbusGateway _gateway;

    public MainForm()
    {
        InitializeComponent();
        InitializeBusinessLogic();
    }

    private void InitializeBusinessLogic()
    {
        // 1. Instantiate services
        _logger = new LoggerService();
        _robot = new RobotController(_logger);
        _gateway = new FieldbusGateway(_logger, _robot);
        _vision = new VisionSystem(_logger);

        // 2. Wire up Events
        _logger.OnLogRequest += (msg, cat) => AppendLog(msg, GetTargetTextBox(cat));
        _vision.OnDataCaptured += (mm) => _gateway.HandleData(mm);
        _robot.OnFeedbackReady += (status) =>
        {
            _gateway.RouteFeedback(status);
            AppendLog($"Received Ack: {status}", txtCameraLog);
        };
    }

    private TextBox GetTargetTextBox(LogCategory cat) => cat switch
    {
        LogCategory.Camera => txtCameraLog,
        LogCategory.Connector => txtConnectorLog,
        LogCategory.Robot => txtRobotLog,
        _ => txtConnectorLog
    };

    private void btnStartSystem_Click(object sender, EventArgs e)
    {
        _cts = new CancellationTokenSource();
        btnStartSystem.Enabled = false;
        btnEndSystem.Enabled = true;
        _logger.Log("System Initializing...", LogCategory.Connector);

        Task.Run(() => _vision.Run(_cts.Token));
    }

    private void btnEndSystem_Click(object sender, EventArgs e)
    {
        _cts?.Cancel();
        btnStartSystem.Enabled = true;
        btnEndSystem.Enabled = false;
        _logger.Log("System Stopping...", LogCategory.Connector);
    }

    private void AppendLog(string message, TextBox target)
    {
        if (target.InvokeRequired)
        {
            target.BeginInvoke(new Action(() => AppendLog(message, target)));
        }
        else
        {
            target.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
            target.SelectionStart = target.Text.Length;
            target.ScrollToCaret();
        }
    }
}