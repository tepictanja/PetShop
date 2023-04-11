using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetShop
{
    public partial class KorpaForm : Form
    {
        private int br = 0;
        public static NarudzbaForm f;

        public Tema tema { get; set; }
        public int idTeme;

        List<Control> buttons;
        public KorpaForm()
        {
            InitializeComponent();
            Initialize_Add();
            prikazi(Korpa.GetSifra(br));
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            Theme(Color.FromName(tema.color), tema.btnfore, tema.btnback, tema.txtColor, tema.style);
        }

        void Initialize_Add()
        {
            buttons = new List<Control>();

            buttons.Add(ukloniButton);
            buttons.Add(naruciButton);
            buttons.Add(napredButton);
            buttons.Add(nazadButton);
        }

        private void Theme(Color back, Color btnfore, Color btnback, Color txtColor, FontStyle style)
        {
            this.BackColor = back;

            foreach (Control c in buttons)
            {
                c.BackColor = btnback;
                c.ForeColor = btnfore;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
            }
        }



        private void prikazi(int sifra)
        {
            if(sifra != 0)
            {
                tbCijena.Visible = true;
                nazadButton.Visible = true;
                napredButton.Visible = true;
                ukloniButton.Visible = true;
                naruciButton.Visible = true;
            }

            Proizvod p = DB_PetShop.GetProizvod(sifra);
            if(p != null)
            {
                pictureBox1.Image = Image.FromFile(p.fajl);
                Instanca i = DB_PetShop.GetInstanca(sifra);
                tbCijena.Text = i.cijena.ToString() + " KM";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB_PetShop.DeleteKorpaBySifra(Korpa.GetSifra(br));
            if (br > 0)
                br--;
            prikazi(Korpa.GetSifra(br));
        }

        private void napredButton_Click(object sender, EventArgs e)
        {
            br++;
            prikazi(Korpa.GetSifra(br));
        }

        private void nazadButton_Click(object sender, EventArgs e)
        {
            if (br > 0)
                br--;
            prikazi(Korpa.GetSifra(br));
        }

        private void naruciButton_Click(object sender, EventArgs e)
        {
            f = new NarudzbaForm();
            f.Show();
            this.Close();
        }
    }
}
