using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using backend;

namespace flightcalc
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

        private void button_calculate_Click(object sender, RoutedEventArgs e)
        {
            int currentIAS = 0;
            int currentAlt = 0;
            int targetAlt = 0;
            int targetDistance = 0;
            int targetROD = 0;

            bool currentIASset = Int32.TryParse(this.textBox_currentIAS.Text, out currentIAS);
            bool currentAltset = Int32.TryParse(this.textBox_currentAlt.Text, out currentAlt);
            bool targetAltset = Int32.TryParse(this.textBox_targetAlt.Text, out targetAlt);
            bool targetDistanceset = Int32.TryParse(this.textBox_targetDistance.Text, out targetDistance);
            bool targetRODset = Int32.TryParse(this.textBox_targetRateOfDescent.Text, out targetROD);

            string errorLabelText = "";
            this.errorLabel.Visibility = Visibility.Hidden;



            if (currentIASset && currentAltset && targetAltset && targetDistanceset)
            {
                this.textBox_resultSpeed.Text = backend.ToD_ToC_calculations.dp_min(currentIAS).ToString();
                this.textBox_resultROD.Text = backend.ToD_ToC_calculations.calculate_rate_of_descent(currentIAS,currentAlt,targetAlt,targetDistance).ToString();
                return;
            }

            errorLabelText = "Incorrect IAS given.";
            this.errorLabel.Content = errorLabelText;
            this.errorLabel.Visibility = Visibility.Visible;
        }
    }
}
