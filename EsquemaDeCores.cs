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
            "#f33d17", "#46cc25", "#cc4125", "#8c0a0e", "#0a8c74", "#5b169c", "#0c2b7a", "#15bd60", "#1f1f7d", "#e6e60e"
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
