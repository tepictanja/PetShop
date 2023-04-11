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
    public partial class AdminPrijavaForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        List<Control> buttons;
        List<Control> labels;

        public AdminPrijavaForm()
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


            buttons.Add(buttonPrijava);

            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
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

        private void buttonPrijava_Click(object sender, EventArgs e)
        {
            foreach (var a in DB_PetShop.GetAdmin())
            {
                if (!a.korisnickoIme.Equals(tbKorisnickoIme.Text) && !a.lozinka.Equals(tbLozinka.Text))
                {
                    MessageBox.Show("Vi niste administrator aplikacije!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            AdminForm f = new AdminForm();
            f.Show();
            this.Close();
        }

        private void AdminPrijavaForm_Load(object sender, EventArgs e)
        {

        }
    }
}
