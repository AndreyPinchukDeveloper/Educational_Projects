using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NewLife
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private int resolution;
        private bool[,] field;
        private int rows;
        private int columns;


        public Form1()
        {
            InitializeComponent();
            //numResolution.Value = 0;
        }

        private void StartGame()
        {
            if (timer1.Enabled)
            {
                return;//exit from this method

            }
            numResolution.Enabled = false;
            numDensity.Enabled = false;
            resolution = (int)numResolution.Value;
            rows = pictureBox1.Width / resolution;
            columns = pictureBox1.Height / resolution;
            field = new bool[rows, columns];

            Random random = new Random();
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    field[x, y] = random.Next((int)numDensity.Value) == 0;
                }
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
        }

        private void StopGame()
        {
            if (timer1.Enabled)
            {
                return;
            }
            timer1.Stop();
            numResolution.Enabled = false;
            numDensity.Enabled = false;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void NextGeneration()
        {
            graphics.Clear(Color.Black);
            var newField = new bool[rows, columns];
            
            for (int x = 0; x < rows; x++)
            {
                for (int y = 0; y < columns; y++)
                {
                    var neighborsCount = CountNeighbors(x, y);
                    var hasLife = field[x, y];

                    if (!hasLife & neighborsCount == 3)
                    {
                        newField[x, y] = true;
                    }
                    else if (hasLife && (neighborsCount < 2 || neighborsCount > 3))
                    {
                        newField[x, y] = false;
                    }
                    else
                    {
                        newField[x, y] = field[x, y];
                    }

                    if (hasLife)
                    {
                        graphics.FillRectangle(Brushes.Crimson, x * resolution, y * resolution, resolution, resolution);
                    }
                }
            }
            field = newField;
            pictureBox1.Refresh();
        }

        private int CountNeighbors(int x, int y)
        {
            return 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            StopGame();
        }
    }
}
