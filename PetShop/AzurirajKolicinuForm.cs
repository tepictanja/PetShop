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
    public partial class AzurirajKolicinuForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        public AzurirajKolicinuForm()
        {
            InitializeComponent();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            this.BackColor = Color.FromName(tema.color);
            buttonAzuriraj.BackColor = tema.btnback;
            buttonAzuriraj.ForeColor = tema.btnfore;
            buttonAzuriraj.Font = new Font(buttonAzuriraj.Font.FontFamily, buttonAzuriraj.Font.Size, tema.style);
            label1.ForeColor = tema.txtColor;
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size, tema.style);
            label2.ForeColor = tema.txtColor;
            label2.Font = new Font(label2.Font.FontFamily, label2.Font.Size, tema.style);
        }

        private void buttonAzuriraj_Click(object sender, EventArgs e)
        {
            DB_PetShop.AzurirajKolicinu(Int32.Parse(tbSifra.Text), Int32.Parse(tbKolicina.Text));
            MessageBox.Show("Količina je azurirana!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
