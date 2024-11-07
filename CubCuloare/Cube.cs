using System;
using System.Drawing;
using System.IO;
using OpenTK.Graphics.OpenGL;

public class Cube
{
    private float[,] vertices;           // Coordonatele vârfurilor cubului
    private Color[] vertexColors;       // Culoare pentru fiecare vârf
    private float alpha = 1.0f;         // Canalul de transparență
    private ColorManager colorManager;  // Instanță pentru gestionarea culorilor

    /// <summary>
    /// Constructorul clasei Cube. Încarcă coordonatele vârfurilor dintr-un fișier
    /// și inițializează culorile vârfurilor.
    /// </summary>
    /// <param name="filePath">Calea fișierului care conține coordonatele vârfurilor cubului.</param>
    public Cube(string filePath)
    {
        colorManager = new ColorManager();  // Inițializare ColorManager
        LoadVertices(filePath); // Încarcă coordonatele vârfurilor din fișier
        InitializeVertexColors(); // Inițializează culorile vârfurilor
    }

    /// <summary>
    /// Încarcă coordonatele vârfurilor cubului dintr-un fișier text.
    /// Fiecare linie trebuie să conțină coordonatele unui vârf (X, Y, Z).
    /// </summary>
    /// <param name="filePath">Calea fișierului care conține coordonatele vârfurilor.</param>
    private void LoadVertices(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath); // Citește toate liniile din fișier
        vertices = new float[8, 3];  // 8 vârfuri, fiecare cu 3 coordonate (X, Y, Z)

        // Parcurge liniile și extrage coordonatele vârfurilor
        for (int i = 0; i < 8; i++)
        {
            string[] coords = lines[i].Split(','); // Împarte coordonatele pe fiecare virgulă
            vertices[i, 0] = float.Parse(coords[0]); // Coordonata X
            vertices[i, 1] = float.Parse(coords[1]); // Coordonata Y
            vertices[i, 2] = float.Parse(coords[2]); // Coordonata Z
        }
    }

    /// <summary>
    /// Inițializează culorile vârfurilor cubului. Folosește managerul de culori pentru
    /// a atribui o culoare aleatorie fiecărui vârf.
    /// </summary>
    private void InitializeVertexColors()
    {
        vertexColors = new Color[8]; // Array de culori pentru cei 8 vârfuri
        for (int i = 0; i < 8; i++)
        {
             vertexColors[i] = colorManager.GetColorFromPalette(); // Atribuie fiecarei culori un nou element din paletă
        }
    }

    /// <summary>
    /// Ajustează culoarea unui vârf al cubului, aplicând transparență.
    /// </summary>
    /// <param name="vertexIndex">Indexul vârfului căruia îi schimbăm culoarea.</param>
    /// <param name="newColor">Noua culoare pentru vârf.</param>
    public void AdjustVertexColor(int vertexIndex, Color newColor)
    {
        if (vertexIndex >= 0 && vertexIndex < 8) // Verificăm dacă indexul vârfului este valid
        {
            // Ajustăm culoarea vârfului cu transparență aplicată
            vertexColors[vertexIndex] = Color.FromArgb((int)(alpha * 255), newColor.R, newColor.G, newColor.B);

            // Afișăm valorile RGB doar când modificăm culoarea vârfului
            Console.WriteLine($"Vertex {vertexIndex}: R={newColor.R}, G={newColor.G}, B={newColor.B}");
        }
    }


    /// <summary>
    /// Ajustează transparența globală a cubului, afectând toate culorile vârfurilor.
    /// </summary>
    /// <param name="newAlpha">Noua valoare de transparență (între 0.0 și 1.0).</param>
    public void AdjustTransparency(float newAlpha)
    {
        if (newAlpha < 0.0f)
            alpha = 0.0f; // Transparente mai mici de 0 devin 0 (complet transparent)
        else if (newAlpha > 1.0f)
            alpha = 1.0f; // Transparente mai mari de 1 devin 1 (complet opac)
        else
            alpha = newAlpha; // Altfel, setăm transparența la valoarea cerută

        // Modifică transparența pentru fiecare vârf
        for (int i = 0; i < vertexColors.Length; i++)
        {
            Color color = vertexColors[i]; // Culoarea curentă a vârfului
            vertexColors[i] = Color.FromArgb((int)(alpha * 255), color.R, color.G, color.B); // Aplică transparența
            Console.WriteLine($"Varful {i} transparenta ajustata: RGB({vertexColors[i].R}, {vertexColors[i].G}, {vertexColors[i].B})");
        }
    }

    /// <summary>
    /// Desenează cubul în scenă folosind OpenGL, având culori diferite pentru fiecare față.
    /// </summary>
    public void Draw()
    {
        // Începem să desenăm triunghiuri
        GL.Begin(PrimitiveType.Triangles);

        // Fața frontală - 2 triunghiuri
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(1); SetVertexColorAndDraw(2);
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(2); SetVertexColorAndDraw(3);

        // Fața din spate - 2 triunghiuri
        SetVertexColorAndDraw(4); SetVertexColorAndDraw(5); SetVertexColorAndDraw(6);
        SetVertexColorAndDraw(4); SetVertexColorAndDraw(6); SetVertexColorAndDraw(7);

        // Fața de sus - 2 triunghiuri
        SetVertexColorAndDraw(3); SetVertexColorAndDraw(2); SetVertexColorAndDraw(6);
        SetVertexColorAndDraw(3); SetVertexColorAndDraw(6); SetVertexColorAndDraw(7);

        // Fața de jos - 2 triunghiuri
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(1); SetVertexColorAndDraw(5);
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(5); SetVertexColorAndDraw(4);

        // Fața dreapta - 2 triunghiuri
        SetVertexColorAndDraw(1); SetVertexColorAndDraw(2); SetVertexColorAndDraw(6);
        SetVertexColorAndDraw(1); SetVertexColorAndDraw(6); SetVertexColorAndDraw(5);

        // Fața stânga - 2 triunghiuri
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(3); SetVertexColorAndDraw(7);
        SetVertexColorAndDraw(0); SetVertexColorAndDraw(7); SetVertexColorAndDraw(4);

        GL.End(); // Terminăm desenarea
    }

    /// <summary>
    /// Setează culoarea unui vârf și îl desenează în scenă.
    /// </summary>
    /// <param name="vertexIndex">Indexul vârfului care trebuie desenat.</param>
    private void SetVertexColorAndDraw(int vertexIndex)
    {
        Color color = vertexColors[vertexIndex];  // Culoarea vârfului
        GL.Color4(color);  // Setează culoarea curentă
        GL.Vertex3(vertices[vertexIndex, 0], vertices[vertexIndex, 1], vertices[vertexIndex, 2]);  // Desenează vârful
    }
}
