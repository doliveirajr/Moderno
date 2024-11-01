using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moderno
{
    internal class EsquemaDeCores
    {
        public static List<string> ListaDeCores = new List<string>()
        {
            "#9BE0BD", "#A4D7E0", "#A9E1D8", "#96E0A2", "#9FC1E0"
        };

        public static Color MudarBrilho(Color cor, double fatorDeCorrecao)
        {
            double red = cor.R;
            double green = cor.G;
            double blue = cor.B;

            if (fatorDeCorrecao < 0)
            {
                fatorDeCorrecao = 1 + fatorDeCorrecao;
                red *= fatorDeCorrecao;
                green *= fatorDeCorrecao;
                blue *= fatorDeCorrecao;
            }
            else
            {
                red = (255 -  red) * fatorDeCorrecao + red;
                green = (255 - green) * fatorDeCorrecao + green;
                blue = (255 - blue) * fatorDeCorrecao + blue;
            }
            return Color.FromArgb(cor.A, (byte)red, (byte)green, (byte)blue);
        }
    }
}
