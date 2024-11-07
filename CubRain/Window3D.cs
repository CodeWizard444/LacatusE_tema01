using System;
using System.Collections.Generic;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using LacatusE_TemaCLI;

namespace CubRain
{
    /// <summary>
    /// Clasa Window3D reprezintă fereastra principală a aplicației 3D.
    /// Gestionează interacțiunile utilizatorului cu aplicația, inclusiv mișcarea camerei, generarea obiectelor 3D și schimbarea culorii de fundal.
    /// </summary>
    class Window3D : GameWindow
    {
        private Axes axes; // Instanță pentru axele 3D
        private Randomizer randomizer; // Instanță pentru generarea de culori random
        private Grid grid; // Instanță pentru a desena grila 3D
        private Camera3DIsometric camera; // Instanță pentru camera 3D izometrică
        private Color backgroundColor = Color.CornflowerBlue;  // Culoarea de fundal implicită
        private List<Objectoid> objectoids; // Lista pentru cuburile care vor cădea
        private const float gridHeight = 0.5f; // Înălțimea grid-ului pentru interacțiune

        /// <summary>
        /// Constructorul ferestrei 3D. Inițializează instanțele de obiecte necesare și afișează ajutorul pentru utilizator.
        /// </summary>
        public Window3D() : base(1280, 768, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On; // Activează sincronizarea verticală pentru a preveni ruperea imaginii

            randomizer = new Randomizer();  // Inițializează instanța de randomizer pentru culori
            axes = new Axes();  // Inițializează axele 3D
            grid = new Grid(size: 25, spacing: 1.0f); // Inițializează grid-ul 3D
            camera = new Camera3DIsometric(new Vector3(30, 30, 30)); // Inițializează camera cu o poziție de start
            objectoids = new List<Objectoid>(); // Inițializăm lista pentru cuburi
            DisplayHelp(); // Afișează meniul de ajutor pentru utilizator
        }

        /// <summary>
        /// Metoda apelată când fereastra este încărcată. Activează testul de adâncime și setează culoarea de fundal.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.Enable(EnableCap.DepthTest); // Activează testul de adâncime pentru a determina ce obiecte sunt vizibile
            GL.DepthFunc(DepthFunction.Less); // Setează funcția de testare a adâncimii
            GL.ClearColor(backgroundColor); // Setează culoarea de fundal
        }

        /// <summary>
        /// Metoda apelată când dimensiunea ferestrei se schimbă. Setează viewport-ul și matricea de proiecție.
        /// </summary>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
             
            GL.Viewport(0, 0, this.Width, this.Height); // Setează viewport-ul la dimensiunile ferestrei
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)this.Width / this.Height, 1.0f, 250.0f);  // Creează o proiecție perspective

            GL.MatrixMode(MatrixMode.Projection);  // Setează matricea de proiecție
            GL.LoadMatrix(ref perspective);  // Încarcă matricea de proiecție

            Matrix4 camera = Matrix4.LookAt(30, 30, 30, 0, 0, 0, 0, 1, 0);  // Creează matricea camerei
            GL.MatrixMode(MatrixMode.Modelview);  // Setează matricea de modelare
            GL.LoadMatrix(ref camera);  // Încarcă matricea camerei
        }

        /// <summary>
        /// Metoda apelată la fiecare cadru pentru a actualiza starea aplicației. Verifică input-ul de la tastatură și mouse.
        /// </summary>
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboardState = Keyboard.GetState();  // Obține starea curentă a tastaturii
            MouseState mouseState = Mouse.GetState();  // Obține starea curentă a mouse-ului
            KeyboardState currentKeyboard = Keyboard.GetState();  // Obține starea curentă a tastaturii pentru a detecta mișcările camerei

            // Închide aplicația când apăsăm ESC
            if (keyboardState[Key.Escape])
            {
                Exit();
            }

            // Resetarea culorii fundalului la apăsarea tastei R
            if (keyboardState[Key.R])
            {
                GL.ClearColor(backgroundColor);
            }

            // Schimbarea culorii fundalului la apăsarea tastei B
            if (keyboardState[Key.B])
            {
                GL.ClearColor(randomizer.RandomColor());
            }

            // Mișcarea camerei
            if (currentKeyboard[Key.W]) camera.MoveForward();
            if (currentKeyboard[Key.S]) camera.MoveBackward();
            if (currentKeyboard[Key.A]) camera.MoveLeft();
            if (currentKeyboard[Key.D]) camera.MoveRight();
            if (currentKeyboard[Key.Q]) camera.MoveUp();
            if (currentKeyboard[Key.E]) camera.MoveDown();

            // Verificăm apăsarea butoanelor mouse-ului
            if (mouseState.IsButtonDown(MouseButton.Left))
            {
                SpawnObject(); // Creăm un cub la fiecare apăsare
            }

            if (mouseState.IsButtonDown(MouseButton.Right))
            {
                ClearObjects(); // Curățăm obiectele când apăsăm butonul drept
            }

            // Actualizăm obiectele care cad
            foreach (var obj in objectoids)
            {
                obj.Update();
            }
        }

        /// <summary>
        /// Metoda apelată pentru a desena fiecare cadru. Afișează axele, grid-ul și obiectele pe ecran.
        /// </summary>
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // Curăță buffer-ul de culoare și adâncime

            // Aplicăm camera
            camera.SetCamera();

            // Desenăm axele, grid-ul și obiectele
            axes.Draw();
            grid.Draw();

            foreach (var obj in objectoids)
            {
                obj.Draw(); // Desenează fiecare obiect (cub) din listă
            }

            SwapBuffers();
        }

        /// <summary>
        /// Creează un nou obiect (cub) atunci când se apasă butonul stâng al mouse-ului.
        /// </summary>
        private void SpawnObject()
        {
            // Când se apasă butonul stâng al mouse-ului, se creează un cub
            Objectoid newObject = new Objectoid(randomizer);
            objectoids.Add(newObject); // Adăugăm obiectul la listă
        }

        /// <summary>
        /// Curăță toate obiectele (cuburi) din scenă atunci când se apasă butonul drept al mouse-ului.
        /// </summary>
        private void ClearObjects()
        {
            // Când se apasă butonul drept al mouse-ului, curățăm obiectele
            objectoids.Clear();
        }

        /// <summary>
        /// Afișează un meniu de ajutor în consolă pentru utilizator.
        /// </summary>
        private void DisplayHelp()
        {
            Console.WriteLine("\n      MENIU");
            Console.WriteLine(" ESC - parasire aplicatie");
            Console.WriteLine(" R - reseteaza culoarea de fundal");
            Console.WriteLine(" B - schimba culoarea de fundal");
            Console.WriteLine(" W - Miscare înainte");
            Console.WriteLine(" S - Miscare înapoi");
            Console.WriteLine(" A - Miscare la stânga");
            Console.WriteLine(" D - Miscare la dreapta");
            Console.WriteLine(" Q - Miscare în sus");
            Console.WriteLine(" E - Miscare în jos");
        }
    }
}
