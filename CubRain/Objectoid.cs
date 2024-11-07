using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace CubRain
{
    /// <summary>
    /// Clasa Objectoid reprezintă un obiect 3D cu proprietăți precum vizibilitatea, culoarea, gravitația și poziția.
    /// Acesta poate cădea din cauza gravitației și poate fi desenat pe ecran.
    /// </summary>
    class Objectoid
    { 
        private bool visibility; // Determină dacă obiectul este vizibil
        private bool isGravityBound;  // Indică dacă obiectul este sub influența gravitației
        private Color color; // Culoarea obiectului
        private List<Vector3> coordList; // Lista de coordonate care definesc colțurile obiectului
        private Vector3 position; // Poziția obiectului în spațiu
        private float size; // Dimensiunea obiectului (cubului)
        private float fallSpeed;  // Viteza de cădere a obiectului
        private Randomizer randomizer; // Generatorul de valori aleatorii pentru coordonate și proprietăți

        private const float GRAVITY = 0.01f; // Constanta gravitației (valoare folosită pentru căderea obiectului)

        /// <summary>
        /// Constructorul clasei Objectoid. Inițializează un obiect cu proprietăți aleatorii (culoare, dimensiune, poziție) 
        /// și stabilește vizibilitatea și influența gravitației.
        /// </summary>
        /// <param name="randomizer">Obiectul Randomizer folosit pentru generarea aleatoare a valorilor.</param>
        public Objectoid(Randomizer randomizer)
        {
            this.randomizer = randomizer;
            visibility = true; // Obiectul este vizibil la început
            isGravityBound = true; // Obiectul este influențat de gravitație la început
            color = randomizer.RandomColor(); // Culoarea obiectului este aleatorie
            size = randomizer.RandomInt(2,4); // Dimensiunea obiectului (cubului) este aleatorie
            position = new Vector3(randomizer.RandomCoord(-10, 10), randomizer.RandomCoord(5, 20), randomizer.RandomCoord(-10, 10)); // Poziția obiectului este aleatorie
            fallSpeed = randomizer.RandomInt(1,1); // Viteza de cădere este constantă (poate fi ajustată în viitor)

            // Inițializarea coordonatelor cubului
            coordList = new List<Vector3>()
            {
                new Vector3(-size / 2, -size / 2, -size / 2), // Vârfuri cub
                new Vector3(size / 2, -size / 2, -size / 2),
                new Vector3(size / 2, -size / 2, size / 2),
                new Vector3(-size / 2, -size / 2, size / 2),
                new Vector3(-size / 2, size / 2, -size / 2),
                new Vector3(size / 2, size / 2, -size / 2),
                new Vector3(size / 2, size / 2, size / 2),
                new Vector3(-size / 2, size / 2, size / 2)
            };
        }

        /// <summary>
        /// Actualizează poziția obiectului, aplicând efectul gravitației. Dacă obiectul atinge solul, mișcarea se oprește.
        /// </summary>
        public void Update()
        {
            if (isGravityBound)
            {
                position.Y -= fallSpeed; // Aplica gravitația pe axa Y
                if (position.Y - size / 2 <= 0) // Verifică coliziunea cu solul
                {
                    position.Y = size / 2; // Oprește obiectul la sol
                    isGravityBound = false; // Încetează efectul gravitație
                }
            }
        }

        /// <summary>
        /// Desenează obiectul 3D pe ecran folosind OpenGL.
        /// </summary>
        public void Draw()
        {
            if (!visibility) return; // Dacă obiectul nu este vizibil, nu-l desena

            GL.PushMatrix(); // Salvează matricea curentă
            GL.Translate(position); // Translează obiectul la poziția sa
            GL.Color3(color); // Aplică culoarea obiectului

            // Fața de jos
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[0]);
            GL.Vertex3(coordList[1]);
            GL.Vertex3(coordList[2]);
            GL.Vertex3(coordList[3]);
            GL.End();

            // Fața de sus
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[4]);
            GL.Vertex3(coordList[5]);
            GL.Vertex3(coordList[6]);
            GL.Vertex3(coordList[7]);
            GL.End();

            // Cele patru fețe laterale
            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[0]);
            GL.Vertex3(coordList[3]);
            GL.Vertex3(coordList[7]);
            GL.Vertex3(coordList[4]);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[1]);
            GL.Vertex3(coordList[2]);
            GL.Vertex3(coordList[6]);
            GL.Vertex3(coordList[5]);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[0]);
            GL.Vertex3(coordList[1]);
            GL.Vertex3(coordList[5]);
            GL.Vertex3(coordList[4]);
            GL.End();

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex3(coordList[3]);
            GL.Vertex3(coordList[2]);
            GL.Vertex3(coordList[6]);
            GL.Vertex3(coordList[7]);
            GL.End();

            GL.PopMatrix();  // Restaurează matricea curentă
        }

        /// <summary>
        /// Comută vizibilitatea obiectului (îl face invizibil sau vizibil).
        /// </summary>
        public void ToggleVisibility()
        {
            visibility = !visibility; // Inversează valoarea vizibilității
        }

        /// <summary>
        /// Resetează poziția obiectului la una aleatorie, reintrând sub influența gravitației.
        /// </summary>
        public void ResetPosition()
        {
            position = new Vector3(randomizer.RandomCoord(-10, 10), randomizer.RandomCoord(5, 20), randomizer.RandomCoord(-10, 10)); // Poziție aleatorie
            isGravityBound = true; // Obiectul va cădea din nou
        }
    }
}
