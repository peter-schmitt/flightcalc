﻿using System;
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

            // Any calculations possible with the input data?
            bool calculation_possible = false;

            // setting default text values for not calculated values
            this.textBox_resultSpeed.Text = "x";
            this.textBox_resultDistanceTravelled.Text = "x";
            this.textBox_resultTimeTravelled.Text = "x";
            this.textBox_resultROD.Text = "x";
            this.textBox_resultROD3deg.Text = "x";

            // resetting error label
            string errorLabelText = "";
            this.errorLabel.Visibility = Visibility.Hidden;

            if (currentIASset)
            {
                this.textBox_resultSpeed.Text = backend.ToD_ToC_calculations.dp_min(currentIAS).ToString();
            }

            if (currentIASset && currentAltset && targetAltset && targetDistanceset)
            {
                this.textBox_resultSpeed.Text = backend.ToD_ToC_calculations.dp_min(currentIAS).ToString();
                this.textBox_resultROD.Text = backend.ToD_ToC_calculations.calculate_rate_of_descent(currentIAS,currentAlt,targetAlt,targetDistance).ToString();
                calculation_possible = true;
            }

            if (currentAltset && targetAltset && targetRODset)
            {
                this.textBox_resultTimeTravelled.Text = backend.ToD_ToC_calculations.calculate_time_to_target_altitude(currentAlt, targetAlt, targetROD).ToString();
                calculation_possible = true;
            }

            if (currentIASset && currentAltset && targetAltset && targetRODset)
            {
                this.textBox_resultDistanceTravelled.Text = backend.ToD_ToC_calculations.calculate_distance_to_target_altitude(currentIAS, currentAlt, targetAlt, targetROD).ToString();
                calculation_possible = true;
            }

            if (currentIASset)
            {
                this.textBox_resultROD3deg.Text = backend.ToD_ToC_calculations.calculate_rate_of_descent(currentIAS).ToString();
                calculation_possible = true;
            }


            // Error message must only be shown, if nothing can be calculated.
            if (calculation_possible)
            {
                return;
            }
            else
            {
                errorLabelText = "Insufficient Data!";
                this.errorLabel.Content = errorLabelText;
                this.errorLabel.Visibility = Visibility.Visible;
                return;
            }
        }
    }
}
