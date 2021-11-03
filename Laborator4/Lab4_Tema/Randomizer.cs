using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tema
{
    class Randomizer
    {
        Random r;
        public Randomizer()
        {
            r = new Random();
        }

        public Color FurnizareCuloareAleatorie()
        {
            int R = r.Next(0,255);
            int G = r.Next(0,255);
            int B = r.Next(0,255);

            Color col = Color.FromArgb(R, G, B);
            return col;
        }

        public int FurnizareNumarRandom()
        {
            int ret = r.Next(0, 38);

            return ret;
        }
    }
}
