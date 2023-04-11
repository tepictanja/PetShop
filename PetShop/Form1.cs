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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            DB_PetShop.DeleteTema();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                    break;
                case 1:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Cyrl-RS");
                    break;
            }

            this.Controls.Clear();
            InitializeComponent();
        }
        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbCustomer.Checked)
            {
                Form2 f2 = new Form2();
                f2.Show();
            }
            else if (rbAdmin.Checked)
            {
                AdminPrijavaForm form = new AdminPrijavaForm();
                form.Show();
            }
            else
                MessageBox.Show("Morate izabrati jedan od naloga!", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB_PetShop.InsertTema(cbTema.SelectedIndex);
        }
    }
}
