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
    public partial class NarudzbaForm : Form
    {
        private int idNarudzbe = 0;

        public Tema tema { get; set; }
        public int idTeme;

        List<Control> buttons;
        List<Control> labels;

        public NarudzbaForm()
        {
            InitializeComponent();
            Initialize_Add();
            otkaziButton.Visible = false;
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            Theme(Color.FromName(tema.color), tema.btnfore, tema.btnback, tema.txtColor, tema.style);
        }

        void Initialize_Add()
        {
            buttons = new List<Control>();
            labels = new List<Control>();


            buttons.Add(button1);
            buttons.Add(otkaziButton);

            labels.Add(label1);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
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
            foreach(Control c in labels)
            {
                c.ForeColor = txtColor;
                c.Font = new Font(c.Font.FontFamily, c.Font.Size, style);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if("".Equals(tbkorisnickoIme.Text) || "".Equals(cbGrad.Text) || 
                "".Equals(tbUlica.Text) || "".Equals(tbBroj.Text) || "".Equals(tbBrojTel.Text) ||
                "".Equals(cbPlacanje.Text) || "".Equals(cbDostava.Text)){
                MessageBox.Show("Morate opuniti sva polja!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Grad g = DB_PetShop.GetGrad(cbGrad.Text);
                if(g == null)
                {
                    MessageBox.Show("Nije moguće naručivanje iz ovog grada!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Narudzba narudzba = new Narudzba();

                DateTime time = DateTime.Now;
                string format = "yyyy-MM-dd HH:mm:ss";
                Kupac k = DB_PetShop.GetKupac(tbkorisnickoIme.Text);
                if (k != null)
                {
                    narudzba.ime = k.ime;
                    narudzba.prezime = k.prezime;
                    narudzba.idKupca = k.idKupca;
                }

                narudzba.datumNarudzbe = time.ToString(format);
                narudzba.brojTelefona = tbBrojTel.Text;
                narudzba.brojKartice = ("".Equals(tbKartica.Text))? " ":tbKartica.Text;
                Adresa adresa = new Adresa();
                adresa.ulica = tbUlica.Text;
                adresa.broj = Int32.Parse(tbBroj.Text);
                adresa.postanskiBroj = g.postanskiBroj;
                DB_PetShop.InsertAdresa(adresa);
                narudzba.idAdrese = DB_PetShop.GetIdAdrese(adresa.ulica, adresa.broj, adresa.postanskiBroj);
                int idNacinaPlacanja = DB_PetShop.GetIdNacinaPlacanja(cbPlacanje.Text);
                if(idNacinaPlacanja != 0)
                    narudzba.idNacinaPlacanja = idNacinaPlacanja;
                int idDostave = DB_PetShop.GetIdDostave(cbDostava.Text, 1);
                if(idDostave != 0)
                    narudzba.idDostave = idDostave;
                narudzba.idStatusaNarudzbe = 1;
                DB_PetShop.InsertNarudzba(narudzba);
                idNarudzbe = narudzba.idNarudzbe;

                List<Korpa> sadrzaj = DB_PetShop.GetSadrzajKorpe();

                foreach(Korpa korpa in sadrzaj)
                {
                    Instanca tmp = DB_PetShop.GetInstanca(korpa.sifra);
                    if (tmp != null)
                    {
                        if (tmp.kolicina < korpa.kolicina)
                        {
                            MessageBox.Show("Odbacena narudzba proizvoda! Dostupna kolicina: " + tmp.kolicina, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            DB_PetShop.AzurirajKolicinu(tmp.sifra, tmp.kolicina - korpa.kolicina);
                            NaruceniProizvod n = new NaruceniProizvod();
                            Instanca nova = DB_PetShop.GetInstanca(tmp.sifra);
                            n.idNarudzbe = narudzba.idNarudzbe;
                            n.idInstance = nova.idInstance;
                            n.ukupnaKolicina = korpa.kolicina;
                            n.ukupnaCijena = n.ukupnaKolicina * nova.cijena;
                            DB_PetShop.UnesiNaruceniProizvod(n);
                        }
                    }
                    else
                        return;

                    otkaziButton.Visible = true;
                    DB_PetShop.DeleteKorpa();
                }
            }
        }

        private void otkaziButton_Click(object sender, EventArgs e)
        {
            Narudzba narudzba = DB_PetShop.GetNarudzba(idNarudzbe);

            if(narudzba != null)
            {
                DB_PetShop.OtkaziNarudzbu(idNarudzbe, cbDostava.Text);
                this.Close();
            }
        }

        private void cbPlacanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPlacanje.SelectedIndex == 0)
            {
                tbKartica.Visible = false;
                label8.Visible = false;
            }
        }

        private void tbKartica_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
