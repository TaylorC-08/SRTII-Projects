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

namespace Cunningham_Taylor_Csharp4_A2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Taylor Cunningham is the author
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            txtList.Text = "";
            txtLowval.Text = "";
            string[] splitString = dataInput.Text.Split('~');
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
            //Error check
            if (errors == true)
            {
                txtList.Text = "Errors in the inserted data. Please try again.";
                txtrandNum.Text = "";
                txtLowval.Text = "";
            }
            else
            {
                //Loop to output every other number
                for (int i=0; i < n; i++)
                {
                    txtList.Text += data[i].ToString() + "\n";
                    i++;
                }
                //Sort array and output smallest number with prepend
                Array.Sort(data);
                txtLowval.Text = "I completed the assignment: " + data[0].ToString();
            }
        }
        private void Rand_Click(object sender, RoutedEventArgs e)
        {
            txtrandNum.Text = "";
            string[] splitString = dataInput.Text.Split('~');
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
            //Error check
            if (errors == true)
            {
                txtList.Text = "Errors in the inserted data. Please try again.";
                txtrandNum.Text = "";
                txtLowval.Text = "";
            }
            else
            //Selects random number from list
            {
                double random = 0;
                var rand = new Random();
                int tempIndex = rand.Next(data.Length);
                random = data[tempIndex];
                txtrandNum.Text = random.ToString();
            }
        }
    }
}