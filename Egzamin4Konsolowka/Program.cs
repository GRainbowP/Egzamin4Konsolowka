namespace Egzamin4Konsolowka
{
    //**************************
    //klasa: Uczen
    //opis: Klasa reprezentuje Ucznia   
    //pola: imie - imie ucznia
    //      oceny - oceny ucznia
    //autor: Paweł
    //**************************
    class Uczen
    {
        private string imie = "";
        public string Imie { get { return imie; } set { imie = value; } }
        private List<int> oceny = new List<int>();
        public List<int> Oceny { get { return oceny; } set { oceny = value; } }

        public int obliczSume()
        {
            int suma = 0;
            for(int i = 0; i < oceny.Count; i++)
            {
                suma += oceny[i];
            }
            return suma;
        }

        public void wypiszListe()
        {
            foreach (int i in oceny)
            {
                if (i == oceny[oceny.Count - 1])
                    Console.Write(i);
                else
                    Console.Write(i + ", ");
            }
        }

        public void sortujListe()
        {
            for(int i = 0; i < oceny.Count - 1; i++)
            {
                for(int j = 0; j < oceny.Count - 1 - i; j++)
                {
                    if (oceny[j] >  oceny[j + 1])
                    {
                        int temp = oceny[j];
                        oceny[j] = oceny[j + 1];
                        oceny[j + 1] = temp;
                    }
                }
            }
        }
    }

    internal class Program
    {
        //**************************
        //nazwa funkcji: NWD
        //opis funkcji: bierze największy wspólny dzielnik z dwóch wartości
        //parametry: suma1 - pierwsza liczba
        //           suma2 - druga liczba
        //zwracany typ i opis: int - największy wspólny dzielni dwóch liczb
        //autor: Paweł
        //**************************
        static int NWD(int suma1, int suma2)
        {
            while(suma1 != suma2)
            {
                if (suma1 > suma2)
                    suma1 = suma1 - suma2;
                else if(suma2 > suma1)
                    suma2 = suma2 - suma1;
            }
            return suma1;
        }

        //**************************
        //nazwa funkcji: mainLoop
        //opis funkcji: główna funkcja odpowiadająca za logikę programu, którą możną ponownie wywołać, kiedy użytkownik chce porównać dwóch nowych uczniów
        //parametry: brak
        //zwracany typ i opis: brak
        //autor: Paweł
        //**************************
        static void mainLoop()
        {
            Uczen u1 = new Uczen();
            Uczen u2 = new Uczen();

            Console.WriteLine("=== RYWALIZACJA UCZNIÓW ===");
            Console.WriteLine(string.Empty);

            Console.Write("Podaj imię ucznia nr 1: ");
            u1.Imie = Console.ReadLine();
            Console.WriteLine("Wpisuj oceny ucznia (1-6). Wpisz 0, aby zakończyć dodawanie.");
            int ocena = 0;
            while (true)
            {
                Console.Write("Ocena: ");
                ocena = Convert.ToInt32(Console.ReadLine());
                if (ocena == 0)
                    break;
                u1.Oceny.Add(ocena);
            }
            u1.sortujListe();

            Console.WriteLine(string.Empty);

            Console.Write("Podaj imię ucznia nr 2: ");
            u2.Imie = Console.ReadLine();
            Console.WriteLine("Wpisuj oceny ucznia (1-6). Wpisz 0, aby zakończyć dodawanie.");
            while (true)
            {
                Console.Write("Ocena: ");
                ocena = Convert.ToInt32(Console.ReadLine());
                if (ocena == 0)
                    break;
                u2.Oceny.Add(ocena);
                
            }
            u2.sortujListe();

            Console.WriteLine(string.Empty);
            Console.WriteLine("=== WYNIKI ===");
            Console.Write($"{u1.Imie}: oceny [");
            u1.wypiszListe();
            int sumaU1 = u1.obliczSume();
            Console.Write($"] | suma = {sumaU1}\n");

            Console.Write($"{u2.Imie}: oceny [");
            u2.wypiszListe();
            int sumaU2 = u2.obliczSume();
            Console.Write($"] | suma = {sumaU2}\n");

            int nwd = NWD(sumaU1, sumaU2);
            if (sumaU1 > sumaU2)
                Console.Write(u1.Imie);
            else if(sumaU2 > sumaU1)
                Console.Write(u2.Imie);

            Console.Write($" WYGRYWA! (przewaga wyrażona NWD: {nwd})");

        }
        static void Main(string[] args)
        {
            mainLoop();

            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Co chcesz zrobić dalej?");
            Console.WriteLine("1 - spróbuj ponownie z nowymi uczniami");
            Console.WriteLine("2 - zakończ program");
            Console.Write("Wybór: ");
            int wybor = Convert.ToInt32(Console.ReadLine());

            if (wybor == 1)
            {
                Console.Clear();
                mainLoop();
            }
            else if (wybor == 2)
                Console.WriteLine("Do widzenia");
        }
    }
}
