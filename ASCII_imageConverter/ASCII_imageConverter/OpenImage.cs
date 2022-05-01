using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ASCII_imageConverter
{
    class OpenImage
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"
        };

        Console.WriteLine("Press enter to start ...\n");

            while (true)
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();
                var bitmap = new Bitmap(openFileDialog.FileName);
        bitmap = ResizeBitmap(bitmap);
    }
}
}
