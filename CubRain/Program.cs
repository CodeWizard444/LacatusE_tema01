using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubRain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Window3D window = new Window3D())
            {
                window.Run(60.0); // Rulează la 60 FPS
            }
        }
    }
}
