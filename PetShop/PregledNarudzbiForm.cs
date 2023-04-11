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
    public partial class PregledNarudzbiForm : Form
    {
        public Tema tema { get; set; }
        public int idTeme;

        public PregledNarudzbiForm()
        {
            InitializeComponent();
            idTeme = DB_PetShop.GetTema();
            tema = Tema.GetTema(idTeme);
            this.BackColor = Color.FromName(tema.color);
            dataGridView1.BackgroundColor = Color.FromName(tema.color);
            dataGridView1.GridColor = tema.txtColor;
            FillGrid();
        }

        void FillGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (var p in DB_PetShop.GetSveNarudzbe())
            {
                DataGridViewRow row = new DataGridViewRow()
                {
                    Tag = p
                };
                row.CreateCells(dataGridView1,p.ime, p.prezime, p.brojTelefona, p.datumNarudzbe, p.idStatusaNarudzbe);
                dataGridView1.Rows.Add(row);
            }
        }
    }

    
}
