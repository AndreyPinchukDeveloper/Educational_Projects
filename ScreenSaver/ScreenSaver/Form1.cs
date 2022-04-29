using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenSaver
{
    public partial class Form1 : Form
    {
        private Star[] stars = new Star[1500];
        private Random random = new Random();
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    Z = random.Next(1, pictureBox1.Width)
                };
            }

            timer1.Start();
        }
    }
}
