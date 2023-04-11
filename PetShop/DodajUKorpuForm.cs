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
    public partial class DodajUKorpuForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        public DodajUKorpuForm()
        {
            InitializeComponent();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            this.BackColor = Color.FromName(tema.color);
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size, tema.style);
            label1.ForeColor = tema.txtColor;
            button1.Font = new Font(button1.Font.FontFamily, button1.Font.Size, tema.style);
            button1.BackColor = tema.btnback;
            button1.ForeColor = tema.btnfore;
        }

        public int sifra;
        

        private void button1_Click(object sender, EventArgs e)
        {
            int kolicina = Int32.Parse(textBox1.Text);
            if(textBox1.Text != " " || kolicina != 0)
            {
                Korpa k = DB_PetShop.GetKorpa(sifra);
                if (k.kolicina != 0) {
                    DB_PetShop.AzurirajKorpu(sifra, kolicina);
                }
                else
                {
                    Korpa korpa = new Korpa();
                    Instanca i = DB_PetShop.GetInstanca(sifra);
                    korpa.idInstance = i.idInstance;
                    korpa.sifra = sifra;
                    korpa.kolicina = kolicina;
                    DB_PetShop.InsertKorpa(korpa);
                }
            }
            Proizvodi.f.Close();
        }

    }
}
