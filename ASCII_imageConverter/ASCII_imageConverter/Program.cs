﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASCII_imageConverter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            OpenImage.OpenFile();
        }
    }
}
