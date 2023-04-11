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
    public partial class AdminForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        public AdminForm()
        {
            InitializeComponent();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            this.BackColor = Color.FromName(tema.color);
            label1.ForeColor = tema.txtColor;
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size, tema.style);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbOdabir.Text.Equals("Dodaj proizvod"))
            {
                DodajProizvodForm form = new DodajProizvodForm();
                form.Show();
            }
            else if(cbOdabir.Text.Equals("Ukloni proizvod"))
            {
                UkloniProizvodForm form = new UkloniProizvodForm();
                form.Show();
            }
            else if (cbOdabir.Text.Equals("Ažuriraj količinu proizvoda"))
            {
                AzurirajKolicinuForm form = new AzurirajKolicinuForm();
                form.Show();
            }
            else if (cbOdabir.Text.Equals("Ažuriraj cijenu proizvoda"))
            {
                AzurirajCijenuForm form = new AzurirajCijenuForm();
                form.Show();
            }
            else if (cbOdabir.Text.Equals("Pregled narudžbi"))
            {
                PregledNarudzbiForm form = new PregledNarudzbiForm();
                form.Show();
            }
        }
    }
}
