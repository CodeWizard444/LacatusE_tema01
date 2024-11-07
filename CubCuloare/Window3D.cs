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
    public class Window3D : GameWindow
    {
        private Axes axes; // Obiectul care gestionează desenarea axelor
        private Cube cube; // Obiectul care reprezintă cubul 3D
        private bool[] keysPressed = new bool[8]; // Array pentru urmărirea stării tastelor apăsate

        /// <summary>
        /// Constructorul clasei Window3D, care inițializează fereastra 3D și obiectele necesare.
        /// </summary>
        /// <param name="width">Lățimea ferestrei.</param>
        /// <param name="height">Înălțimea ferestrei.</param>
        public Window3D(int width, int height) : base(width, height, GraphicsMode.Default, "Cub 3d cu control al culorilor")
        {
            VSync = VSyncMode.On; // Activează sincronizarea verticală pentru a evita flicker-ul
            axes = new Axes(); // Inițializarea obiectului pentru axele coordonate
            cube = new Cube("cub.txt"); // Inițializarea cubului, citind coordonatele dintr-un fișier

            DisplayHelp(); // Afișează ajutorul pe consolă
        }

        /// <summary>
        /// Metoda care se execută la încărcarea ferestrei.
        /// Se setează culoarea fundalului și se activează testul de adâncime.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.CornflowerBlue); // Setare culoare fundal
            GL.Enable(EnableCap.DepthTest);      // Permite adâncimea pentru 3D
        }

        /// <summary>
        /// Metoda care se execută atunci când fereastra este redimensionată.
        /// Se ajustează raportul de aspect și matricea de proiecție.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height); // Setează viewport-ul pentru a se potrivi dimensiunii ferestrei

            // Configurare Proiecție
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            float aspectRatio = Width / (float)Height; // Calculăm raportul de aspect
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45), aspectRatio, 0.1f, 100.0f);
            GL.LoadMatrix(ref projection); // Setează matricea de proiecție
        }

        /// <summary>
        /// Metoda care se execută pentru fiecare cadru de actualizare.
        /// Verifică starea tastelor și realizează acțiuni corespunzătoare.
        /// </summary>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (Keyboard.GetState().IsKeyDown(Key.Escape))
                Exit(); // Închide aplicația dacă se apasă Escape

            KeyboardState input = Keyboard.GetState();

            // Verificăm dacă fiecare tastă este apăsată și dacă nu a fost deja procesată
            if (input.IsKeyDown(Key.Number1) && !keysPressed[0])
            {
                cube.AdjustVertexColor(0, Color.Red);
                keysPressed[0] = true;  // Setăm flag-ul că tasta 1 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number2) && !keysPressed[1])
            {
                cube.AdjustVertexColor(1, Color.Green);
                keysPressed[1] = true;  // Setăm flag-ul că tasta 2 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number3) && !keysPressed[2])
            {
                cube.AdjustVertexColor(2, Color.Blue);
                keysPressed[2] = true; // Setăm flag-ul că tasta 3 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number4) && !keysPressed[3])
            {
                cube.AdjustVertexColor(3, Color.Yellow);
                keysPressed[3] = true; // Setăm flag-ul că tasta 4 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number5) && !keysPressed[4])
            {
                cube.AdjustVertexColor(4, Color.Cyan);
                keysPressed[4] = true; // Setăm flag-ul că tasta 5 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number6) && !keysPressed[5])
            {
                cube.AdjustVertexColor(5, Color.Magenta);
                keysPressed[5] = true; // Setăm flag-ul că tasta 6 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number7) && !keysPressed[6])
            {
                cube.AdjustVertexColor(6, Color.Orange);
                keysPressed[6] = true; // Setăm flag-ul că tasta 7 a fost apăsată
            }
            if (input.IsKeyDown(Key.Number8) && !keysPressed[7])
            {
                cube.AdjustVertexColor(7, Color.Purple);
                keysPressed[7] = true; // Setăm flag-ul că tasta 8 a fost apăsată
            }

            // Resetăm flag-urile când tasta este eliberată
            if (input.IsKeyUp(Key.Number1)) keysPressed[0] = false;
            if (input.IsKeyUp(Key.Number2)) keysPressed[1] = false;
            if (input.IsKeyUp(Key.Number3)) keysPressed[2] = false;
            if (input.IsKeyUp(Key.Number4)) keysPressed[3] = false;
            if (input.IsKeyUp(Key.Number5)) keysPressed[4] = false;
            if (input.IsKeyUp(Key.Number6)) keysPressed[5] = false;
            if (input.IsKeyUp(Key.Number7)) keysPressed[6] = false;
            if (input.IsKeyUp(Key.Number8)) keysPressed[7] = false;

            // Controlul transparenței (exemplu: T pentru ajustare)
            if (input.IsKeyDown(Key.T))
                cube.AdjustTransparency(0.5f); // Setează transparența la 50%
        }

        /// <summary>
        /// Metoda care se execută pentru a reda fiecare cadru grafic.
        /// Se desenează scena, inclusiv axele și cubul.
        /// </summary>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // Curăță buffer-ul de culoare și adâncime

            // Configurare Camera
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            Matrix4 camera = Matrix4.LookAt(new Vector3(10, 10, 10), Vector3.Zero, Vector3.UnitY); // Poziționează camera
            GL.LoadMatrix(ref camera); // Aplică matricea camerei

            // Desenare Axele Pozitive folosind clasa Axes
            axes.DrawAxes();

            cube.Draw();

            SwapBuffers(); // Încărcarea imaginii desenate


        }

        /// <summary>
        /// Afișează informațiile despre controlul aplicației în consolă.
        /// </summary>
        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" 1 - Schimbă culoarea vârfului 0 în roșu");
            Console.WriteLine(" 2 - Schimbă culoarea vârfului 1 în verde");
            Console.WriteLine(" 3 - Schimbă culoarea vârfului 2 în albastru");
            Console.WriteLine(" 4 - Schimbă culoarea vârfului 3 în galben");
            Console.WriteLine(" 5 - Schimbă culoarea vârfului 4 în cyan");
            Console.WriteLine(" 6 - Schimbă culoarea vârfului 5 în magenta");
            Console.WriteLine(" 7 - Schimbă culoarea vârfului 6 în portocaliu");
            Console.WriteLine(" 8 - Schimbă culoarea vârfului 7 în violet");
            Console.WriteLine(" T - Setează transparența la 50%");
        }

    }
}
