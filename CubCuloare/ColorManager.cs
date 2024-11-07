using System;
using System.Drawing;

public class ColorManager
{
    private Random random; // Obiect Random pentru generarea de valori aleatorii

    // Paleta predefinită de culori
    private Color[] predefinedPalette = new Color[]
    {
        Color.Red, Color.Green, Color.Blue, Color.Yellow,
        Color.Cyan, Color.Magenta, Color.Orange, Color.Purple
    };

    /// <summary>
    /// Constructorul clasei ColorManager. Inițializează obiectul Random.
    /// </summary>
    public ColorManager()
    {
        random = new Random(); // Inițializează generatorul de numere aleatorii
    }

    /// <summary>
    /// Generează o culoare aleatorie RGB cu valori între 0 și 255 pentru fiecare canal.
    /// Canalul alpha este setat la 255 (opac complet).
    /// </summary>
    /// <returns>Culoare aleatorie generată din valorile RGB.</returns>
    public Color GetRandomColor()
    {
        // Generează valori aleatorii pentru fiecare canal de culoare
        int r = random.Next(256);  // Valori pentru canalul roșu
        int g = random.Next(256);  // Valori pentru canalul verde
        int b = random.Next(256);  // Valori pentru canalul albastru
        // Returnează culoarea combinând cele trei canale (R, G, B) și setând alpha la 255 (opac)
        return Color.FromArgb(255, r, g, b);  // Culoare aleatorie RGB
    }

    /// <summary>
    /// Alege o culoare aleatorie din paleta predefinită de culori.
    /// </summary>
    /// <returns>Culoare aleasă din paleta predefinită.</returns>
    public Color GetColorFromPalette()
    {
        // Alege o culoare aleatorie din paleta definită
        return predefinedPalette[random.Next(predefinedPalette.Length)];
    }
}
