namespace GatewayMessagingForms
{
    public partial class MainForm : Form
    {

        // Delegate for thread-safe UI updates
        delegate void LogUpdateDelegate(string message, TextBox target);

        public MainForm()
        {
            InitializeComponent();
        }

        private async void btnStartSystem_Click(object sender, EventArgs e)
        {
            btnStartSystem.Enabled = false;
            AppendLog("System Initializing...", txtConnectorLog);

            // Start messaging
            Task.Run(() => RunCameraComponent());
 
        }

        // --- COMPONENT A: Vision System ---
        private void RunCameraComponent() 
        { 
            Random rnd = new Random();
            int i = 0;
            while (true)
            {
                // Simulate part detection (double in millimeters)
                double detectedPosMm = rnd.Next(50, 200) + rnd.NextDouble();
                AppendLog($"[Camera] Part detected at: {detectedPosMm:F2} mm", txtCameraLog);
                // Send raw data to the Connector
                GatewayConnector(detectedPosMm);

                Thread.Sleep(4000); // Wait for next scan cycle
                //i++;
                //if (i == 5) break;
            }
        }

        // --- THE CONNECTOR: Fieldbus Gateway (Data Translator) ---
        private void GatewayConnector(object rawData) 
        {
            if (rawData is double mmValue)
            {
                // Logic: Convert mm to inches for the legacy Robot Controller
                double inchValue = mmValue * 0.0393701;

                AppendLog($"[Gateway] Converting {mmValue:F2}mm to {inchValue:F4}in", txtConnectorLog);

                // Route the converted data to the Robot Component
                RunRobotComponent(inchValue);
            }
        }


        // --- COMPONENT B: Robot ---
        private void RunRobotComponent(double coordinateInInches)
        {
            AppendLog($"[Robot] Command Received: Move to {coordinateInInches:F4} in", txtRobotLog);

            // Simulate mechanical movement delay
            Thread.Sleep(1500);

            // Logic: Process data and return a string-based acknowledgment
            string statusUpdate = coordinateInInches > 5.0 ? "ERR_OUT_OF_REACH" : "SUCCESS_POS_REACHED";

            ReturnFeedbackToGateway(statusUpdate);
        }

        private void ReturnFeedbackToGateway(string status)
        {
            AppendLog($"[Gateway] Routing Status Back: {status}", txtConnectorLog);
            AppendLog($"[Camera] Received Ack: {status}", txtCameraLog);
        }

        // --- HELPER: Thread-safe UI Logging ---
        private void AppendLog(string message, TextBox target)
        {
            // Check if we are on a background thread
            if (target.InvokeRequired)
            {
                target.Invoke(new LogUpdateDelegate(AppendLog), message,  target);
            }
            else
            {
                target.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
                target.SelectionStart = target.Text.Length;
                target.ScrollToCaret(); // Auto-scroll to latest log
            }
        }

    }
}
