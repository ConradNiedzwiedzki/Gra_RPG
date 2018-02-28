using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilnikGry
{
    class Swiat
    {
        public static readonly List<Przedmiot> Przedmioty = new List<Przedmiot>();
        public static readonly List<Potwor> Potwory = new List<Potwor>();
        public static readonly List<Zadanie> Zadania = new List<Zadanie>();
        public static readonly List<Lokalizacja> Lokalizacje = new List<Lokalizacja>();

        public const int ID_PRZEDMIOTU_ZARDZEWIALY_MIECZ = 1;
        public const int ID_PRZEDMIOTU_SZCZURZY_OGON = 2;
        public const int ID_PRZEDMIOTU_KAWALEK_FUTRA = 3;
        public const int ID_PRZEDMIOTU_KIEL_WEZA = 4;
        public const int ID_PRZEDMIOTU_SKORA_WEZA = 5;
        public const int ID_PRZEDMIOTU_MACZUGA = 6;
        public const int ID_PRZEDMIOTU_MIKSTURA_LECZENIA = 7;
        public const int ID_PRZEDMIOTU_KIEL_PAJAKA = 8;
        public const int ID_PRZEDMIOTU_PAJECZYNA = 9;
        public const int ID_PRZEDMIOTU_PRZEPUSTKA = 10;

        public const int ID_POTWORA_SZCZUR = 1;
        public const int ID_POTWORA_WAZ = 2;
        public const int ID_POTWORA_WIELKI_PAJAK = 3;

        public const int ID_ZADANIA_OCZYSC_OGROD_ALECHEMIKA = 1;
        public const int ID_ZADANIA_OCZYSC_POLE_ROLNIKA = 2;

        public const int ID_LOKALIZACJI_DOM = 1;
        public const int ID_LOKALIZACJI_RYNEK_MIASTA = 2;
        public const int ID_LOKALIZACJI_POSTERUNEK_STRAZNICZY = 3;
        public const int ID_LOKALIZACJI_DOM_ALCHEMIKA = 4;
        public const int ID_LOKALIZACJI_OGROD_ALCHEMIKA = 5;
        public const int ID_LOKALIZACJI_CHATA_ROLNIKA = 6;
        public const int ID_LOKALIZACJI_POLE_ROLNIKA = 7;
        public const int ID_LOKALIZACJI_MOST = 8;
        public const int ID_LOKALIZACJI_POLE_PAJAKOW = 9;

        static Swiat()
        {
            UzupelnijPrzedmioty();
            UzupelnijPotwory();
            UzupelnijZadania();
            UzupelnijLokalizacje();
        }

        private static void UzupelnijPrzedmioty()
        {
            Przedmioty.Add(new Bron(ID_PRZEDMIOTU_ZARDZEWIALY_MIECZ, "Zardzewiały miecz", "Zardzewiałe miecze", 0, 5));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_SZCZURZY_OGON, "Szczurzy ogon", "Szczurze ogony"));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_KAWALEK_FUTRA, "Kawałek futra", "Kawałki futra"));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_KIEL_WEZA, "Kieł węża", "Kły węża"));
            Przedmioty.Add(new Bron(ID_PRZEDMIOTU_MACZUGA, "Maczuga", "Maczugi", 3, 10));
            Przedmioty.Add(new MiksturaLeczenia(ID_PRZEDMIOTU_MIKSTURA_LECZENIA, "Mikstura leczenia", "Mikstury leczenia", 5));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_KIEL_PAJAKA, "Kieł pająka", "Kły pająka"));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_PAJECZYNA, "Pajęczyna", "Pajęczyny"));
            Przedmioty.Add(new Przedmiot(ID_PRZEDMIOTU_PRZEPUSTKA, "Przepustka", "Przepustka"));
        }

        private static void UzupelnijPotwory()
        {
            Potwor szczur = new Potwor(ID_POTWORA_SZCZUR, "Szczur", 5, 3, 10, 3, 3);
            szczur.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_SZCZURZY_OGON), 75, false));
            szczur.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_KAWALEK_FUTRA), 75, true));

            Potwor waz = new Potwor(ID_POTWORA_WAZ, "Wąż", 5, 3, 10, 3, 3);
            waz.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_KIEL_WEZA), 75, false));
            waz.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_SKORA_WEZA), 75, true));

            Potwor wielkiPajak = new Potwor(ID_POTWORA_WIELKI_PAJAK, "Wielki pająk", 20, 5, 40, 10, 10);
            wielkiPajak.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_KIEL_PAJAKA), 75, true));
            wielkiPajak.TabelaLupu.Add(new PrzedmiotLupu(PrzedmiotPoID(ID_PRZEDMIOTU_PAJECZYNA), 25, false));

            Potwory.Add(szczur);
            Potwory.Add(waz);
            Potwory.Add(wielkiPajak);
        }

        private static void UzupelnijZadania()
        {
            Zadanie oczyscOgrodAlchemika = new Zadanie(ID_ZADANIA_OCZYSC_OGROD_ALECHEMIKA, "Oczyść ogród alchemika", "Zabij trzy szczury, które zalęgły się w ogrodzie alchemika i przynieś mu 3 szczurze ogony. W nagrodę otrzymasz miksturę lezenia i 10 kawałków złota.", 20, 10);
            oczyscOgrodAlchemika.PrzedmiotyDoWykonaniaZadania.Add(new PrzedmiotyDoWykonaniaZadania(PrzedmiotPoID(ID_PRZEDMIOTU_SZCZURZY_OGON), 3));
            oczyscOgrodAlchemika.PrzedmiotNagroda = PrzedmiotPoID(ID_PRZEDMIOTU_MIKSTURA_LECZENIA);

            Zadanie oczyscPoleRolnika = new Zadanie(ID_ZADANIA_OCZYSC_POLE_ROLNIKA, "Oczyść pole rolnika", "Zabij węże, które zaległy się na polu rolnika i przynieś mu 3 kły. W nagrodę otrzymasz przepustkę i 20 kawałków złota.", 20, 20);
            oczyscPoleRolnika.PrzedmiotyDoWykonaniaZadania.Add(new PrzedmiotyDoWykonaniaZadania(PrzedmiotPoID(ID_PRZEDMIOTU_KIEL_WEZA), 3));
            oczyscPoleRolnika.PrzedmiotNagroda = PrzedmiotPoID(ID_PRZEDMIOTU_PRZEPUSTKA);

            Zadania.Add(oczyscOgrodAlchemika);
            Zadania.Add(oczyscPoleRolnika);
        }

        private static void UzupelnijLokalizacje()
        {
            // Stworzenie lokalizacji
            Lokalizacja dom = new Lokalizacja(ID_LOKALIZACJI_DOM, "Dom", "Twój dom. Serio.. Powinieneś tu posprzątać.");
            Lokalizacja rynekMiasta = new Lokalizacja(ID_LOKALIZACJI_RYNEK_MIASTA, "Rynek miasta", "Widzisz fontannę.");
            Lokalizacja domAlchemika = new Lokalizacja(ID_LOKALIZACJI_DOM_ALCHEMIKA, "Dom alchemika", "Na półkach jest bardzo dużo dziwnych roślin,");
            domAlchemika.DostepneZadanieTegoMiejsca = ZadaniePoID(ID_ZADANIA_OCZYSC_OGROD_ALECHEMIKA);
            Lokalizacja ogrodAlchemika = new Lokalizacja(ID_LOKALIZACJI_OGROD_ALCHEMIKA, "Ogród alchemika", "Rośnie tu bardzo dużo gatunków roślin.");
            ogrodAlchemika.PotworZyjacyWTymMiejscu = PotworPoID(ID_POTWORA_SZCZUR);
            Lokalizacja chataRolnika = new Lokalizacja(ID_LOKALIZACJI_CHATA_ROLNIKA, "Chata rolnika", "Mała chotka z rolnikiem naprzeciwko.");
            chataRolnika.DostepneZadanieTegoMiejsca = ZadaniePoID(ID_ZADANIA_OCZYSC_POLE_ROLNIKA);
            Lokalizacja poleRolnika = new Lokalizacja(ID_LOKALIZACJI_POLE_ROLNIKA, "Pole rolnika", "Widzisz mnóstwo najróżniejszych warzyw.");
            poleRolnika.PotworZyjacyWTymMiejscu = PotworPoID(ID_POTWORA_WAZ);
            Lokalizacja posterunekStrazniczy = new Lokalizacja(ID_LOKALIZACJI_POSTERUNEK_STRAZNICZY, "Posterunek stażniczy", "Widisz wielkiego strażnika-twardziela");
            Lokalizacja most = new Lokalizacja(ID_LOKALIZACJI_MOST, "Most", "Kamienny most, przechodzący przez szeroką rzekę.");
            Lokalizacja polePajakow = new Lokalizacja(ID_LOKALIZACJI_POLE_PAJAKOW, "Las", "Widzisz mnóstwo wielkich pajęczyn na drzewach.");
            polePajakow.PotworZyjacyWTymMiejscu = PotworPoID(ID_POTWORA_WIELKI_PAJAK);

            // Połączenia lokalizacji
        }
    }
}
