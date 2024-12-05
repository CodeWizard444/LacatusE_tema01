using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CubWinForm
{
    public partial class CubForm : Form
    {
        // Variabile pentru poziția cubului pe axele X, Y și Z
        private float cubeX = 0f, cubeY = 0f, cubeZ = 0f;

        // Variabila pentru a decide dacă axele trebuie să fie desenate
        private bool showAxes = false;

        // Variabila care controlează dacă cubul este activ sau nu
        private bool cubeEnabled = false;

        // Variabile pentru culorile cubului (roșu, verde, albastru)
        private float redColor = 1.0f;
        private float greenColor = 1.0f;
        private float blueColor = 0.0f;

        // Constructorul form-ului, înregistrează evenimentele pentru controlul OpenGL și slider-e
        public CubForm()
        {
            InitializeComponent();
            glControl1.Paint += GlControl1_Paint; // Eveniment pentru redarea scenei
            glControl1.Load += glControl1_Load;  // Eveniment pentru inițializarea OpenGL

            // Adăugarea evenimentelor pentru slider-ele de culoare
            sliderRed.ValueChanged += SliderColor_ValueChanged;
            sliderGreen.ValueChanged += SliderColor_ValueChanged;
            sliderBlue.ValueChanged += SliderColor_ValueChanged;
        }

        // Evenimentul de încărcare a formularului
        private void CubForm_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent(); // Se face curent contextul OpenGL
            GL.ClearColor(Color.Black); // Setează culoarea de fundal pentru scena OpenGL

            // Se adaugă evenimentele pentru slider-ele care controlează poziția cubului
            sliderX.ValueChanged += Slider_ValueChanged;
            sliderY.ValueChanged += Slider_ValueChanged;
            sliderZ.ValueChanged += Slider_ValueChanged;
        }

        // Evenimentul pentru încărcare OpenGL
        private void glControl1_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent(); // Se face curent contextul OpenGL

            // Setează culoarea de fundal
            GL.ClearColor(Color.Black);

            // Activează Z-buffer pentru a gestiona corect ordinea obiectelor
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);

            // Configurarea proiecției perspectivei
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(
                (float)Math.PI / 4,
                glControl1.Width / (float)glControl1.Height,
                0.1f, // Distanța minimă de vizualizare
                50f); // Distanța maximă de vizualizare
            GL.LoadMatrix(ref perspective);

            // Setează modul de vizualizare a modelului
            GL.MatrixMode(MatrixMode.Modelview);
        }

        // Evenimentul pentru redarea OpenGL la fiecare actualizare a controlului
        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            // Curăță buffer-ul de culoare și adâncime
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LoadIdentity();

            // Poziționează camera într-o poziție 3D pentru a vizualiza cubul
            GL.Translate(0f, -2f, -15f); // Camera mai departe și ușor mai jos
            GL.Rotate(30, 1, 0, 0);     // Înclinare pe axa X
            GL.Rotate(-45, 0, 1, 0);    // Rotire pe axa Y

            // Desenează axele dacă este activat acest mod
            if (showAxes)
                DrawAxes();

            // Desenează cubul dacă este activat
            if (cubeEnabled)
            {
                GL.PushMatrix(); // Salvează matricea curentă
                GL.Translate(cubeX, cubeY, cubeZ); // Aplică translația pentru cub
                DrawCube(); // Desenează cubul
                GL.PopMatrix(); // Restabilește matricea salvată
            }

            // Schimbă buffer-urile pentru a afișa imaginea finală
            glControl1.SwapBuffers();
        }

        // Evenimentul pentru schimbarea stării checkbox-ului pentru afișarea axelor
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Actualizează variabila pentru afișarea axelor
            showAxes = checkBox1.Checked;
            glControl1.Invalidate(); // Re-redesenăm scena
        }

        // Evenimentul pentru butonul de activare a cubului
        private void button1_Click(object sender, EventArgs e)
        {
            UnsetAllObjects(); // Dezactivează toate obiectele
            SetObject(); // Activează cubul
            glControl1.Invalidate(); // Re-redesenăm scena
        }

        // Evenimentul pentru schimbarea valorii slider-elor care controlează poziția cubului
        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            // Mapăm valorile slider-elor într-un interval adecvat pentru OpenGL
            cubeX = sliderX.Value / 10f; // Scalăm valorile slider-ului
            cubeY = sliderY.Value / 10f;
            cubeZ = sliderZ.Value / 10f;

            glControl1.Invalidate(); // Re-redesenăm scena
        }

        // Evenimentul pentru schimbarea valorii slider-elor care controlează culoarea cubului
        private void SliderColor_ValueChanged(object sender, EventArgs e)
        {
            // Obținem valorile slider-elor de culoare
            redColor = sliderRed.Value / 100f;   // Împărțim la 100 pentru a obține valori între 0 și 1
            greenColor = sliderGreen.Value / 100f;
            blueColor = sliderBlue.Value / 100f;

            glControl1.Invalidate(); // Re-redesenăm scena
        }

        // Funcția care desenează axele X, Y și Z
        private void DrawAxes()
        {
            GL.Begin(PrimitiveType.Lines);

            // Axă X - Roșu
            GL.Color3(Color.Red);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(10, 0, 0);

            // Axă Y - Verde
            GL.Color3(Color.Green);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 10, 0);

            // Axă Z - Albastru
            GL.Color3(Color.Yellow);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, 10);

            GL.End();
        }

        // Funcția care desenează cubul
        private void DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);
            GL.Color3(redColor, greenColor, blueColor); // Aplică culoarea cubului

            // Fața frontală
            GL.Vertex3(-1, -1, 1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(-1, 1, 1);

            // Fața spate
            GL.Vertex3(-1, -1, -1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(-1, 1, -1);

            // Fața dreaptă
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(1, 1, -1);

            // Fața stângă
            GL.Vertex3(-1, -1, -1);
            GL.Vertex3(-1, -1, 1);
            GL.Vertex3(-1, 1, 1);
            GL.Vertex3(-1, 1, -1);

            // Fața de sus
            GL.Vertex3(-1, 1, -1);
            GL.Vertex3(1, 1, -1);
            GL.Vertex3(1, 1, 1);
            GL.Vertex3(-1, 1, 1);

            // Fața de jos
            GL.Vertex3(-1, -1, -1);
            GL.Vertex3(1, -1, -1);
            GL.Vertex3(1, -1, 1);
            GL.Vertex3(-1, -1, 1);

            GL.End();
        }

        // Funcția care activează cubul
        private void SetObject()
        {
            cubeEnabled = true;
        }

        // Funcția care dezactivează cubul
        private void UnsetObject()
        {
            cubeEnabled = false;
        }

        // Funcția care dezactivează toate obiectele (în acest caz doar cubul)
        private void UnsetAllObjects()
        {
            cubeEnabled = false;
            showAxes = false;
        }

        // Evenimentul pentru schimbarea stării checkbox-ului 2
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Se actualizează o variabilă sau setare bazată pe starea checkbox-ului
            // (exemplu: activarea unui alt obiect sau setare diferită)
            cubeEnabled = checkBox2.Checked; // Acest exemplu presupune că este folosit pentru a activa/dezactiva cubul
            glControl1.Invalidate(); // Re-redesenăm scena pentru a reflecta modificarea
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

    }
}
