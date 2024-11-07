using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CubRain
{
    /// <summary>
    /// Clasa Randomizer generează valori aleatorii, inclusiv culori și coordonate, utilizând obiectul Random.
    /// Aceasta este utilă pentru a crea efecte de ploaie de cuburi cu caracteristici aleatorii.
    /// </summary>
    class Randomizer
    {
        private Random random; // Obiectul care generează numere aleatorii
        private const int LOW_INT_VAL = -25; // Valoarea minimă pentru numere întregi
        private const int HIGH_INT_VAL = 25; // Valoarea maximă pentru numere întregi
        private const int LOW_COORD_VAL = -50; // Valoarea minimă pentru coordonate
        private const int HIGH_COORD_VAL = 50; // Valoarea maximă pentru coordonate

        /// <summary>
        /// Constructorul clasei Randomizer. Inițializează obiectul Random.
        /// </summary>
        public Randomizer()
        {
            random = new Random(); // Crează o instanță a generatorului de numere aleatorii
        }

        /// <summary>
        /// Generează o culoare aleatorie, cu valori pentru fiecare canal (roșu, verde, albastru) între 0 și 255.
        /// </summary>
        /// <returns>O culoare aleatorie generată.</returns>
        public Color RandomColor()
        {
            int red = random.Next(0, 256); // Generează o valoare aleatorie pentru roșu
            int green = random.Next(0, 256); // Generează o valoare aleatorie pentru verde
            int blue = random.Next(0, 256); // Generează o valoare aleatorie pentru albastru

            return Color.FromArgb(red, green, blue); // Creează și returnează culoarea aleatorie
        }

        /// <summary>
        /// Generează un număr întreg aleatoriu între valorile minime și maxime definite în clasa Randomizer.
        /// </summary>
        /// <returns>Un număr întreg aleatoriu între LOW_INT_VAL și HIGH_INT_VAL.</returns>
        public int RandomInt()
        {
            return random.Next(LOW_INT_VAL, HIGH_INT_VAL); // Generează un număr întreg aleatoriu
        }

        /// <summary>
        /// Generează un număr întreg aleatoriu între două valori specifice date de utilizator.
        /// </summary>
        /// <param name="min">Valoarea minimă.</param>
        /// <param name="max">Valoarea maximă.</param>
        /// <returns>Un număr întreg aleatoriu între min și max.</returns>
        public int RandomInt(int min,int max)
        {
            return random.Next(min, max); // Generează un număr între min și max
        }

        /// <summary>
        /// Generează o coordonată aleatorie între valorile minime și maxime definite în clasa Randomizer.
        /// </summary>
        /// <returns>O valoare de coordonată aleatorie între LOW_COORD_VAL și HIGH_COORD_VAL.</returns>
        public int RandomCoord()
        {
            return random.Next(LOW_COORD_VAL, HIGH_COORD_VAL); // Generează o valoare de coordonată aleatorie
        }

        /// <summary>
        /// Generează o coordonată aleatorie între două valori specifice date de utilizator.
        /// </summary>
        /// <param name="min">Valoarea minimă pentru coordonată.</param>
        /// <param name="max">Valoarea maximă pentru coordonată.</param>
        /// <returns>O valoare de coordonată aleatorie între min și max.</returns>
        public int RandomCoord(int min,int max)
        {
            return random.Next(min,max); // Generează o valoare de coordonată între min și max
        }
    }
}
