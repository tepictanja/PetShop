using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    class Proizvod
    {
        public int sifra { get; set; }
        public string naziv { get; set; }
        public string opis { get; set; }
        public string fajl { get; set; }
        public int idVrste { get; set; }
        public int idKategorije { get; set; }
    }
}
