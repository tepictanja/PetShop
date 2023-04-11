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
    public partial class UkloniProizvodForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        public UkloniProizvodForm()
        {
            InitializeComponent();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            this.BackColor = Color.FromName(tema.color);
            buttonUkloni.BackColor = tema.btnback;
            buttonUkloni.ForeColor = tema.btnfore;
            buttonUkloni.Font = new Font(buttonUkloni.Font.FontFamily, buttonUkloni.Font.Size, tema.style);
            label1.ForeColor = tema.txtColor;
            label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size, tema.style);
        }

        private void buttonUkloni_Click(object sender, EventArgs e)
        {
            DB_PetShop.DeleteInstancaBySifra(Int32.Parse(tbSifra.Text));
            DB_PetShop.DeleteProizvodBySifra(Int32.Parse(tbSifra.Text));
            MessageBox.Show("Proizvod je izbrisa iz baze!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
