using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace PetShop
{
    static class DB_PetShop
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlHciPetShop"].ConnectionString;

        public static void UnesiKupca(Kupac kupac)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Kupac(ime, prezime, korisnickoIme, lozinka)
                  VALUES (@ime, @prezime, @korisnickoIme, @lozinka)";
            cmd.Parameters.AddWithValue("@ime", kupac.ime);
            cmd.Parameters.AddWithValue("@prezime", kupac.prezime);
            cmd.Parameters.AddWithValue("@korisnickoIme", kupac.korisnickoIme);
            cmd.Parameters.AddWithValue("@lozinka", kupac.lozinka);
            cmd.ExecuteNonQuery();
            kupac.idKupca = (int)cmd.LastInsertedId;
            conn.Close();
        }
        public static List<Proizvod> GetProizvodi(int idKategorije, int idVrste)
        {
            List<Proizvod> result = new List<Proizvod>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT sifra, naziv, opis, fajl, idKategorije, idVrste FROM `Proizvod` WHERE idKategorije=@idKategorije and idVrste=@idVrste";
            cmd.Parameters.AddWithValue("@idKategorije", idKategorije);
            cmd.Parameters.AddWithValue("@idVrste", idVrste);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Proizvod()
                {
                    sifra = reader.GetInt32(0),
                    naziv = reader.GetString(1),
                    opis = reader.GetString(2),
                    fajl = reader.GetString(3),
                    idKategorije = reader.GetInt32(4),
                    idVrste = reader.GetInt32(5)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Administrator> GetAdmin()
        {
            List<Administrator> result = new List<Administrator>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Administrator";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Administrator()
                {
                    idAdmina = reader.GetInt32(0),
                    ime = reader.GetString(1),
                    korisnickoIme = reader.GetString(2),
                    mail = reader.GetString(3),
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteInstancaBySifra(int sifra)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Instanca WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteProizvodBySifra(int sifra)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Proizvod WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AzurirajKolicinu(int sifra, int kolicina)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Instanca SET kolicina=@kolicina WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@kolicina", kolicina);
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AzurirajCijenu(int sifra, int cijena)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Instanca SET cijena=@cijena WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@cijena", cijena);
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UnesiProizvod(Proizvod proizvod)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Proizvod(sifra, naziv, opis, fajl, idKategorije, idVrste)
                  VALUES (@sifra, @naziv, @opis, @fajl, @idKategorije, @idVrste)";
            cmd.Parameters.AddWithValue("@sifra", proizvod.sifra);
            cmd.Parameters.AddWithValue("@naziv", proizvod.naziv);
            cmd.Parameters.AddWithValue("@opis", proizvod.opis);
            cmd.Parameters.AddWithValue("@fajl", proizvod.fajl);
            cmd.Parameters.AddWithValue("@idKategorije", proizvod.idKategorije);
            cmd.Parameters.AddWithValue("@idVrste", proizvod.idVrste);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void UnesiInstancu(Instanca instanca)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Instanca(kolicina, cijena, sifra)
                  VALUES (@kolicina, @cijena, @sifra)";
            cmd.Parameters.AddWithValue("@kolicina", instanca.kolicina);
            cmd.Parameters.AddWithValue("@cijena", instanca.cijena);
            cmd.Parameters.AddWithValue("@sifra", instanca.sifra);
            cmd.ExecuteNonQuery();
            instanca.idInstance = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static Instanca GetInstanca(int sifra)
        {
            Instanca result = new Instanca();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idInstance, kolicina, cijena, sifra FROM `Instanca` WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.idInstance = reader.GetInt32(0);
                result.kolicina = reader.GetInt32(1);
                result.cijena = reader.GetInt32(2);
                result.sifra = reader.GetInt32(3);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static Proizvod GetProizvod(int sifra)
        {
            Proizvod result = new Proizvod();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT sifra, naziv, opis, fajl, idKategorije, idVrste FROM `Proizvod` WHERE sifra = @sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.sifra = reader.GetInt32(0);
                result.naziv = reader.GetString(1);
                result.opis = reader.GetString(2);
                result.fajl = reader.GetString(3);
                result.idKategorije = reader.GetInt32(4);
                result.idVrste = reader.GetInt32(5);
                return result;
            }
            reader.Close();
            conn.Close();
            return null;
        }

        public static void InsertKorpa(Korpa korpa)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Korpa(idInstance, sifra, kolicina)
                  VALUES (@idInstance, @sifra, @kolicina)";
            cmd.Parameters.AddWithValue("@idInstance", korpa.idInstance);
            cmd.Parameters.AddWithValue("@sifra", korpa.sifra);
            cmd.Parameters.AddWithValue("@kolicina", korpa.kolicina);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void AzurirajKorpu(int sifra, int kolicina)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Korpa SET kolicina=@kolicina WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@kolicina", kolicina);
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static Korpa GetKorpa(int sifra)
        {
            Korpa result = new Korpa();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idInstance, sifra, kolicina FROM `Korpa` WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.idInstance = reader.GetInt32(0);
                result.sifra = reader.GetInt32(1);
                result.kolicina = reader.GetInt32(2);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Korpa> GetSadrzajKorpe()
        {
            List<Korpa> result = new List<Korpa>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `Korpa`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Korpa()
                {
                    idInstance = reader.GetInt32(0),
                    sifra = reader.GetInt32(1),
                    kolicina = reader.GetInt32(2),
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteKorpa()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `Korpa`";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void DeleteKorpaBySifra(int sifra)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Korpa WHERE sifra=@sifra";
            cmd.Parameters.AddWithValue("@sifra", sifra);
            cmd.ExecuteNonQuery();
        }

        public static Kupac GetKupac(string korisnickoIme)
        {
            Kupac result = new Kupac();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idKupca, ime, prezime, korisnickoIme, lozinka FROM `Kupac` WHERE korisnickoIme=@korisnickoIme";
            cmd.Parameters.AddWithValue("@korisnickoIme", korisnickoIme);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.idKupca = reader.GetInt32(0);
                result.ime = reader.GetString(1);
                result.prezime = reader.GetString(2);
                result.korisnickoIme = reader.GetString(3);
                result.lozinka = reader.GetString(4);
                return result;
            }
            reader.Close();
            conn.Close();
            return null;
        }

        public static void InsertAdresa(Adresa adresa)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Adresa(ulica, broj, postanskiBroj)
                  VALUES (@ulica, @broj, @postanskiBroj)";
            cmd.Parameters.AddWithValue("@ulica", adresa.ulica);
            cmd.Parameters.AddWithValue("@broj", adresa.broj);
            cmd.Parameters.AddWithValue("@postanskiBroj", adresa.postanskiBroj);
            cmd.ExecuteNonQuery();
            adresa.idAdrese = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static int GetIdNacinaPlacanja(string nacinPlacanja)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idNacinaPlacanja FROM `NacinPlacanja` WHERE nacinPlacanja=@nacinPlacanja";
            cmd.Parameters.AddWithValue("@nacinPlacanja", nacinPlacanja);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static int GetIdVrsteDostave(string vrstaDostave)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idVrsteDostave FROM `VrstaDostave` WHERE vrstaDostave=@vrstaDostave";
            cmd.Parameters.AddWithValue("@vrstaDostave", vrstaDostave);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static int GetIdDostave(string vrstaDostave, int idStatusaDostave)
        {
            int idvd = DB_PetShop.GetIdVrsteDostave(vrstaDostave);
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idDostave FROM `Dostava` WHERE idVrsteDostave=@idvd and idStatusaDostave =@idStatusaDostave";
            cmd.Parameters.AddWithValue("@idvd", idvd);
            cmd.Parameters.AddWithValue("@idStatusaDostave", idStatusaDostave);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static int GetIdAdrese(string ulica, int broj, int postanskiBroj)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idAdrese FROM `Adresa` WHERE ulica=@ulica and broj =@broj and postanskiBroj=@postanskiBroj";
            cmd.Parameters.AddWithValue("@ulica", ulica);
            cmd.Parameters.AddWithValue("@broj", broj);
            cmd.Parameters.AddWithValue("@postanskiBroj", postanskiBroj);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static Grad GetGrad(string ime)
        {
            Grad result = new Grad();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT postanskiBroj, ime FROM `Grad` WHERE ime=@ime";
            cmd.Parameters.AddWithValue("@ime", ime);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.postanskiBroj = reader.GetInt32(0);
                result.ime = reader.GetString(1);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void InsertNarudzba(Narudzba narudzba)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Narudzba(ime, prezime, datumNarudzbe, brojTelefona, brojKartice, idKupca, idAdrese, idNacinaPlacanja, idDostave, idStatusaNarudzbe)
                  VALUES (@ime, @prezime, @datumNarudzbe, @brojTelefona, @brojKartice, @idKupca, @idAdrese, @idNacinaPlacanja, @idDostave, @idStatusaNarudzbe)";
            cmd.Parameters.AddWithValue("@ime", narudzba.ime);
            cmd.Parameters.AddWithValue("@prezime", narudzba.prezime);
            cmd.Parameters.AddWithValue("@datumNarudzbe", narudzba.datumNarudzbe);
            cmd.Parameters.AddWithValue("@brojTelefona", narudzba.brojTelefona);
            cmd.Parameters.AddWithValue("@brojKartice", narudzba.brojKartice);
            cmd.Parameters.AddWithValue("@idKupca", narudzba.idKupca);
            cmd.Parameters.AddWithValue("@idAdrese", narudzba.idAdrese);
            cmd.Parameters.AddWithValue("@idNacinaPlacanja", narudzba.idNacinaPlacanja);
            cmd.Parameters.AddWithValue("@idDostave", narudzba.idDostave);
            cmd.Parameters.AddWithValue("@idStatusaNarudzbe", narudzba.idStatusaNarudzbe);
            cmd.ExecuteNonQuery();
            narudzba.idNarudzbe = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static Narudzba GetNarudzba(int idNarudzbe)
        {
            Narudzba result = new Narudzba();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `Narudzba` WHERE idNarudzbe=@idNarudzbe";
            cmd.Parameters.AddWithValue("@idNarudzbe", idNarudzbe);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                result.idNarudzbe = reader.GetInt32(0);
                result.ime = reader.GetString(1);
                result.prezime = reader.GetString(2);
                result.datumNarudzbe = reader.GetString(3);
                result.brojTelefona = reader.GetString(4);
                result.brojKartice = reader.GetString(5);
                result.idKupca = reader.GetInt32(6);
                result.idAdrese = reader.GetInt32(7);
                result.idNacinaPlacanja = reader.GetInt32(8);
                result.idDostave = reader.GetInt32(9);
                result.idStatusaNarudzbe = reader.GetInt32(10);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Narudzba> GetSveNarudzbe()
        {
            List<Narudzba> result = new List<Narudzba>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `Narudzba`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Narudzba()
                {
                    idNarudzbe = reader.GetInt32(0),
                    ime = reader.GetString(1),
                    prezime = reader.GetString(2),
                    datumNarudzbe = reader.GetString(3),
                    brojTelefona = reader.GetString(4),
                    brojKartice = reader.GetString(5),
                    idKupca = reader.GetInt32(6),
                    idAdrese = reader.GetInt32(7),
                    idNacinaPlacanja = reader.GetInt32(8),
                    idDostave = reader.GetInt32(9),
                    idStatusaNarudzbe = reader.GetInt32(10)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void UnesiNaruceniProizvod(NaruceniProizvod n)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO NaruceniProizvodi(idNarudzbe, idInstance, ukupnaKolicina, ukupnaCijena)
                  VALUES (@idNarudzbe, @idInstance, @ukupnaKolicina, @ukupnaCijena)";
            cmd.Parameters.AddWithValue("@idNarudzbe", n.idNarudzbe);
            cmd.Parameters.AddWithValue("@idInstance", n.idInstance);
            cmd.Parameters.AddWithValue("@ukupnaKolicina", n.ukupnaKolicina);
            cmd.Parameters.AddWithValue("@ukupnaCijena", n.ukupnaCijena);
            cmd.ExecuteNonQuery();
            n.idInstance = (int)cmd.LastInsertedId;
            conn.Close();
        }

        public static int GetIdStatusaNarudzbe(string statusNarudzbe)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idStatusaNarudzbe FROM `StatusNarudzbe` WHERE statusNarudzbe=@statusNarudzbe";
            cmd.Parameters.AddWithValue("@statusNarudzbe", statusNarudzbe);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static int GetIdStatusaDostave(string statusDostave)
        {
            int result = 0;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idStatusaDostave FROM `StatusDostave` WHERE statusDostave=@statusdostave";
            cmd.Parameters.AddWithValue("@statusDostave", statusDostave);
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }


        public static void OtkaziNarudzbu(int idNarudzbe, string vrstaDostave)
        {
            int ids = DB_PetShop.GetIdStatusaNarudzbe("Otkazano");
            int idd = DB_PetShop.GetIdStatusaDostave("Otkazano");
            int idSDostave = DB_PetShop.GetIdDostave(vrstaDostave, idd);
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE Narudzba SET idStatusaNarudzbe=@ids, idDostave=@idSDostave WHERE idNarudzbe=@idNarudzbe";
            cmd.Parameters.AddWithValue("@ids", ids);
            cmd.Parameters.AddWithValue("@idSDostave", idSDostave);
            cmd.Parameters.AddWithValue("@idNarudzbe", idNarudzbe);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertTema(int idTeme)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO Tema(idTeme)
                  VALUES (@idTeme)";
            cmd.Parameters.AddWithValue("@idTeme", idTeme);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static int GetTema()
        {
            int result = -1;
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `Tema`";
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetInt32(0);
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static void DeleteTema()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM `Tema`";
            cmd.ExecuteNonQuery();
            conn.Close();


        }
    }
}
