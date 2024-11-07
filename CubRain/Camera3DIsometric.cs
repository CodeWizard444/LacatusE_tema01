using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace LacatusE_TemaCLI
{
    /// <summary>
    /// Clasa Camera3DIsometric reprezintă o cameră 3D cu vedere izometrică. Permite mutarea camerei în spațiul 3D pe axele X, Y și Z.
    /// </summary>
    class Camera3DIsometric
    {
        private Vector3 position; // Poziția curentă a camerei în spațiul 3D
        private float speed; // Viteza de mișcare a camerei

        /// <summary>
        /// Constructorul clasei Camera3DIsometric. Initializează poziția și viteza camerei.
        /// </summary>
        /// <param name="initialPosition">Poziția inițială a camerei.</param>
        /// <param name="initialSpeed">Viteza de mișcare a camerei (implicită este 0.5f).</param>
        public Camera3DIsometric(Vector3 initialPosition, float initialSpeed=.5f)
        {
            position = initialPosition; // Setează poziția inițială a camerei
            speed = initialSpeed; // Setează viteza inițială de mișcare
        }

        /// <summary>
        /// Setează matricea de vizualizare a camerei, definind cum se vizualizează scena din perspectiva camerei.
        /// </summary>
        public void SetCamera()
        {
            // Creează matricea de vizualizare (camerei) folosind poziția curentă a camerei și direcția țintă (centrul lumii)
            Matrix4 view = Matrix4.LookAt(position, new Vector3(0, 0, 0), Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview); // Setează modul de matrice pentru transformările modelului
            GL.LoadMatrix(ref view);  // Încarcă matricea de vizualizare în OpenGL
        }

        /// <summary>
        /// Mișcă camera înainte (pe axa Z).
        /// </summary>
        public void MoveForward()
        {
            position.Z -= speed; // Deplasează camera înainte pe axa Z
        }

        /// <summary>
        /// Mișcă camera înapoi (pe axa Z).
        /// </summary>
        public void MoveBackward()
        {
            position.Z += speed; // Deplasează camera înapoi pe axa Z
        }

        /// <summary>
        /// Mișcă camera la dreapta (pe axa X).
        /// </summary>
        public void MoveLeft()
        {
            position.X -= speed;  // Deplasează camera la stânga pe axa X
        }

        /// <summary>
        /// Mișcă camera la dreapta (pe axa X).
        /// </summary>
        public void MoveRight()
        {
            position.X += speed;  // Deplasează camera la dreapta pe axa X
        }

        /// <summary>
        /// Mișcă camera în sus (pe axa Y).
        /// </summary>
        public void MoveUp()
        {
            position.Y += speed; // Deplasează camera în sus pe axa Y
        }

        /// <summary>
        /// Mișcă camera în jos (pe axa Y).
        /// </summary>
        public void MoveDown()
        {
            position.Y -= speed; // Deplasează camera în jos pe axa Y
        }

    }

}
