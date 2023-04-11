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
    public partial class DodajProizvodForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        List<Control> buttons;
        List<Control> labels;

        public DodajProizvodForm()
        {
            InitializeComponent();
            Initialize_Add();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            Theme(Color.FromName(tema.color), tema.btnfore, tema.btnback, tema.txtColor, tema.style);
        }

        void Initialize_Add()
        {
            buttons = new List<Control>();
            labels = new List<Control>();


            buttons.Add(buttonSacuvaj);
            buttons.Add(buttonUcitaj);

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(labelSifra);
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

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Select image( *.Jpg; *.png)| *.Jpg; *.png";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSacuvaj_Click_1(object sender, EventArgs e)
        {
            var proizvod = new Proizvod()
            {
                sifra = Int32.Parse(tbSifra.Text),
                naziv = tbNaziv.Text,
                opis = tbOpis.Text,
                fajl = openFileDialog1.FileName,
                idKategorije = Int32.Parse(tbKategorija.Text),
                idVrste = Int32.Parse(tbVrsta.Text)
            };

            var instanca = new Instanca()
            {
                kolicina = Int32.Parse(tbKolicina.Text),
                cijena = Int32.Parse(tbCijena.Text),
                sifra = Int32.Parse(tbSifra.Text)
            };
            DB_PetShop.UnesiProizvod(proizvod);
            DB_PetShop.UnesiInstancu(instanca);
            MessageBox.Show("Proizvod je sačuvan!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
