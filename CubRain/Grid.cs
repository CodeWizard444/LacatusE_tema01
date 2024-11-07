using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace CubRain
{
    /// <summary>
    /// Clasa Grid reprezintă o rețea de coordonate (grid) 3D folosită pentru a desena un sistem de linii și pătrate pe axa Y=0.
    /// Acesta include opțiuni de personalizare pentru dimensiunea rețelei, distanța dintre linii și culorile de fundal și linii.
    /// </summary>
    class Grid
    {
        private int size; // Dimensiunea rețelei (numărul de linii pe fiecare direcție)
        private float spacing; // Distanța dintre linii
        private Color backgroundColor;  // Culoarea de fundal a gridului
        private Color lineColor;  // Culoarea liniilor

        /// <summary>
        /// Constructorul clasei Grid. Permite configurarea dimensiunii rețelei, distanței dintre linii și culorilor.
        /// Dacă nu sunt specificate culorile, se folosesc valori implicite pentru fundal (gri închis) și linii (alb).
        /// </summary>
        /// <param name="size">Dimensiunea rețelei (numărul de pătrate pe fiecare direcție).</param>
        /// <param name="spacing">Distanța dintre fiecare linie.</param>
        /// <param name="backgroundColor">Culoarea de fundal a gridului.</param>
        /// <param name="lineColor">Culoarea liniilor gridului.</param>
        public Grid(int size =10, float spacing=1.0f, Color? backgroundColor = null, Color? lineColor = null)

        {
            this.size = size; // Setează dimensiunea rețelei
            this.spacing = spacing; // Setează distanța dintre linii
            this.backgroundColor = backgroundColor ?? Color.FromArgb(50, 50, 50);  // Culoare fundal (valoare implicită gri închis)
            this.lineColor = lineColor ?? Color.White; // Culoare linii (valoare implicită albă)
        }

        /// <summary>
        /// Desenează gridul pe ecran folosind OpenGL. Acesta desenează pătrate pentru fundal și linii pentru coordonatele rețelei.
        /// </summary>
        public void Draw()
        {
            // Setează culoarea fundalului și începe desenarea pătratelor de fundal
            GL.Color3(backgroundColor);
            GL.Begin(PrimitiveType.Quads);

            // Desenează pătratele de fundal
            for (int x = -size; x < size; x++)
            {
                for (int z = -size; z < size; z++)
                {
                    GL.Vertex3(x * spacing, 0, z * spacing); // Colțul 1 al pătratului
                    GL.Vertex3((x + 1) * spacing, 0, z * spacing); // Colțul 2 al pătratului
                    GL.Vertex3((x + 1) * spacing, 0, (z + 1) * spacing); // Colțul 3 al pătratului
                    GL.Vertex3(x * spacing, 0, (z + 1) * spacing); // Colțul 4 al pătratului
                }
            }

            GL.End(); // Sfârșit desenare pătrate de fundal

            // Setează culoarea liniilor și începe desenarea liniilor de coordonată
            GL.Color3(lineColor);
            GL.Begin(PrimitiveType.Lines);

            // Desenează liniile pe direcția X (orizontal)
            for (int i = -size; i <= size; i++)
            {
                GL.Vertex3(i * spacing, 0, -size * spacing); // Linie de start pe axa Z
                GL.Vertex3(i * spacing, 0, size * spacing); // Linie de sfârșit pe axa Z
            }

            // Desenează liniile pe direcția Z (vertical)
            for (int i = -size; i <= size; i++)
            {
                GL.Vertex3(-size * spacing, 0, i * spacing); // Linie de start pe axa X
                GL.Vertex3(size * spacing, 0, i * spacing); // Linie de sfârșit pe axa X
            }

            GL.End(); // Sfârșit desenare linii
        }
    }
}
