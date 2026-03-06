using System.Windows;

namespace MultiThreadWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            // UI preparation: disable button, show progressbar
            btnCalculate.IsEnabled = false;
            pbStatus.Visibility = Visibility.Visible;
            txtResult.Text = "Calculating route...";

            // Use thread for the long process
            string result = await Task.Run(() => LongRunningCalculation());

            //string result = LongRunningCalculation(); // bad practice: blocking the flow

            // UI update
            txtResult.Text = $"Result: {result}";
            pbStatus.Visibility = Visibility.Collapsed;
        }

        private string LongRunningCalculation()
        {

            System.Threading.Thread.Sleep(10000);
            return "Calculated route: [Home -> Work -> Home]";
        }

    }
}