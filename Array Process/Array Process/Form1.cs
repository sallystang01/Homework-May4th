using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Array_Process
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void ReadScores(List<int> scoresList)
        {
            try
            {
                // Open the TestScores.text file.
                StreamReader inputFile = File.OpenText("TestScores.txt");

                // Read the scores into the list

                while (!inputFile.EndOfStream)
                {
                    scoresList.Add(int.Parse(inputFile.ReadLine()));
                }

                // Close the file
                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // The DisplayScores method displays the contents of the 
        // scoresList parameter in the ListBox control
        private void DisplayScores(List<int> scoresList)
        {
            foreach (int Score in scoresList)
            {
                listBox1.Items.Add(Score);
            }
        }

        // The Average method returns the average of the values
        // in the parameter
        private double Average(List<int> scoresList)
        {
            int counter = 0; // Counter variable 
            double average; // to hold the average

            // Calculate the toal of the socres
            foreach (int score in scoresList)
            {
                counter += score;
            }

            // Calculate the average of the scores
            average = (double)counter / scoresList.Count;

            // return the average
            return average;
        }

        // The AvoveAverage method returns the number of
        // abover average scores in the scores list
        private int AboveAverage(List<int> scoresList)
        {
            int numAbove = 0;       // Counter

            // Get the average score.
            double avg = Average(scoresList);

            // Count the number of above average scores
            foreach (int score in scoresList)
            {
                if (score > avg)
                {
                    numAbove++;
                }
            }
            // Return the numberof above average scores
            return numAbove;
        }

        // Below average method returns the number of 
        // below average scores in socresList
        private int BelowAverage(List<int> scoresList)
        {
            int numBelow = 0; // counter

            // Get the average score
            double avg = Average(scoresList);

            // Count the number of below average scores
            foreach (int score in scoresList)
            {
                if (score < avg)
                {
                    numBelow++;
                }
            }
            // Return the numbre of below average scores
            return numBelow;
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {

            double averageScore;        // To hold the average score
            int numAboveAverage;        // number of above average scores
            int numBelowAverage;        // Numbr of below average scores

            // Create a list to hold the scores
            List<int> scoresList = new List<int>();

            // Read the scores from the filed into the list
            ReadScores(scoresList);

            // Display the scores
            DisplayScores(scoresList);

            // Display the average score
            averageScore = Average(scoresList);
            lblAverage.Text = averageScore.ToString();

            // Display the number of above average scores 
            numAboveAverage = AboveAverage(scoresList);
            lblAboveAverage.Text = numAboveAverage.ToString();

            // Display the number of below average scores
            numBelowAverage = BelowAverage((scoresList));
            lblBelowAverage.Text = numBelowAverage.ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Closes applciation
            Application.Exit();
        }
    }
}

