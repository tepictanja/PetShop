SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

create schema if not exists `petshop` default character set utf8 ;
use `petshop` ;

create table if not exists `petshop`.`Kategorija` (
	`idKategorije` int not null,
    `kategorija` varchar(99) not null,
    primary key (`idKategorije`))
engine = InnoDB;

insert into kategorija(idKategorije, kategorija) values ('1', 'Hrana');
insert into kategorija(idKategorije, kategorija) values ('2', 'Oprema');
insert into kategorija(idKategorije, kategorija) values ('3', 'Igracke');

create table if not exists `petshop`.`VrstaLjubimca` (
	`idVrste` int not null,
    `vrsta` varchar(99) not null,
    primary key (`idVrste`))
engine = InnoDB;

insert into vrstaljubimca(idVrste, vrsta) values ('1', 'Psi');
insert into vrstaljubimca(idVrste, vrsta) values ('2', 'Macke');
insert into vrstaljubimca(idVrste, vrsta) values ('3', 'Ptice');
insert into vrstaljubimca(idVrste, vrsta) values ('4', 'Male zivotinje');

create table if not exists `petshop`.`Proizvod` (
	`sifra` int not null,
    `naziv` varchar(99) not null,
    `opis` varchar(255) not null,
    `fajl` varchar(255) not null,
    `idKategorije` int not null,
    `idVrste` int not null,
    primary key (`sifra`),
	constraint `fk_proizvod_kategorija1` 
	foreign key(`idKategorije`)
    references `petshop`.`Kategorija` (`idKategorije`)
    on delete no action
    on update no action,
	constraint `fk_proizvod_vrsta1` 
	foreign key(`idVrste`)
    references `petshop`.`VrstaLjubimca` (`idVrste`)
    on delete no action
    on update no action)
engine = InnoDB;

create table if not exists `petshop`.`Instanca` (
	`idInstance` int not null auto_increment,
    `kolicina` int not null,
    `cijena` int not null,
    `sifra` int not null,
    primary key (`idInstance`),
	constraint `fk_instanca_proizvod1` 
	foreign key(`sifra`)
    references `petshop`.`Proizvod` (`sifra`)
)
ENGINE = InnoDB;


create table if not exists `petshop`.`Korpa` (
    `idInstance` int not null,
    `sifra` int not null,
    `kolicina` int not null,
    primary key (`idInstance`, `sifra`),
	constraint `fk_korpa_instanca` 
	foreign key(`idInstance`)
    references `petshop`.`Instanca` (`idInstance`),
    constraint `fk_korpa_proizvod` 
	foreign key(`sifra`)
    references `petshop`.`Proizvod` (`sifra`)
)
ENGINE = InnoDB;

create table if not exists `petshop`.`Grad` (
	`postanskiBroj` int not null,
    `ime` VARCHAR(45) not null,
    primary key (`postanskiBroj`))
engine = InnoDB;

insert into grad(postanskiBroj, ime) values ('78000', 'Banja Luka');
insert into grad(postanskiBroj, ime) values ('76300', 'Bijeljina');
insert into grad(postanskiBroj, ime) values ('74000', 'Doboj');
insert into grad(postanskiBroj, ime) values ('89101', 'Trebinje');

create table if not exists `petshop`.`Adresa` (
	`idAdrese` int not null  auto_increment,
    `ulica` varchar(45) not null,
    `broj` int not  null,
    `postanskiBroj` int not null,
    PRIMARY KEY (`idAdrese`),
	constraint `fk_adresa_grad1`
    foreign key (`postanskiBroj`)
    references `petshop`.`Grad` (`postanskiBroj`)
) 
ENGINE = InnoDB;

create table if not exists `petshop`.`StatusNarudzbe` (
	`idStatusaNarudzbe` int not null,
    `statusNarudzbe` varchar(99) not null,
    primary key (`idStatusaNarudzbe`)
)
engine = InnoDB;

insert into statusnarudzbe(idStatusaNarudzbe, statusNarudzbe) values ('1', 'Neisporuceno');
insert into statusnarudzbe(idStatusaNarudzbe, statusNarudzbe) values ('2', 'Isporuceno');
insert into statusnarudzbe(idStatusaNarudzbe, statusNarudzbe) values ('3', 'Otkazano');

create table if not exists `petshop`.`NacinPlacanja` (
	`idNacinaPlacanja` int not null,
    `nacinPlacanja` varchar(99) not null,
    primary key (`idNacinaPlacanja`))
ENGINE = InnoDB;

insert into nacinplacanja(idNacinaPlacanja, nacinPlacanja) values ('1', 'Pouzecem');
insert into nacinplacanja(idNacinaPlacanja, nacinPlacanja) values ('2', 'Karticno');

create table if not exists `petshop`.`StatusDostave` (
	`idStatusaDostave` int not null,
    `statusDostave` varchar(99) not null,
    primary key (`idStatusaDostave`))
engine = InnoDB;

insert into statusdostave(idStatusaDostave, statusDostave) values ('1', 'Nije dostavljeno');
insert into statusdostave(idStatusaDostave, statusDostave) values ('2', 'Dostavljeno');
insert into statusdostave(idStatusaDostave, statusDostave) values ('3', 'Otkazano');

create table if not exists `petshop`.`VrstaDostave` (
	`idVrsteDostave` int not null,
    `vrstaDostave` varchar(99) not null,
    primary key (`idVrsteDostave`))
engine = InnoDB;

insert into vrstadostave(idVrsteDostave, vrstaDostave) values ('1', '1 dan');
insert into vrstadostave(idVrsteDostave, vrstaDostave) values ('2', '7 dana');

create table if not exists `petshop`.`Dostava` (
	`idDostave` int not null auto_increment,
    `cijena` int not null,
    `idVrsteDostave` int not null,
    `idStatusaDostave` int not null,
    primary key (`idDostave`),
	constraint `fk_dostava_vrsta_dostave1`
    foreign key (`idVrsteDostave`)
    references `petshop`.`VrstaDostave` (`idVrsteDostave`),
	constraint `fk_dostava_status_dostave1`
    foreign key (`idStatusaDostave`)
    references `petshop`.`StatusDostave` (`idStatusaDostave`))    
engine = InnoDB;

insert into dostava(cijena, idVrsteDostave, idStatusaDostave) values ('10', '1', '1');
insert into dostava(cijena, idVrsteDostave, idStatusaDostave) values ('7', '2', '1');
insert into dostava(cijena, idVrsteDostave, idStatusaDostave) values ('10', '1', '3');
insert into dostava(cijena, idVrsteDostave, idStatusaDostave) values ('7', '2', '3');

create table if not exists `petshop`.`Kupac` (
	`idKupca` int not null auto_increment,
    `ime` varchar(45) not null,
    `prezime` varchar(45) not null,
    `korisnickoIme` varchar(45) not null,
    `lozinka` varchar(15) not null,
    primary key (`idKupca`))
engine = InnoDB;

create table if not exists `petshop`.`Narudzba` (
	`idNarudzbe` int not null auto_increment,
    `ime` varchar(45) not null, 
    `prezime` varchar(45) not null, 
    `datumNarudzbe` varchar(30) not null,
    `brojTelefona` varchar(11)  not null,
    `brojKartice` varchar(13) null, 
    `idKupca` int not null,
    `idAdrese` int not null, 
    `idNacinaPlacanja` int not null, 
    `idDostave` int not null, 
    `idStatusaNarudzbe` int not null, 
    primary key(`idNarudzbe`),
    constraint`fk_narudzba_kupac1`
	foreign key(`idKupca`)
	references`petshop`.`Kupac` (`idKupca`),
	constraint `fk_narudzba_adresa1`
	foreign key(`idAdrese`)
	references`petshop`.`Adresa` (`idAdrese`),
	constraint `fk_narudzba_nacina_placanja1`
	foreign key(`idNacinaPlacanja`)
	references `petshop`.`NacinPlacanja` (`idNacinaPlacanja`),
	constraint `fk_narudzba_dostava1`
	foreign key (`idDostave`)
	references `petshop`.`Dostava` (`idDostave`),
	constraint `fk_narudzba_status_narudzbe1`
	foreign key (`idStatusaNarudzbe`)
	references `petshop`.`StatusNarudzbe` (`idStatusaNarudzbe`)
)
engine= InnoDB;

create table if not exists `petshop`.`NaruceniProizvodi` (
        `idNarudzbe` int not null,
        `idInstance` int not null,
        `ukupnaKolicina` int not null,
        `ukupnaCijena` int null,
        primary key (`idNarudzbe`, `idInstance`),
        constraint`fk_naruceni_proizvodi_narudzba1`
		foreign key(`idNarudzbe`)
		references`petshop`.`Narudzba` (`idNarudzbe`),
		constraint`fk_naruceni_proizvodi_instanca1`
		foreign key(`idInstance`)
		references`petshop`.`Instanca` (`idInstance`)
)
engine= InnoDB;
    
create table if not exists `petshop`.`Administrator` (
		`idAdmina` int not null,
        `ime` varchar(45) not null,
        `korisnickoIme` varchar(45) not null,
        `lozinka` varchar(33) not null,
        `mail` varchar(99) not null,
        primary key(`idAdmina`))
engine= InnoDB;
    
insert into administrator(idAdmina, ime, korisnickoIme, lozinka, mail) values ('1', 'Tanja Tepic', 'root', 'ta20nja37te', 'tepictanja1146@gmail.com'); 
    
create table if not exists `petshop`.`Tema` (
		`idTeme` int not null,
        primary key(`idTeme`))
engine= InnoDB;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;