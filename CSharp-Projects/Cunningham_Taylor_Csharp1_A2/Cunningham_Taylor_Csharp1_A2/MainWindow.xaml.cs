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
namespace Cunningham_Taylor_Csharp1_A2
    // Taylor Cunningham is the author
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
        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            {
                string[] splitString = txtInput.Text.Split(',');
                int numNums = 0;
                double result;
                bool errors = false;
                //Determine the number of numbers in the list
                for (int i = 0; i < splitString.Length; i++)
                {
                    if (double.TryParse(splitString[i], out result))
                    {
                        numNums++;
                    }
                    else
                    {
                        errors = true;
                    }
                }
                //Store numbers from list to an array
                int n = 0;
                double[] doubleResult = new double[numNums];
                for (int i = 0; i < splitString.Length; i++)
                {
                    if (double.TryParse(splitString[i], out result))
                    {
                        doubleResult[n] = result;
                        n++;
                    }
                }
                //sorts array in ascending numeriacal order
                Array.Sort(doubleResult);
                //Checks if array has no length to prevent crash from calculating with no data on text change
                if (doubleResult.Length == 0)
                {
                    sumOutput.Text = "";
                    meanOutput.Text = "";
                    medianOutput.Text = "";
                    minOutput.Text = "";
                    maxOutput.Text = "";
                    rangeOutput.Text = "";
                    STDEVOutput.Text = "";
                    modeOutput.Text = "";
                }
                else
                {
                    {
                        //define variables for stats
                        double min = 0;
                        double max = 0;
                        double median = 0;
                        double range = 0;
                        double STDEV = 0;
                        double sum = 0;
                        double summnation = 0;
                        //Calculate the sum of the list
                        for (int i = 0; i < n; i++)
                        {
                            sum += doubleResult[i];
                        }
                        //Calculate mean of the list
                        double mean = sum / numNums;
                        //Calculate the min, max, and range of the list
                        min = doubleResult[0];
                        max = doubleResult[doubleResult.Length - 1];
                        range = max - min;
                        //calculate the median of the list
                        if (doubleResult.Length % 2 == 0)
                        {
                            median = (doubleResult[doubleResult.Length / 2] + doubleResult[(doubleResult.Length / 2) - 1]) / 2;
                        }
                        else
                        {
                            median = doubleResult[doubleResult.Length / 2];
                        }
                        //Calculate standard deviation of the list
                        for (int i = 0; i < n; i++)
                        {
                            summnation += Math.Pow(doubleResult[i] - mean, 2);
                            STDEV = Math.Sqrt(summnation / (doubleResult.Length - 1));
                        }
                        //declare variables needed for mode calculation
                        double high = 0;
                        double highval = 0;
                        double currentval = 0;
                        bool mode = false;
                        //Calculate the mode of the list
                        for (int i = 0; i < doubleResult.Length; i++)
                        {
                            currentval = 0;
                            for (int j = 0; j < doubleResult.Length; j++)
                            {
                                if (doubleResult[j] == doubleResult[i])
                                {
                                    currentval++;
                                }
                                if (currentval > highval)
                                {
                                    highval = currentval;
                                    high = doubleResult[i];
                                    mode = true;
                                }
                                // Checks if there is no mode for the data
                                else if (currentval == highval & doubleResult[i] != high)
                                {
                                    mode = false;
                                }
                            }
                        }
                        //Display if errors are in the input and clear outputs if there is errors
                        if (errors == true)
                        {
                            textErrors.Text = "Errors in the list. Please try again.";
                            sumOutput.Text = "";
                            meanOutput.Text = "";
                            medianOutput.Text = "";
                            minOutput.Text = "";
                            maxOutput.Text = "";
                            rangeOutput.Text = "";
                            STDEVOutput.Text = "";
                            modeOutput.Text = "";
                        }
                        //Display outputs if there is no errors in the input
                        else
                        {
                            textErrors.Text = "";
                            sumOutput.Text = "Sum: " + sum.ToString();
                            meanOutput.Text = "Mean: " + mean.ToString();
                            medianOutput.Text = "Median: " + median.ToString();
                            minOutput.Text = "Minimum: " + min.ToString();
                            maxOutput.Text = "Maximum: " + max.ToString();
                            rangeOutput.Text = "Range: " + range.ToString();
                            //Checks to see if the array only has 1 value, since there is no deviation or mode unless there is multiple values
                            if (doubleResult.Length == 1)
                            {
                                STDEVOutput.Text = "No Standard deviation";
                                modeOutput.Text = "No Mode";
                            }
                            else
                            {
                                STDEVOutput.Text = "Sample Standard Deviation: " + STDEV.ToString();
                                //Checks to see if there is a mode of the data to display "No Mode" if there is no true mode
                                if (mode == true)
                                {
                                    modeOutput.Text = "Mode: " + high.ToString();
                                }
                                else
                                {
                                    modeOutput.Text = "No Mode";
                                }
                            }
                        }
                    }
                }
            } 
        }
    }
}