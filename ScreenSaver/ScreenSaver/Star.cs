using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver
{
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public float Map(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }

        public void DrawStar(Star star, int width, int height, Graphics graphics)
        {
            float starSize = Map(star.Z, 0, width, 10, 0);
            float x = Map(star.X / star.Z, 0, 1, 0, width) + width / 2;
            float y = Map(star.Y / star.Z, 0, 1, 0, height) + height / 2;
            graphics.FillEllipse(Brushes.Blue, x, y, starSize, starSize);
        }

        public void MoveStar(Star star, Random random, int width, int height)
        {
            star.Z -= 10;
            if (star.Z < 1)
            {
                star.X = random.Next(-width, width);
                star.Y = random.Next(-height, height);
                star.Z = random.Next(1, width);
            }
        }
    }
}
