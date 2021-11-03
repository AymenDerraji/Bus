using System;
using System.Linq;

namespace Bussen
{
    class Buss
    {
        public person[] passagerare;
        public int antal_passagerare;



        public void Run()
        {
            antal_passagerare = 25;
            passagerare = new person[antal_passagerare];



            Console.WriteLine("Welcome to the awesome Buss-simulator");

            int alt = -1; // try catch fungerar inte om alt är tomt, därför väljer jag -1 som är ett bra alternativ.
            do
            {
                int countPerson = 0;
                for (int i = 0; i < antal_passagerare; i++)// i denna loop kontrollerar vi antal personer (i vektorn).
                {
                    if (passagerare[i] != null)//om vektor element inte lika med null då 
                    {
                        countPerson++; // Plussar 1 varje gg den får en träff
                    }
                }
                Console.WriteLine("Mata in vilket nr på alternativet du vill utföra!\n");
                Console.WriteLine("1. Lägga till en passagerare");
                Console.WriteLine("2. Skriv ut alla åldrar på passagerare.");
                Console.WriteLine("3. Beräkna den totala åldern av alla passagerare.");
                Console.WriteLine("4. Beräkna Genomsnitt av den totala åldern av alla passagerare.");
                Console.WriteLine("5. Ta fram den passagerare med högst ålder av alla passagerare.");
                Console.WriteLine("0. Avsluta programmet");
                try 
                {
                    alt = int.Parse(Console.ReadLine()); //matar in vilket alternativ man vill utföra!
                }
                catch { Console.WriteLine("Fel inmating!"); } // Meddelande vid fel inmatning

                switch (alt)
                {
                    case 1:
                        if (countPerson == antal_passagerare) // Kontrollerar om bussen är fullsatt
                        {
                            Console.WriteLine("Fullsatt");
                        }
                        else
                        {
                            Console.WriteLine("Lägga till en passagerare.");
                            add_passenger(countPerson);
                        } //ropar in metod add_passenger
                        continue;

                    case 2:
                        Console.WriteLine("Alla åldrar på passagerare:");
                        print_buss();
                        continue;
                    case 3:
                        Console.WriteLine("Totala åldern av alla passagerare är {0} år. \n", calc_total_age());
                        continue;
                    case 4:
                        Console.WriteLine("GenomSnitt av den Totala åldern av alla passagerare är {0} år. \n", Math.Round(calc_average_age(countPerson), 2)); // genomsnittar samtligas ålder
                        continue;
                    case 5:
                        Console.WriteLine("Högst ålder är {0} år. \n", max_age());
                        continue;
                    case 0:
                        Console.WriteLine("Avsluta programmet!");
                        break;
                    default:
                        break;
                }
            } while (alt != 0);

        }



        public void add_passenger(int countPerson)
        {
            //Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
            //Om bussen är full kan inte någon passagerare stiga på

            string sex = "";
            int age = -1;

            Console.WriteLine("Antal Personer är {0} i bussen", countPerson);

            Console.WriteLine("Ålder: ");
            do
            {
                try
                {
                    age = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Fel inmating! Ange ålder igen!");
                }
            } while (age<0);
           
            Console.WriteLine("Kön: ");
            Console.WriteLine("1.Man");
            Console.WriteLine("2.Kvinna");
            int alt =-1;
            do // loopar tills man matar in rätt kön
            {
                try
                {
                    alt = int.Parse(Console.ReadLine()); 
                }
                catch { Console.WriteLine("Fel inmating!"); } 

                switch (alt)
                {
                    case 1:
                        Console.WriteLine("Man.");
                        sex = "Man";
                        break;
                    case 2:
                        Console.WriteLine("Kvinna");
                        sex = "Kvinna";
                        break;
                    default:
                        Console.WriteLine("Välj igen!");
                        break;
                }
            } while (alt != 1 && alt != 2);
            passagerare[countPerson] = new person(age, sex);// lägger in personen i rätt tom vektor
        }

        public void print_buss()
        {
            //Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
            foreach (person x in passagerare)
            {
                if (x != null) Console.WriteLine("ålder : {0}, kön: {1}", x.get_age(), x.get_sex());
            }
            Console.WriteLine("");
        }
        public int calc_total_age()
        {
            //Beräkna den totala åldern.
            int count_age = 0;
            foreach (person x in passagerare)
            {
                if (x != null) count_age += x.get_age();
            }
            return count_age;
        }

        public decimal calc_average_age(int countPerson)// metoden tar emot antal personer
        {
            //Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
            decimal average = Convert.ToDecimal(calc_total_age()) / countPerson;
            return average;
        }

        public int max_age()
        {

            //ta fram den passagerare med högst ålder. 
            int[] age = new int[25]; // Skapar ny vektor som innehåller bara int.
            for (int i = 0; i < passagerare.Length; i++) //loopar från 0 och plussas med 1 till 25. 
            {
                if (passagerare[i] != null)
                {
                    age[i] = passagerare[i].get_age(); // skickar in alla åldrar till nya vektorn "age"
                }
                else
                {
                    age[i] = 0; // Om vektorn är tom blir d 0
                };
            }
            return age.Max();
        }


    }
    class person  // skapar en klass för person
    {
        private int age;
        private string sex;
        public person(int _age, string _sex)  // detta är konstruktor för person som innehåller "age" "sex"
        {
            age = _age;
            sex = _sex;
        }

        public int get_age() // i det här returneras åldern
        {
            return age;
        }
        public string get_sex() // i det här returneras kön
        {
            return sex;
        }

    }

    class Program
    {
        public static void Main(string[] args)
        {
            //Skapar ett objekt av klassen Buss som heter minbuss
            //Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
            var minbuss = new Buss();
            minbuss.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}