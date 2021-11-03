using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Tema
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Fereastra f = new Fereastra())
            {
                f.Run(30.0, 0.0);
            }
        }
    }
}
