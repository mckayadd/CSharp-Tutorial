namespace MultiThreadForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnCalculate_Click(object sender, EventArgs e)
        {
            // Prepare UI
            btnCalculate.Enabled = false;
            pbStatus.Visible = true;
            lblResult.Text = "Calculating... (Please wait!)";

            // Assign calculation to worker thread
            string result = await Task.Run(() => LongRunningCalculation());

            // UI thread finalizes:
            lblResult.Text = $"Result : {result}";
            pbStatus.Visible = false;
            btnCalculate.Enabled = true;
        }
        
        private string LongRunningCalculation()
        {
            System.Threading.Thread.Sleep(10000);
            return "Optimized route: [Depo -> Assembly -> Shipment]";
        }


    }
}
