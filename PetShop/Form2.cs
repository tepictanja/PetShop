using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PetShop
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;

        public Tema tema { get; set; }
        public int idTeme;

        List<Control> buttons;
        List<Control> labels;
        List<Control> radioButtons;

        public Form2()
        {
            InitializeComponent();
            passLabel.Visible = false;
            Instance = this;
            Initialize_Add();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            Theme(Color.FromName(tema.color), tema.btnfore, tema.btnback, tema.txtColor, tema.style);
        }

        void Initialize_Add()
        {
            buttons = new List<Control>();
            labels = new List<Control>();


            buttons.Add(button1);

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(passLabel);
            labels.Add(label7);
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
            foreach (Control c in labels)
            {
                c.ForeColor = txtColor;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Kupac k = DB_PetShop.GetKupac(tbKorisnickoIme.Text);
            bool id = true;
            if (k == null)
            {
                var kupac = new Kupac()
                {
                    ime = tbIme.Text,
                    prezime = tbPrezime.Text,
                    korisnickoIme = tbKorisnickoIme.Text,
                    lozinka = tbLozinka.Text,
                };

                DB_PetShop.UnesiKupca(kupac);
            }
            else
            {
                if (!tbLozinka.Text.Equals(k.lozinka))
                {
                    passLabel.Visible = true;
                    id = false;
                }
                else
                {
                    id = true;
                    passLabel.Visible = false;
                }
            }

            if (id == true)
            {
                Proizvodi p = new Proizvodi();
                p.Show();
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
    }
}
