using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ASCII_imageConverter
{
    static class OpenImage
    {
        private const double WIDTH_OFFSET = 1.5;
        private const int MAX_WIDTH = 100;
        public static void OpenFile()
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
                bitmap = ResizeBitmap(bitmap, WIDTH_OFFSET);
                bitmap.ToGrayscale();//convert to black and white

                var converter = new BitmapToAscii(bitmap);
                var rows = converter.Convert();

                foreach(var row in rows)
                    Console.WriteLine(row);

                var rowNegative = converter.ConvertAsNegative();
                File.WriteAllLines("image.txt", rows.Select(r => new string(r)));

                Console.SetCursorPosition(0, 0);
            }
        }

        public static Bitmap ResizeBitmap(Bitmap bitmap, double value)
        {
            var newHeight = bitmap.Height / value * MAX_WIDTH / bitmap.Width;
            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
            {
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));
            }
            return bitmap;
        }
    }
}
