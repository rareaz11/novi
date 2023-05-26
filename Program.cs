using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/* moj prvi projekt
 konzolna aplikacija koja sluzi za dodavanje sportasa u listu i upis preko StreamWritera u file
pretrazivanje ,sortiranje*/

namespace novi
{
    internal class Program
    {



        struct Utrke
        {
            public string ImeNatjecanja;
            public string rezultat;
            public DateTime datum;
            public int Nagrada;


        }
        struct Sportas
        {
            public int oib;
            public string ime;
            public string prezime;
            public Utrke evidenciije;
            


        }




        static void Main(string[] args)
        {
            List<Sportas> Spor = new List<Sportas>();

            string putanja = @"sport.txt";


            Sportas s = new Sportas();
        q:
            Console.WriteLine("Dobrodosli u Ak Split: ");
            Console.WriteLine("ZA NASTAVAK  U IZBRONIK PRISTINITE ENTER: ");
            Console.ReadLine();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("1.Unos sportasa ");
            Console.WriteLine("2.Ispis ongo sto je upisano");
            Console.WriteLine("3.upis u file ");
            Console.WriteLine("4.Prikazi natjecanja");
            Console.WriteLine("5.sortiraj po Imenu");
            Console.WriteLine("6.sortiraj po prezimenu");
            Console.WriteLine("7sortiraj po novcanim nagraadama");
            Console.WriteLine("8. ukupna zarada pojedninog sportasa");
            Console.WriteLine("9. Ukupna Zarada Sportasa");
            Console.WriteLine("10.Sortiranje po datumu");
            Console.WriteLine("11 . izadi");



            int izbrnik;
            Console.WriteLine("odabreite jednu od ponudenih opcija");
            izbrnik = Convert.ToInt32(Console.ReadLine());

            switch (izbrnik)
            {
                case 1:

                    Console.WriteLine("UNOS NOVOG SPORTASA: ");




                    Console.WriteLine("-------------");



                    Console.WriteLine("Unesite  oib sportasa: ");
                    int oib = Convert.ToInt32(Console.ReadLine());
                    if (oib == s.oib)
                    {
                        Console.WriteLine("ne mogu postojati 2 ista oiba ");
                        Console.WriteLine("pokusajte opet");
                        goto q;
                    }
                    else
                    {
                        Console.WriteLine("oib prihvacen!!");
                        Console.ReadLine();
                    }
                    Console.WriteLine("unesite  ime sportasa: ");
                    string ime = Console.ReadLine();
                    Console.WriteLine("unesite prezime sportasa: ");
                    string prezime = Console.ReadLine();
                    Console.WriteLine("unesite   Ime natjecanja: ");
                    string evidenciije = Console.ReadLine();
                    Console.WriteLine("unesite rezultat ostvaren na natjecanju: ");
                    string evidenciijer = Console.ReadLine();
                    Console.WriteLine("uneiste  tocan datum dogadaja: ");
                    DateTime evidenciijed = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("unesite iznos nagrade: ");
                    int evidenciijen = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("podatci su sporemljeni ");

                    s.oib = oib;
                    s.ime = ime;
                    s.prezime = prezime;
                    s.evidenciije.ImeNatjecanja = evidenciije;
                    s.evidenciije.rezultat = evidenciijer;
                    s.evidenciije.datum = evidenciijed;
                    s.evidenciije.Nagrada = evidenciijen;
                    Console.WriteLine("podatci su spremljeni");


                    Spor.Add(s);
                    goto q;
                    break;
                case 2:

                    Console.WriteLine("oib: " + s.oib);
                    Console.WriteLine("ime " + s.ime);
                    Console.WriteLine("prez " + s.prezime);
                    Console.WriteLine("mjesto: " + s.evidenciije.ImeNatjecanja);
                    Console.WriteLine("rezult: " + s.evidenciije.rezultat);
                    Console.WriteLine("datume: " + s.evidenciije.datum);
                    Console.WriteLine("nagrada: " + s.evidenciije.Nagrada);
                    Console.ReadLine();
                    goto q;
                    break;

                case 3:
                    StreamWriter sw = new StreamWriter(putanja);
                    foreach (Sportas k in Spor)
                    {
                        Console.WriteLine("vrijednost" + s.oib + s.ime + s.prezime + s.evidenciije.ImeNatjecanja + s.evidenciije.rezultat + s.evidenciije.datum + s.evidenciije.Nagrada);
                        sw.WriteLine("oib sportasa: " + s.oib);
                        sw.WriteLine(" ime sportasa: " + s.ime);
                        sw.WriteLine("prezime sportasa: " + s.prezime);
                        sw.WriteLine(" nastup: " + s.evidenciije.ImeNatjecanja);
                        sw.WriteLine("rezultat:  " + s.evidenciije.rezultat);
                        sw.WriteLine("datum: " + s.evidenciije.datum);
                        sw.WriteLine("NOVCANA NAAGRADA: " + s.evidenciije.Nagrada);
                       
                      
                    }
                    sw.Flush(); 
                    sw.Close();
                    

                    goto q;

                    break;

                case 4:
                    //po prezimenu od slova a
                    Spor = (List<Sportas>)Spor.OrderBy(x => s.prezime).ToList();

                    foreach (Sportas k in Spor)
                    {
                        Console.WriteLine("ispis podataka: " + s.oib + " " + s.ime + " " + s.prezime);
                    }

                    goto q;
                    break;
                case 5:
                    
                    //po prezimenu od slova z
                    Spor = (List<Sportas>)Spor.OrderByDescending(x => s.prezime).ToList();

                    foreach (Sportas k in Spor)
                    {
                        Console.WriteLine("ispis podataka: " + s.oib + " " + s.ime + " " + s.prezime);
                    }


                    goto q;
                    break;

                case 6:

                    //dva uvijeta ime po prvim slovima , prezime od iza
                    Spor = (List<Sportas>)Spor.OrderBy(x => s.prezime).ThenByDescending(x =>s.ime).ToList();

                    foreach (Sportas k in Spor)
                    {
                        Console.WriteLine("ispis podataka: " + s.oib + " " + s.ime + " " + s.prezime) ;
                    }

                    break;


                case 7:
                    //gdje je zarada veca od 3000 kn ispisi imena
                    
                        Spor  = (List<Sportas>)Spor.Where(x => s.evidenciije.Nagrada > 3000).ToList();

                        foreach (Sportas k in Spor)
                        {
                            Console.WriteLine("ispis podataka gdje je placa veca od 3000: oib: " + s.oib + "  ime : " + s.ime + " prezime " + s.prezime + " novac:  " + s.evidenciije.Nagrada);

                            Console.WriteLine(" ");
                            Console.ReadLine();
                        }
                        

                    

                    goto q;
                    break;


                    case 8:
                    //brisanje

                    s.oib = 0;

                    s.ime = " ";
                    s.prezime = " ";
                    s.evidenciije.ImeNatjecanja = " ";
                    s.evidenciije.Nagrada = 0 ;
                    s.evidenciije.rezultat = " ";
                    s.evidenciije.datum = DateTime.Now;
                    Console.WriteLine("brisanje podataka ");
                    Console.ReadLine() ;

                    goto q;

                    break;



                case 9:
                   //sveukupna zarada
                        Spor = (List<Sportas>)Spor.Where(x => s.evidenciije.Nagrada >0).ToList();


                     
                    

                    int ukupno = Spor.Sum(x =>s.evidenciije.Nagrada);
                    Console.WriteLine("ukupna zarada sportasa: " + ukupno);
                    goto q;

                    break;

                case 10:
                    //sortiranje po datumu
                    Spor = (List<Sportas>)Spor.Where(x => s.evidenciije.datum.Month == 3).ToList();

                    foreach (Sportas k in Spor)
                    {
                        Console.WriteLine("ispis podataka gdje je placa veca od 3000: oib: " + s.oib + "  ime : " + s.ime + " prezime " + s.prezime + " DATUM:  " + s.evidenciije.datum);

                        Console.WriteLine(" ");
                        Console.ReadLine();
                    }
                    goto q;
                        break;

                case 11:
                    //kraj
                    Console.WriteLine("___________________");

                    Console.WriteLine("KRAJ");

                    Console.WriteLine(" ______________________");
                    Console.ReadLine() ;


                    break;



                    

            }

        }

      /* 
        void PretraziPoImenu(List<Sportas>Spor, Sportas s)
        {
            Spor = (List<Sportas>)Spor.Where(x => s.evidenciije.Nagrada >3000).ToList();

            foreach (Sportas k in Spor)
            {
                Console.WriteLine("ispis podataka pozaradi: " + s.oib + " " + s.ime + " " + s.prezime);

                Console.WriteLine(" ");
                Console.ReadLine();
      
       POKUSAJJJJ NECEG */
            }

        }

    




            
    

