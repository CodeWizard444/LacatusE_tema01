using System;
using System.IO;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace TriunghiCuCuloare
{
    class Program : GameWindow
    {
        private float rotationX = 0.0f;
        private float rotationY = 0.0f;
        private Vector4[] colors = new Vector4[3];  // Culori pentru fiecare vertex
        private Vector3[] vertices;  // Stocare coordonate triunghi
        private int selectedVertex = 0;  // Vertexul selectat pentru modificare

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0.1f, 0.2f, 0.3f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
            IncarcaTriunghi("triunghi.txt");  // Încarcă coordonatele triunghiului

            // Initializare culori pentru fiecare vertex (RGB)
            colors[0] = new Vector4(1.0f, 0.0f, 0.0f, 1.0f); // Rosu pentru primul vertex
            colors[1] = new Vector4(0.0f, 1.0f, 0.0f, 1.0f); // Verde pentru al doilea vertex
            colors[2] = new Vector4(0.0f, 0.0f, 1.0f, 1.0f); // Albastru pentru al treilea vertex
        }

        private void IncarcaTriunghi(string filename)
        {
            var lines = File.ReadAllLines(filename);
            vertices = new Vector3[3];
            for (int i = 0; i < 3; i++)
            {
                var coords = lines[i].Split(' ');
                vertices[i] = new Vector3(
                    float.Parse(coords[0]),
                    float.Parse(coords[1]),
                    float.Parse(coords[2])
                );
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 100.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            if (Keyboard[Key.Escape])
                Exit();

            // Selectare vertex pentru ajustare
            if (Keyboard[Key.Number1]) selectedVertex = 0;
            if (Keyboard[Key.Number2]) selectedVertex = 1;
            if (Keyboard[Key.Number3]) selectedVertex = 2;

            // Modificare culori RGB ale vertexului selectat
            if (Keyboard[Key.R]) colors[selectedVertex].X = Math.Min(colors[selectedVertex].X + 0.05f, 1.0f);  // Creste valoarea roșu
            if (Keyboard[Key.G]) colors[selectedVertex].Y = Math.Min(colors[selectedVertex].Y + 0.05f, 1.0f);  // Creste valoarea verde
            if (Keyboard[Key.B]) colors[selectedVertex].Z = Math.Min(colors[selectedVertex].Z + 0.05f, 1.0f);  // Creste valoarea albastru

            // Afiseaza valorile RGB pentru fiecare vertex in consola
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Vertex {i + 1}: R={colors[i].X:F2}, G={colors[i].Y:F2}, B={colors[i].Z:F2}");
            }
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            rotationX += e.YDelta * 0.2f;
            rotationY += e.XDelta * 0.2f;
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.UnitZ * 5, Vector3.Zero, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            GL.Rotate(rotationX, 1.0f, 0.0f, 0.0f);
            GL.Rotate(rotationY, 0.0f, 1.0f, 0.0f);

            // Desenează=a triunghiul cu culori per vertex
            GL.Begin(PrimitiveType.Triangles);
            for (int i = 0; i < 3; i++)
            {
                GL.Color4(colors[i]);
                GL.Vertex3(vertices[i]);
            }
            GL.End();

            SwapBuffers();
        }

        [STAThread]
        static void Main(string[] args)
        {
            using (Program game = new Program())
            {
                game.Run(30.0, 0.0);
            }
        }
    }
}
