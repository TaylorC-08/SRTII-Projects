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

namespace Cunningham_Taylor_Csharp2_A2
    //Taylor Cunningham is the author
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
        private void calculateClick(object sender, RoutedEventArgs e)
        {
            string[] splitString = txtdata.Text.Split(',');
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
            //Checks to see if the list is too small to have a standard deviation to prevent errors
            if (data.Length < 2)
            {
                errors = true;
            }
            if (errors == true)
            {
                txtScrolling.Text = "Errors in the list. Either a non-numerical value has been entered, or too few numbers are present. Please try again.";
            }
            else
            {
                //sorts array in ascending numeriacal order
                Array.Sort(data);
                //define variables
                double STDEV = 0;
                double sum = 0;
                double summnation = 0;
                //Calculate the sum of the list
                for (int i = 0; i < n; i++)
                {
                    sum += data[i];
                }
                //Calculate mean of the list
                double mean = sum / numNums;
                //Calculate standard deviation of the list
                for (int i = 0; i < n; i++)
                {
                    summnation += Math.Pow(data[i] - mean, 2);
                    STDEV = Math.Sqrt(summnation / (data.Length));
                }
                //Takes data and removes repeated values as there is no need to display them multiple times
                double[] data2 = data.Distinct().ToArray();
                //Count number of numbers in data without repeats
                double len = data2.Length;
                //Calculate Z-scores of the list arranged from least to greatest
                double[] zScores = new double[numNums];
                for (int i = 0; i < len; i++)
                {
                    zScores[i] = (data2[i] - mean) / STDEV;
                }
                //Starts the list of Z scores; out of loop to prevent repeating it
                txtScrolling.Text = "Z Scores: ";
                //loop through adding all z scores to the text block 
                for (int i = 0; i < len; i++)
                {
                    txtScrolling.Text = txtScrolling.Text + Environment.NewLine + data2[i] + ": " + zScores[i];
                }
                //Stem and leaf plot
                txtScrolling.Text = txtScrolling.Text + Environment.NewLine + "Stem and leaf plot: ";
                int num = 0;
                int prevStem;
                int Leaf = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    int Stem = 0;
                    num = (int)data[i];
                    prevStem = num / 10;
                    Leaf = num % 10;
                    txtScrolling.Text = txtScrolling.Text + Environment.NewLine + prevStem + " | " + Leaf;
                    for (int j =i+1; j< data.Length; j++)
                    {
                        num =(int) data[j];
                        Stem = num / 10;
                        Leaf = num % 10;
                        if (Stem == prevStem)
                        {
                            txtScrolling.Text = txtScrolling.Text + " " + Leaf;
                            i++;
                        }
                        
                    }
                }
            }
        }
    }
}