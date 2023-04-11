using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal class Narudzba
    {
        public int idNarudzbe { get; set; }
        public  string ime { get; set; }

        public string prezime { get; set; }
        public string datumNarudzbe { get; set; }
        public string brojTelefona { get; set; }
        public string brojKartice { get; set; }

        public int idKupca { get; set; }
        public int idAdrese { get; set; }
        public int idNacinaPlacanja { get; set; }
        public int idDostave { get; set; }
        public int idStatusaNarudzbe { get; set; }


    }
}
