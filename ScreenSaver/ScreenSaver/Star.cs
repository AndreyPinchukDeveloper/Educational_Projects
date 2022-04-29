using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSaver
{
    public class Star
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        private float Map(float n, float start1, float stop1, float start2, float stop2)
        {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }
}
