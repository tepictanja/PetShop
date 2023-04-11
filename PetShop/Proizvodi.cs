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
    public partial class Proizvodi : Form
    {
        
        public Tema tema { get; set; }
        public int idTeme;

        List<ToolStripMenuItem> tools;
        List<Control> buttons;
        List<Control> checkBoxes;

        public Proizvodi()
        {
            InitializeComponent();
            Initialize_Add();
            Delete();
            DB_PetShop.DeleteKorpa();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            Theme(Color.FromName(tema.color), tema.btnfore, tema.btnback, tema.txtColor, tema.style);

        }

        void Initialize_Add()
        {
            tools = new List<ToolStripMenuItem>();
            buttons = new List<Control>();
            checkBoxes = new List<Control>();

            tools.Add(psiToolStripMenuItem);
            tools.Add(mačkeToolStripMenuItem);
            tools.Add(pticeToolStripMenuItem);
            tools.Add(maleŽivotinjeToolStripMenuItem);
            tools.Add(psiHrana);
            tools.Add(psiOprema);
            tools.Add(psiIgracke);
            tools.Add(mackeHrana);
            tools.Add(mackeOprema);
            tools.Add(mackeIgracke);
            tools.Add(pticeHrana);
            tools.Add(pticeOprema);
            tools.Add(pticeIgracke);
            tools.Add(maleZHrana);
            tools.Add(maleZOprema);
            tools.Add(maleZIgracke);


            buttons.Add(korpaButton);
            buttons.Add(napredButton);
            buttons.Add(nazadButton);

            checkBoxes.Add(checkBox1);
            checkBoxes.Add(checkBox2);
            checkBoxes.Add(checkBox3);
        }

        private void Theme(Color back, Color btnfore, Color btnback, Color txtColor, FontStyle style)
        {
            this.BackColor = back;

            foreach(Control c in buttons)
            {
                c.BackColor = btnback;
                c.ForeColor = btnfore;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
            }
            foreach(Control c in checkBoxes)
            {
                c.ForeColor = txtColor;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
                c.Visible = false;
            }
            foreach(ToolStripMenuItem c in tools)
            {
                c.ForeColor = txtColor;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
            }
        }

        private void Delete()
        {
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            pictureBox1.Visible = false;
            pb1.Visible = false;
            pb2.Visible = false;
            pb3.Visible = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

        }

        private int br=0;
        

        private List<Proizvod> proizvodiList = new List<Proizvod>();
        private List<Proizvod> lista = new List<Proizvod>();
        public static DodajUKorpuForm f;

        private void PostaviSliku(int br, string slika, String naziv)
        {
            if (br == 1)
                try
                {
                    pb1.Visible = true;
                    pb1.Image = Image.FromFile(slika);
                    textBox1.Visible = true;
                    textBox1.Text = naziv;
                    checkBox1.Visible = true;

                    Instanca instanca = DB_PetShop.GetInstanca(proizvodiList[0].sifra);
                    String s = proizvodiList[0].naziv + "\n";
                    s += proizvodiList[0].sifra + "\n" + proizvodiList[0].opis + "\n";
                    s += instanca.cijena + "KM\n" + instanca.kolicina;
                    textBox1.Text = s;
                }
                catch (Exception ex)
                {
                }
            else if (br == 2)
                try
                {
                    pb2.Visible = true;
                    pb2.Image = Image.FromFile(slika);
                    textBox2.Visible = true;
                    textBox2.Text = naziv;
                    checkBox2.Visible = true;
                    Instanca instanca = DB_PetShop.GetInstanca(proizvodiList[1].sifra);
                    String s = proizvodiList[1].naziv + "\n";
                    s += proizvodiList[1].sifra + "\n" + proizvodiList[1].opis + "\n";
                    s += instanca.cijena + "KM\n" + instanca.kolicina;
                    textBox2.Text = s;
                }
                catch (Exception ex)
                { }
            else if (br == 3)
                try
                {
                    pb3.Visible = true;
                    pb3.Image = Image.FromFile(slika);
                    textBox3.Visible = true;
                    textBox3.Text = naziv;
                    checkBox3.Visible = true;
                    Instanca instanca = DB_PetShop.GetInstanca(proizvodiList[2].sifra);
                    String s = proizvodiList[2].naziv + "\n";
                    s += proizvodiList[2].sifra + "\n" + proizvodiList[0].opis + "\n";
                    s += instanca.cijena + "KM\n" + instanca.kolicina;
                    textBox3.Text = s;
                }
                catch (Exception ex)
                {}
        }

        private void ShowAll()
        {
            proizvodiList.Clear();
            int j = 0;
            for (int i = 0; i < br; i++)
                for (j = 0; j < 3; j++) ;
            for (int i = 1; i <= 3 && j < lista.Count; i++)
            {
                proizvodiList.Add(lista[j]);
                PostaviSliku(i, lista[j].fajl, lista[j].naziv);
                j++;
            }
        }
        private void mačkeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hranaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(1, 1);
            ShowAll();
        }

        private void nazadButton_Click(object sender, EventArgs e)
        {
            if (br != 0)
                br--;
            Delete();
            ShowAll();
        }

        private void napredButton_Click(object sender, EventArgs e)
        {
            br++;
            Delete();
            ShowAll();
        }

        private void psiOprema_Click(object sender, EventArgs e)
        {
            lista.Clear ();
            Delete();
            lista = DB_PetShop.GetProizvodi(2, 1);
            ShowAll();
        }

        private void psiIgracke_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(3, 1);
            ShowAll();
        }

        private void mackeHrana_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(1, 2);
            ShowAll();
        }

        private void mackeOprema_Click(object sender, EventArgs e)
        {
            lista.Clear();
            lista = DB_PetShop.GetProizvodi(2, 2);
            ShowAll();
        }

        private void mackeIgracke_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(3, 2);
            ShowAll();
        }

        private void pticeHrana_Click(object sender, EventArgs e)
        {
            lista.Clear();
            lista = DB_PetShop.GetProizvodi(1, 3);
            ShowAll();
        }

        private void pticeOprema_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(2, 3);
            ShowAll();
        }

        private void pticeIgracke_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(3, 3);
            ShowAll();

        }

        private void maleZHrana_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(1, 4);
            ShowAll();

        }

        private void maleZOprema_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(2, 4);
            proizvodiList.Clear();
            ShowAll();
        }

        private void maleZIgracke_Click(object sender, EventArgs e)
        {
            lista.Clear();
            Delete();
            lista = DB_PetShop.GetProizvodi(3, 4);
            ShowAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                f = new DodajUKorpuForm();
                f.sifra = proizvodiList[0].sifra;
                f.Show();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                f = new DodajUKorpuForm();
                f.sifra = proizvodiList[1].sifra;
                f.Show();
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                f = new DodajUKorpuForm();
                f.sifra = proizvodiList[2].sifra;
                f.Show();
            }
        }


        private void korpaButton_Click_1(object sender, EventArgs e)
        {
            KorpaForm k = new KorpaForm();
            k.Show();
        }
    }
}
