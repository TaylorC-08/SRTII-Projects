using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Security;
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
using Microsoft.Win32;
namespace Cunningham_Taylor_Csharp3_A2
{
    //Taylor Cunningham is the author
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            //Takes text from txt file
            string temptext = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    temptext =(sr.ReadToEnd());
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
            //Splits the numbers from the txt file
            string[] splitString = temptext.Split(',');
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
                //Checks that all inputs are numbers to prevent errors
                else
                {
                    errors = true;
                }
            }
            //Store numbers from list to an array
            int n = 0;
            double[] data = new double[numNums];
            for (int i = 0; i < splitString.Length; i++)
            {
                if (double.TryParse(splitString[i], out result))
                {
                    data[n] = result;
                    n++;
                }
            }
            //Declare variables for random samples
            var rand = new Random();
            int numOfTrials;
            int sampleSize;
            //Checks inputs for errors
            if (int.TryParse(Trials.Text, out numOfTrials))
            { }
            else
            {
                errors = true;
            }
            if (numOfTrials == 1)
            {
                errors = true;
            }
            if (int.TryParse(Size.Text, out sampleSize))
            { }
            else
            {
                errors = true;
            }
            //Displays error text if there are errors and clears the inputs if there are no errors before calculation
            if (errors == true)
            {
                txtSamples.Text = "Errors in the list. Please try again.";
                txtMean.Text = "";
                return;
            }
            else
            {
                txtSamples.Text = "";
                txtMean.Text = "\n";
            }
            //Calculates the random samples and their means
            for (int j = 0; j < numOfTrials; j++)
            {
                double[] templist = new double[sampleSize];
                double[] means = new double[numOfTrials];
                string tempNumbers = "";
                string meantxt = "";
                for (int i = 0; i < sampleSize; i++)
                {
                    int tempIndex = rand.Next(data.Length);
                    templist[i] = data[tempIndex];
                    tempNumbers += (templist[i].ToString() + ",");
                }
                means[j] = mean(templist);
                meantxt += (means[j].ToString() + "\n");
                txtSamples.Text += "\n" + tempNumbers;
                //Output the mean of all samples
                txtMean.Text += meantxt;
            }
            //Copy output of means to the clipboard for histograms
            Clipboard.SetData(DataFormats.Text, (Object)txtMean.Text);
        }
        //Method to calculate sum
        double sum(double[] numbers)
        {
            double sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
        //Method to calculate mean
        double mean(double[] numbers)
        {
            double mean = 0;
            mean = (sum(numbers)) / numbers.Length;
            return mean;
        }
    }
}