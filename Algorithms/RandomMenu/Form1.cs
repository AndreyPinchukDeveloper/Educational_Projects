using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandomMenu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            DishesForMenu list = new DishesForMenu();
            InitializeComponent();
            CreateRandomMenu(list);
        }

        private void CreateRandomMenu(DishesForMenu list)
        {
            Random random = new Random();
            label1.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
            label2.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
            label3.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
            label4.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
            label5.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
            label6.Text = list.dishes[random.Next(0, 9)] +
                list.nuts[random.Next(0, 9)] +
                list.fruits[random.Next(0, 9)];
        }
    }
}
