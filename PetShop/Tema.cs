using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PetShop
{
    public  class Tema
    {
        //public int idTeme { get; set; }
        public string color { get; set; }

        public Color btnfore { get; set; }
        public Color txtColor { get; set; }

        public Color btnback { get; set; }
        //public Font font { get; set; }
        public FontStyle style { get; set; }

        public static Tema GetTema(int id)
        {
            Tema tema = new Tema();
            if(id == 0)
            {
                tema.color = "LightGreen";
                tema.style = FontStyle.Bold;
                tema.btnback = Color.FromArgb(4, 71, 22);
                tema.btnfore = Color.FromArgb(255, 255, 255);
                tema.txtColor = Color.FromArgb(4, 71, 22);
            }
            else if(id == 1)
            {
                tema.color = "LightBlue";
                tema.style = FontStyle.Italic;
                tema.btnback = Color.FromArgb(9, 21, 150);
                tema.btnfore = Color.FromArgb(255, 255, 255);
                tema.txtColor = Color.FromArgb(9, 21, 150);
            }
            else if(id==2)
            {
                tema.color = "LightGray";
                tema.style = FontStyle.Underline;
                tema.btnback = Color.FromArgb(27, 27, 28);
                tema.btnfore = Color.FromArgb(255, 255, 255);
                tema.txtColor = Color.FromArgb(27, 27, 28);
            }
            return tema;
        }
    }
}
