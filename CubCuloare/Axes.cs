using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace CubCuloare
{
    /// <summary>
    /// Reprezintă o clasă care desenează axele 3D într-o fereastră OpenTK.
    /// Acesta va desena axele X, Y și Z într-o scenă 3D.
    /// </summary>
    class Axes
    {
        /// <summary>
        /// Desenează axele X, Y și Z într-o scenă 3D.
        /// Axele vor fi colorate astfel:
        /// - Axă X (roșie),
        /// - Axă Y (verde),
        /// - Axă Z (albastru).
        /// </summary>
        public void DrawAxes()
        {
            // Începem să desenăm linii (axele) folosind OpenGL
            GL.Begin(PrimitiveType.Lines);

            // Desenăm axa X: roșie
            GL.Color3(Color.Red); // Setăm culoarea pentru axa X
            GL.Vertex3(0, 0, 0); // Punctul de început (origine)
            GL.Vertex3(10, 0, 0); // Punctul de final pe axa X

            // Desenăm axa Y: verde
            GL.Color3(Color.Green); // Setăm culoarea pentru axa Y
            GL.Vertex3(0, 0, 0); // Punctul de început (origine)
            GL.Vertex3(0, 10, 0); // Punctul de final pe axa Y

            // Desenăm axa Z: albastru
            GL.Color3(Color.Blue); // Setăm culoarea pentru axa Z
            GL.Vertex3(0, 0, 0); // Punctul de început (origine)
            GL.Vertex3(0, 0, 10); // Punctul de final pe axa Z

            // Terminăm desenarea
            GL.End();
        }

    }
}
