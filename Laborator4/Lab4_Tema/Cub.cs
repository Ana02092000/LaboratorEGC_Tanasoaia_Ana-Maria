using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tema
{
    class Cub
    {
        private const String FISIER = "coordonate.txt";

        private List<Vector3> listaCoordonate;
        char[] sep = { ' ' };
        Randomizer _r;
        bool showCube = true;
        private Color[] ColorV2 = new Color[39];

        public Cub()
        {
            listaCoordonate = CitireFisier(FISIER);
            _r = new Randomizer();
            SetareCuloare();
        }

        public void SetareCuloare() // setare culoare pentru fiecare punct ce formeaza triunghiurile din componenta cubului
        {
            for (int i=0; i<39; i++)
            {
                ColorV2[i] = _r.FurnizareCuloareAleatorie();
            }
        }

        public void SchimbareCuloare(Randomizer r) //schimba culoarea unui triunghi aleatoriu de pe cub si o afiseaza
        {
            Color color1;
                color1 = r.FurnizareCuloareAleatorie();
                int i = r.FurnizareNumarRandom();
                ColorV2[i] = color1;
                Console.WriteLine(ColorV2[i] + "  ");
            
            Console.WriteLine("\n");
        }

        public void Desenare()
        {
            int j = 0;
            
            GL.Begin(PrimitiveType.Triangles);
                foreach (var vert in listaCoordonate)
                {
                GL.Color3(ColorV2[j]);
                GL.Vertex3(vert);
                    j++;
                }
                GL.End();
            
        }

        private List<Vector3> CitireFisier (string fis) //citire din fisier
        {
            List<Vector3> vlc3 = new List<Vector3>();

            var lines = File.ReadLines(fis);
            foreach (var line in lines)
            {
                string[] numere = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                Vector3 vec = new Vector3(Convert.ToInt32(numere[0]), Convert.ToInt32(numere[1]), Convert.ToInt32(numere[2]));
                vlc3.Add(vec);
            }
            return vlc3;
        }
    }
}
