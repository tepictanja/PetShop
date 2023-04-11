using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    internal class Korpa
    {
        public int idInstance { get; set; }
        public int sifra { get; set; }
        public int kolicina { get; set; }

        public static int GetSifra(int br)
        {
            List<Korpa> korpa = DB_PetShop.GetSadrzajKorpe();
            for (int i = 0; i < korpa.Count; i++)
            {
                if (i == br)
                    return korpa[i].sifra;
            }
            return 0;
        }

    }
}
