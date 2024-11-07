using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace CubRain
{
    /// <summary>
    /// Clasa Axes este responsabilă pentru desenarea axelor X, Y și Z într-un sistem 3D.
    /// </summary>
    class Axes
    {
        private Color xAxisColor;
        private Color yAxesColor;
        private Color zAxisColor;
        private float axisLength;

        /// <summary>
        /// Inițializează o instanță a clasei <see cref="Axes"/> cu culorile și lungimea axelor specificate.
        /// </summary>
        /// <param name="length">Lungimea axelor (valoare implicită: 25.0f).</param>
        public Axes(float length=25.0f)
        {
            // Setează culorile axelor
            xAxisColor = Color.Red;   // Culoare pentru axa X
            yAxesColor = Color.Green; // Culoare pentru axa Y
            zAxisColor = Color.Blue;  // Culoare pentru axa Z

            // Setează lungimea axelor
            axisLength = length;
        }

        /// <summary>
        /// Desenează axele X, Y și Z în spațiul 3D.
        /// </summary>
        public void Draw()
        {
            GL.LineWidth(2.0f);

            GL.Color3(xAxisColor);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(-axisLength, 0, 0);
            GL.Vertex3(axisLength, 0, 0);
            GL.End();

            GL.Color3(yAxesColor);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, -axisLength, 0);
            GL.Vertex3(0, axisLength, 0);
            GL.End();

            GL.Color3(zAxisColor);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex3(0, 0, -axisLength);
            GL.Vertex3(0, 0, axisLength);
            GL.End();

            GL.LineWidth(1.0f);
        }
    }
}
