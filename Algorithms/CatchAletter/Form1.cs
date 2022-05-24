using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatchAletter
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if (listBox1.Items.Count>7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("The game is over!");
                timer1.Stop();
                
            }
        }

        //new method to start new game

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                int time = timer1.Interval;

                time = time > 700 ? time -= 10 : time;
                time = time > 250 ? time -= 7 : time;
                time = time > 100 ? time -= 2 : time;

                difficultyProgressBar.Value = 800 - time;
                stats.Update(true);
            }
            else
            {
                stats.Update(false);
            }
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed: " + stats.Missed;
            accuracyLabel.Text = "Accuracy: " + stats.Accuracy +" %";
            totalLabel.Text = "Total: " + stats.Accuracy;
        }
    }
}
