using System;
using System.Diagnostics;
using System.Threading;

namespace Maturita_2020_Tridy
{
    //Input, ktery resi user errory a opakuje moznost zadani, dokud uzivatel nezada spravne. Odpoved je ulozena do stringu s nazvem ==> Secured_(String nebo double podle metody)_Output.
    public class Secured_Input_Class
    {
        // Proměné daného typu, které se vrací po proběhnutí jejich metody
        private string Secured_String_Output;
        private double Secured_Double_Output;
        private int Secured_Int_Output;
        // Boolean který funguje jako podmínka pro běh cyklu
        private bool Zadani_Hotovo = true;

        // Metoda pro osetrene zadavani uzivatelskych vstupu do stringu
        public string Secured_Input_Character(string Lowr_Or_Upper)
        {
            while (Zadani_Hotovo)
            {
                // Volba mezi ToLower a ToUpper => do 1. argumentu patri volba "L" pro ToLower nebo "U" pro ToUpper
                if (Lowr_Or_Upper == "L")
                {
                    // Usměrnění obsahu stringu do malých písmen
                    Secured_String_Output = Console.ReadLine().ToLower();
                    break;
                }
                else if (Lowr_Or_Upper == "U")
                {
                    // Usměrnění obsahu stringu do velkých písmen
                    Secured_String_Output = Console.ReadLine().ToUpper();
                    break;
                }
                else
                    continue;
            }
            // Vrácení stringu po operaci
            return Secured_String_Output;
        }


        //Zadani cisla do stringu a nasledne naparsovani do DOUBLE
        public double Secured_Input_Double()
        {
            // Cyklus while, který se opakuje dokud uživatel nezadá vstup, který jde přeparsovat na číslo.
            while (!double.TryParse(Console.ReadLine(), out Secured_Double_Output))
            {
                // Metoda Error_message, která změmní barvu na červenou a vypíše chybu
                var Err = new Error_message();
                Err.Err_msg("R", "Zadejte prosim cislo. Zkuste to znovu: ");
            }
            // Vrácení double po operaci
            return Secured_Double_Output;
        }

        //Zadani cisla do stringu a nasledne naparsovani do INT
        public int Secured_Input_Int()
        {
            // Cyklus while, který se opakuje dokud uživatel nezadá vstup, který jde přeparsovat na číslo.
            while (!int.TryParse(Console.ReadLine(), out Secured_Int_Output))
            {
                // Metoda Error_message, která změmní barvu na červenou a vypíše chybu
                var Err = new Error_message();
                Err.Err_msg("R", "Zadejte prosim cislo. Zkuste to znovu: ");
            }
            // Vrácení integer po operaci
            return Secured_Int_Output;
        }
    }

    //Trida vypocita faktorial.
    public class Faktorial
    {
        // Deklarace proměných pro třídu
        private int Zaklad, Vysledek = 1, Pocitadlo, Temp;

        //Vypocita faktorial, s parametrem funce (Zaklad)
        public void Faktorial_Vypocet_For()
        {
            // Deklarace třídy pro ošetřené vstupy
            var Input = new Secured_Input_Class();
            Console.Write("Zadejte cele, kladne cislo pro faktorializaci: ");
            // Cyklus while, 
            while (true)
            {
                Zaklad = Input.Secured_Input_Int();
                if (Zaklad != 0 && Zaklad > 0)
                {
                    Temp = Zaklad;
                    break;
                }
            }
            for (Pocitadlo = 1; Pocitadlo <= Zaklad; Pocitadlo++)
            {
                Vysledek *= Pocitadlo;
            }
            Console.WriteLine("Faktorial {0} je {1}.", Temp, Vysledek);

            if (Vysledek == 10)
            {
                Console.WriteLine("Vysledek je 0 jelikoz jeho hodnota prekracuje maximalni hodnotu ktera je v rosahu int...");
            }
        }

        public void Faktorial_Vypocet_While()
        {
            var Input = new Secured_Input_Class();
            Console.Write("Zadejte cele, kladne cislo pro faktorializaci: ");
            while (true)
            {
                Zaklad = Input.Secured_Input_Int();
                if (Zaklad != 0 && Zaklad > 0)
                {
                    Temp = Zaklad;
                    break;
                }
            }
            Pocitadlo = 1;
            while (Pocitadlo <= Zaklad)
            {
                Vysledek *= Pocitadlo;
                Pocitadlo++;
            }
            Console.WriteLine("Faktorial {0} je {1}.", Temp, Vysledek);

            if (Vysledek == 10)
            {
                Console.WriteLine("Vysledek je 0 jelikoz jeho hodnota prekracuje maximalni hodnotu ktera je v rosahu int...");
            }
        }
    }

    //Trida s kompletni kalkulackou v modre barve.
    public class Kalkulacka
    {
        public double X;
        public string Xs;
        public double Y;
        public double vysledek;
        public string Ys;
        public string jmeno;
        public string volba;
        public bool err = true;
        private bool splneno = false;
        private bool Xsplneno = true;
        private bool Ysplneno = true;

        //Metoda pro zadani neznamych pomoci parsovani ze stringu
        private void Zadani_Neznamych()
        {
            while (splneno == false)
            {
                Console.Write("Zadejte prvni promenou X: ");
                Xs = Console.ReadLine();
                if (!double.TryParse(Xs, out X))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zadany typ musi byt cislo!");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Xsplneno = false;
                }
                else
                {
                    Xsplneno = true;
                }
                Console.Write("Ted zadejte druhou promenou Y: ");
                Ys = Console.ReadLine();
                if (!double.TryParse(Ys, out Y))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zadany typ musi byt cislo!");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Ysplneno = false;
                }
                else
                {
                    Ysplneno = true;
                }
                if (Xsplneno == true && Ysplneno == true)
                {
                    splneno = true;
                    Console.WriteLine("\nDekuji za zadani promenych.");
                }
                else
                {
                    splneno = false;
                }
            }
        }

        //Zvoleni pocetni operace pomoci zadani do stringu
        private void Zvoleni_Pocetni_Operace()
        {
            Console.WriteLine("Nyni vyberte pocetni operaci, kterou si prejete pouzit:");
            Console.WriteLine("1. Scitani =====> Scitani \n2. Odcitani =====> Odcitani \n3. Nasobeni =====> Nasobeni \n4. Deleni =====> Deleni");
            while (err == true)
            {
                Console.Write("Zvolte jednu z moznosti: ");
                volba = Console.ReadLine().ToLower();
                if (volba == "scitani" || volba == "odcitani" || volba == "nasobeni" || volba == "deleni")
                {
                    err = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vami zadana volba => {0} je neplatna!", volba);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    continue;
                }
            }
        }

        //Vypocetni cast kodu, ktera vraci vysledek zvolene operace
        private double Vypocet()
        {
            if (volba == "scitani")
            {
                vysledek = X + Y;
                return vysledek;
            }
            else if (volba == "odcitani")
            {
                vysledek = X - Y;
                return vysledek;
            }
            else if (volba == "nasobeni")
            {
                vysledek = X * Y;
                return vysledek;
            }
            else if (volba == "deleni")
            {
                vysledek = X / Y;
                return vysledek;
            }
            else
            {
                return 0;
            }
        }

        //Vypsani vysledku uzivateli
        private void Vysledek()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nVysledek {0} {1} a {2} je {3}.", volba, X, Y, vysledek);
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        //Spusti vsechny casti kalkulacky (Zadani_Nezamych, Zvoleni_Pocetni_Operace, Vypocet a Vysledek)
        public void Kalkulacka_Spusteni()
        {
            Zadani_Neznamych();
            Zvoleni_Pocetni_Operace();
            Vypocet();
            Vysledek();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    //Trida na serazovani cisel Vzestupne nebo Sestupne.
    public class Serazeni_Cisel
    {
        private static uint Pocet_Cisel = 3;
        private int Temp;
        private int[] Databaze = new int[Pocet_Cisel];
        private int Max_Cislo;
        private int Min_Cislo;

        //Metoda pro zapis poctu cisel urcenych uzivatelem do pole typu double
        private void Serazeni_Cisel_Zapis()
        {
            var Input = new Secured_Input_Class();
            for (int Pocitadlo = 0; Pocet_Cisel > Pocitadlo; Pocitadlo++)
            {
                Databaze[Pocitadlo] = Input.Secured_Input_Int();
            }
        }

        //Metoda pro serazeni cisel vzestupne pomoci bubblesortu.
        public void Serazeni_Cisel_Vzestupne()
        {
            for (int i = 0; i < Pocet_Cisel - 1; i++)
            {
                for (int j = i + 1; j < Pocet_Cisel; j++)
                {
                    if (Databaze[i] > Databaze[j])
                    {
                        Temp = Databaze[i];
                        Databaze[i] = Databaze[j];
                        Databaze[j] = Temp;
                    }
                }
            }
        }

        //Metoda pro serazeni cisel vzestupne pomoci bubblesortu.
        public void Serazeni_Cisel_Sestupne()
        {
            for (int i = 0; i < Pocet_Cisel - 1; i++)
            {
                for (int j = i + 1; j < Pocet_Cisel; j++)
                {
                    if (Databaze[i] < Databaze[j])
                    {
                        Temp = Databaze[i];
                        Databaze[i] = Databaze[j];
                        Databaze[j] = Temp;
                    }
                }
            }
        }

        //Vyber nejvetsiho cisla pomoci pozice v poli.
        private void Nejvetsi_cislo()
        {
            for (int Opakovani = 0; Pocet_Cisel > Opakovani; Opakovani++)
            {
                if (Databaze[Opakovani] > Max_Cislo)
                {
                    Max_Cislo = Databaze[Opakovani];
                }
            }
            Console.WriteLine("Nejvetsi cislo je {0}", Max_Cislo);
        }

        //Vyber nejmensiho cisla pomoci pozice v poli.
        private void Nejmensi_cislo()
        {
            for (int Opakovani = 0; Pocet_Cisel > Opakovani; Opakovani++)
            {
                if (Opakovani == 0)
                {
                    Min_Cislo = Databaze[Opakovani];
                }
                else if (Databaze[Opakovani] < Min_Cislo)
                {
                    Min_Cislo = Databaze[Opakovani];
                }
            }
            Console.WriteLine("Nejmensi cislo je {0}", Min_Cislo);
        }

        //Metoda pro vypis serazene databaze
        private void Vypis_Cisel()
        {
            Console.Write("Serazene pole: ");
            for (int Opakovani = 0; Pocet_Cisel > Opakovani; Opakovani++)
            {
                Console.Write(Databaze[Opakovani] + " ");
            }
        }

        //Metoda pro spuštění a user interfence.
        public void Serazeni_Cisel_Spusteni()
        {
            string Volba;
            var Input = new Secured_Input_Class();
            var Err = new Error_message();
            Console.WriteLine("Program po zapisu trech cisel je podle vasi volby seradi, nebo vybere nejmesi ci nejvetsi.");
            Serazeni_Cisel_Zapis();
            Console.WriteLine("Pro operaci s polem zvolte: \nPro srovnani pole napiste Vzestupne nebo Sestupne.\nPro vypis nejvetsiho a nejmensiho cisla napiste: Nejvetsi nebo Nejmensi.");
            while (true)
            {
                Volba = Input.Secured_Input_Character("L");
                if (Volba == "vzestupne")
                {
                    Serazeni_Cisel_Vzestupne();
                    Vypis_Cisel();
                    break;
                }
                else if (Volba == "sestupne")
                {
                    Serazeni_Cisel_Sestupne();
                    Vypis_Cisel();
                    break;
                }
                else if (Volba == "nejvetsi")
                {
                    Nejvetsi_cislo();
                    break;
                }
                else if (Volba == "nejmensi")
                {
                    Nejmensi_cislo();
                    break;
                }
                else
                {
                    Err.Err_msg("R", "Vami zadana volba je neplatna, zkuste to znovu!");
                    continue;
                }
            }
        }
    }

    //Trida pracujici jako taxametr. Z ujete vzdalenosti vypocita cenu dle zvolene sazby.
    public class Taxikar
    {
        private double Vzdalenost;
        private string Sazba;
        private double Cena;

        //Zvoleni delky cesty a sazby za ni
        private void Zvoleni_Vzdalenosti()
        {
            var Input = new Secured_Input_Class();
            Console.Write("Zadejte kolik Km jste ujeli: ");
            Vzdalenost = Input.Secured_Input_Double();
        }

        //Metoda pro zvoleni sazby 
        private void Zvoleni_Sazby()
        {
            var Input = new Secured_Input_Class();
            Console.WriteLine("Zvolte sazbu:\nMetropole \nMesto \nVesnice");
            Sazba = Input.Secured_Input_Character("L");
        }

        //Metoda pro výpočet ceny podle zadaného plánu. 
        private void Vypocet_Ceny()
        {
            while (true)
            {
                Zvoleni_Sazby();
                if (Sazba == "metropole")
                {
                    Cena = Vzdalenost * 130;
                    break;
                }
                else if (Sazba == "mesto")
                {
                    Cena = Vzdalenost * 100;
                    break;
                }
                else if (Sazba == "vesnice")
                {
                    Cena = Vzdalenost * 69;
                    break;
                }
                else
                {
                    Console.WriteLine("Vami zvolena moznost je neplatna");
                    continue;
                }
            }
        }

        //Metoda pro spuštění ostatních metod.
        public void Spusteni()
        {
            Zvoleni_Vzdalenosti();
            Vypocet_Ceny();
            Console.WriteLine("Cena za svezeni {0}Km je {1}Kc.", Vzdalenost, Cena);
        }
    }

    //Trida ktera z uzivatelskeho vstupu nenulovych cisel zakoncenychu nulou spocita pocet kladnych a pocet zapornych. Vysledek vypise do konzole.
    public class Nenulova_Cisla
    {
        private int Cislo_Vstup;
        private int Kladne;
        private int Zaporne;

        //Metoda pro spocitani kladných a záporných čísel, které nekončí nulou.
        public void Vypocet_Vycet_Plus_a_Minus()
        {
            var Err = new Error_message();
            var Input = new Secured_Input_Class();
            Console.WriteLine("Zadavejte kladana a zaporna cisla koncici nulou. Jakmile zadate 0,\nprogram se ukonci a vypise pocet kladnych a zapornych.");
            while ((Cislo_Vstup = Input.Secured_Input_Int()) != 0)
            {
                if ((Cislo_Vstup % 10) == 0)
                {
                    if (Cislo_Vstup > 0)
                    {
                        Kladne++;
                    }
                    else
                    {
                        Zaporne++;
                    }
                }
                else
                {
                    Err.Err_msg("R", "Vami zadane cislo nekonci nulou.");
                    continue;
                }
            }
            Console.WriteLine("Kladne {0} a zaporne {1}", Kladne, Zaporne);
        }
    }

    //Trida pro vypocitani ciferneho souctu cisla
    public class Ciferny_Soucet
    {
        private int Vstup, Soucet, Temp;
        private bool Kladne = true;

        //Metoda pro vypoctu ciferneho souctu cisla.
        public void Cif_soucet()
        {
            Console.WriteLine("Zadejte cislo a program vypise ciselny soucet.");
            var Input = new Secured_Input_Class();
            Vstup = Input.Secured_Input_Int();
            if (Vstup < 0)
            {
                Kladne = false;
                Vstup *= -1;
            }
            while (Vstup != 0)
            {
                Temp = (Vstup % 10);
                Soucet += Temp;
                Vstup /= 10;
            }
            if (!Kladne)
            {
                Soucet *= -1;
            }
            Console.WriteLine("Ciferny soucet je {0}", Soucet);
        }
    }

    //Trida pro vypocitani nejvetsiho spolecneho delitele pomoci Euklidova algoritmu
    public class Nejvetsi_Delitel
    {
        private double Vstup1, Vstup2, Temp;

        //Metoda pro vypočítání největšího společného dělitele.
        public void Nejvetsi_Spolecny_Delitel()
        {
            var Msg = new Error_message();
            var Input = new Secured_Input_Class();
            Console.WriteLine("Tento program vypise ze dvou zadanych promenych nejvetsiho spolecneho delitele.");
            Console.Write("Zadejte  prvni promenou: ");
            Vstup1 = Input.Secured_Input_Double();
            Console.Write("Zadejte  druhou promenou: ");
            Vstup2 = Input.Secured_Input_Double();
            while (Vstup2 != 0)
            {
                Temp = Vstup1 % Vstup2;
                Vstup1 = Vstup2;
                Vstup2 = Temp;
            }
            Msg.Err_msg("G", "Nejvetsi spolecny delitel je " + Vstup1);
        }
    }

    //Trida pro vypocitani prirozene mocniny z uzivatelskeho vstupu 
    public class Mocnina
    {
        private int Vstup, Temp_Vstup, Exponent, Temp_Exponent;

        //Metoda pro umocnění libovolného čísla
        public void Umocneni()
        {
            int Opakovani = 0;
            var Input = new Secured_Input_Class();
            Console.WriteLine("Program vypise mocninu z uzivatelskeho vstupu.");
            Console.Write("Zadejte mocnence: ");
            Vstup = Input.Secured_Input_Int();
            Temp_Vstup = Vstup;
            Console.Write("Zadejte exponent: ");
            Exponent = Input.Secured_Input_Int();
            Temp_Exponent = Exponent;
            do
            {
                Vstup *= Temp_Vstup;
                Opakovani++;
            } while (Exponent-- > Opakovani);
            Console.WriteLine("Vysledek mocneni {0} s exponentem {1} je {2}.", Temp_Vstup, Temp_Exponent, Vstup);
        }
    }

    //Trida pro soucet rady cisel 
    public class Soucet_Rady_Cisel
    {
        private int n, Temp;

        //Metoda pro součet řady od 0 až po n, které zadá uživatel z klávesnice
        public void Soucet_Rady()
        {
            var Input = new Secured_Input_Class();
            Console.Write("Program secte radu cisel az po cislo ktere zadate: ");
            n = Input.Secured_Input_Int();
            Temp = n;
            for (int Opakovani = 0; Temp > Opakovani; Opakovani++)
            {
                n = Opakovani + n;
            }
            Console.WriteLine("Soucet rady je {0}", n);
        }
    }

    //Trida pro serazeni nahodne vygenerovaneho pole o peti prvcich
    public class Serazeni_Rand_Arr
    {
        private static uint Pocet_Cisel = 10;
        private int[] Databaze = new int[Pocet_Cisel];

        //Metoda pro naplněním pole pseudo náhodnými hodnotami od 0 od 9.
        private void Rand_Arr()
        {
            Random random = new Random();
            for (int Opakovani = 0; Opakovani < Pocet_Cisel; Opakovani++)
            {
                Databaze[Opakovani] = random.Next(0, 9);
            }
        }

        //Metoda pro seřazení pole 
        public void Rand_Arr_Serazeni()
        {
            for (int i = 0; i < Databaze.Length - 1; i++)
            {
                int maxIndex = i;
                for (int j = i + 1; j < Databaze.Length; j++)
                {
                    if (Databaze[j] > Databaze[maxIndex]) maxIndex = j;
                }
                int tmp = Databaze[i];
                Databaze[i] = Databaze[maxIndex];
                Databaze[maxIndex] = tmp;
            }
        }

        //Metoda pro výpis nesrovnaného pole 
        private void Rand_Arr_Vypis()
        {
            for (int Opakovani = 0; Opakovani < Pocet_Cisel; Opakovani++)
            {
                Console.WriteLine("Nesrovnane pole: " + Databaze[Opakovani]);
            }
        }

        //Metoda pro výpis srovnaného pole 
        private void Sorted_Arr_Vypis()
        {
            for (int Opakovani = 0; Opakovani < Pocet_Cisel; Opakovani++)
            {
                Console.WriteLine("Srovnane pole: " + Databaze[Opakovani]);
            }
        }

        //Metoda pro spuštění programu
        public void Rand_Arr_Spusteni()
        {
            Rand_Arr();
            Rand_Arr_Vypis();
            Console.WriteLine("Nesrovnane pole....\nTed pole srovname.");
            Rand_Arr_Serazeni();
            Console.WriteLine("\nVypis srovnaneho pole: ");
            Sorted_Arr_Vypis();
        }
    }

    //Trida pro overeni zda je cislo prvocislo
    public class Prvocislo
    {
        private int Cislo_Zapis;
        //Pocitadlo pro cisla kterymi jde delit "Cislo" delit
        private int Delitelne = 0;
        private int Prvocilo;
        private bool Zadano = false;
        private string Odpoved;
        private bool zaporne = false;
        private long Cas;
        public bool Optimalizovane;

        //Metoda pro výběr mezi opitmalizovanou a neoptimalizovanou metodou.
        private void Prvocislo_spusteni()
        {
            var Input = new Secured_Input_Class();
            Console.WriteLine("Chcete spustit optimalizovanou, nebo neoptimalizovanou verzi algorytmu?");
            Odpoved = Input.Secured_Input_Character("L");
        }

        //Optimalizovaná metoda pro hledání prvočísla.
        private void Prvocislo_Overeni_Optimalizovane()
        {
            Optimalizovane = true;
            Console.WriteLine("Zadejte cislo, o kterem si myslitem ze je prvocislem. \nProgram to overi a vypise vysledek.");
            Console.Write("Cislo: ");
            var Input = new Secured_Input_Class();
            Cislo_Zapis = Input.Secured_Input_Int();
            var Stopky = new Stopwatch();
            Stopky.Start();
            for (int Opakovani = 2; Opakovani <= 9; Opakovani++)
            {
                if (Cislo_Zapis < 0)
                {
                    zaporne = true;
                }
                Thread.Sleep(10);
                if ((Cislo_Zapis % Opakovani) == 0)
                {
                    Delitelne++;
                    Prvocilo = Cislo_Zapis;
                }
                else
                {
                    continue;
                }
            }
            Stopky.Stop();
            Cas = Stopky.ElapsedMilliseconds;
        }

        //Neoptimalizovaná metoda pro hledání prvočísla.
        private void Prvocislo_Overeni_Neoptimalizovane()
        {
            Optimalizovane = false;
            Console.WriteLine("Zadejte cislo, o kterem si myslitem ze je prvocislem. \nProgram to overi a vypise vysledek.");
            Console.Write("Cislo: ");
            var Input = new Secured_Input_Class();
            Cislo_Zapis = Input.Secured_Input_Int();
            var Stopky = new Stopwatch();
            Stopky.Start();
            for (int Opakovani = 2; Opakovani < Cislo_Zapis; Opakovani++)
            {
                if (Cislo_Zapis < 0)
                {
                    zaporne = true;
                }
                Thread.Sleep(10);
                if ((Cislo_Zapis % Opakovani) == 0)
                {
                    Delitelne++;
                    Prvocilo = Cislo_Zapis;
                }
                else
                {
                    continue;
                }
            }
            Stopky.Stop();
            Cas = Stopky.ElapsedMilliseconds;
        }

        private void Prvocislo_Vypis()
        {
            if (Delitelne == 1 || Delitelne == 0)
            {
                Console.WriteLine("Cislo {0} je prvocislo.", Cislo_Zapis);
            }
            else
            {
                Console.WriteLine("Cislo {0} neni prvocislo.", Cislo_Zapis);
            }
            Console.WriteLine("Overovani prvociselnosti trvalo {0}ms.", Cas);
            if (zaporne)
            {
                Console.WriteLine("Fun fact: Zadne zaporne cislo neni prvocislo. Nejmensi prvocislo je 2.");
                zaporne = false;
            }
            Delitelne = 0;
        }

        //Metoda pro spuštění programu  na hledání prvočísel
        public void Prvocislo_Spusteni()
        {
            while (!Zadano)
            {
                Prvocislo_spusteni();
                var Input = new Secured_Input_Class();
                if (Odpoved == "optimalizovanou")
                {
                    Prvocislo_Overeni_Optimalizovane();
                }
                else if (Odpoved == "neoptimalizovanou")
                {
                    Prvocislo_Overeni_Neoptimalizovane();
                }
                else
                {
                    Console.WriteLine("Vami zadana moznost je neplatna.");
                }
                Prvocislo_Vypis();
                Console.WriteLine("\nChcete zadat dalsi cislo?");
                Odpoved = Input.Secured_Input_Character("L");
                if (Odpoved == "ano")
                {
                    Zadano = false;
                }
                else
                {
                    Zadano = true;
                }
            }
        }
    }

    //Trida pro sestaverni pyramidy z hvezdicek
    public class Pyramida
    {
        private int Levo;
        private int Vyska;
        private int Pravo;
        private int MaxSirka;
        private int Pocitadlo;
        private int Levo_Pocitadlo;
        private int Pravo_Pocitadlo;
        private int Hvezdicky_Pocitadlo;

        //Metoda pro tisknutí mezer
        private void PrintMezer()
        {
            Console.Write(" ");
        }

        //Metoda pro tisknutí hvězdiček
        void PrintHvezdicek()
        {
            Console.Write("*");
        }

        //Metoda pro vytvoření pyramidy 
        public void Vytvoreni_Pyramidy()
        {
            var Input = new Secured_Input_Class();
            Console.WriteLine("Zadejte kolik pater bude mit pyramida");
            Vyska = Input.Secured_Input_Int();
            MaxSirka = (2 * Vyska) - 1;
            for (Pocitadlo = 0; Pocitadlo < Vyska; Pocitadlo++)
            {
                Pravo = (MaxSirka / 2) - Pocitadlo;
                Levo = (MaxSirka / 2) - Pocitadlo;
                while (Levo_Pocitadlo <= Levo)
                {
                    PrintMezer();
                    Levo_Pocitadlo++;
                }
                while (Hvezdicky_Pocitadlo - Pocitadlo <= Pocitadlo)
                {
                    PrintHvezdicek();
                    Hvezdicky_Pocitadlo++;
                }
                while (Pravo_Pocitadlo <= Levo)
                {
                    PrintMezer();
                    Pravo_Pocitadlo++;
                }
                Hvezdicky_Pocitadlo = 0;
                Levo_Pocitadlo = 0;
                Pravo_Pocitadlo = 0;
                Console.WriteLine("");
            }

        }
    }

    //Trida pro prohozeni dvou cisel
    public class Prohozeni
    {
        private int X, Y, Temp;

        //Metoda pro prohozeni dvou cisel typu int
        public void Prohod()
        {
            Console.WriteLine("Program zaznamena dve vami zadane cisla a prohodi je.");
            var Input = new Secured_Input_Class();
            Console.Write("Zadejte prvni cislo [X]: ");
            X = Input.Secured_Input_Int();
            Console.Write("Zadejte prvni cislo [Y]: ");
            Y = Input.Secured_Input_Int();
            Temp = X;
            X = Y;
            Y = Temp;
            Console.WriteLine("Nyni se X = {0} a Y = {}.", X, Y);
        }
    }

    //Trida pro nalezeni nejvetsiho a nejmensi cisla
    public class Nejvetsi_Nejmensi
    {
        private int[] Cisla = new int[5];
        private int Max = 0;
        private int Min = 0;
        private int Pocitadlo;
        private string Volba;

        //Metoda pro naplněním pole pseudo náhodnými hodnotami od 0 od 9.
        private void Zaplneni()
        {
            var Rand = new Random();
            for (int Opakovani = 0; Opakovani < 5; Opakovani++)
            {
                Cisla[Opakovani] = Rand.Next(0, 10);
            }
        }

        //Metoda pro výpis neseražazeného pole
        private void Rand_Arr_Vypis()
        {
            for (int Opakovani = 0; Opakovani < 5; Opakovani++)
            {
                Console.WriteLine("Nesrovnane pole: " + Cisla[Opakovani]);
            }
        }

        //Metoda pro nalezení největšího, nebo nejmenšího čísla
        private void Nalezeni()
        {

            for (Pocitadlo = 0; Pocitadlo < 5; Pocitadlo++)
            {
                if (Cisla[Max] < Cisla[Pocitadlo])
                    Max = Pocitadlo;

                if (Cisla[Min] > Cisla[Pocitadlo])
                    Min = Pocitadlo;
            }
        }

        //Metoda pro spuštění applikace na hledání největšího nebo nejmenšího čísla.
        public void Spusteni()
        {
            Zaplneni();
            Nalezeni();
            while (true)
            {
                var Input = new Secured_Input_Class();
                Console.Write("Chcete vypsat nejvesi nebo nejmensi cislo?  ");
                Volba = Input.Secured_Input_Character("L");
                if (Volba == "nejvetsi")
                {
                    Console.WriteLine("Neserazene pole: ");
                    Rand_Arr_Vypis();
                    Console.WriteLine("\nNejvetsi cislo je {0}", Cisla[Max]);
                    break;
                }
                else if (Volba == "nejmensi")
                {
                    Console.WriteLine("Neserazene pole: ");
                    Rand_Arr_Vypis();
                    Console.WriteLine("Nejmensi cislo je {0}", Cisla[Min]);
                    break;
                }
                else
                    Console.WriteLine("Vami zadana volba neni spravna!");
            }
        }
    }

    //Metoda pro změnu barvy výstupu pro zvýraznění chyby
    public class Error_message
    {
        //private string Colour_Choice;
        public void Err_msg(string Colour_Choice, string Zprava)
        {
            if (Colour_Choice == "R" || Colour_Choice == "r")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Zprava);
                Console.ResetColor();
            }
            else if (Colour_Choice == "G" || Colour_Choice == "g")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Zprava);
                Console.ResetColor();
            }
            else if (Colour_Choice == "B" || Colour_Choice == "b")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(Zprava);
                Console.ResetColor();
            }
            else if (Colour_Choice == "Y" || Colour_Choice == "y")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(Zprava);
                Console.ResetColor();
            }
        }
    }

    public class TabulkaMocnin
    {
        private int Vstup, Temp;
        private int Exponent;

        private int Umocni(int cislo)
        {
            int Opakovani = 0;
            Vstup = cislo;
            Temp = Vstup;
            Exponent = 2;
            do
            {
                Vstup *= Temp;
                Opakovani++;
            } while (Exponent-- > Opakovani);
            return Vstup;
        }

        public void Spust()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.WriteLine("Mocnina pro {0} je {1}", i, Umocni(i));
            }
        }
    }
}
