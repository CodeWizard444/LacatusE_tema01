using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubCuloare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Window3D window = new Window3D(800, 600))
            {
                window.Run(60.0); // Rulează aplicația la 60 FPS
            }
        }
    }
}
