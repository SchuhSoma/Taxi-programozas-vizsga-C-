using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Taxi
{
    class Program
    {
        static List<Taxi> TaxiList;
        static List<string> FizetesiM;
        static List<string> Ido;
        static Dictionary<string, int> Statisztika;
        static void Main(string[] args)
        {
            Feladat2Beolvasas();
            Feladat3FeljegyzesekSzama();
            Feladat4Bevetele6185nek();
            Feladat5FizetesiModok();
            Feladat6OsszesKM();
            Feladat7LeghosszabbUt();
            //eladat8Hibakereses();
            Console.ReadKey();
        }

        private static void Feladat8Hibakereses()
        {
            Console.WriteLine("\n8.Feladat: Hibak szűrése");
            var sw = new StreamWriter(@"hibak.csv",false, Encoding.UTF8);
            Ido = new List<string>();
            foreach (var t in TaxiList)
            {
                if (!Ido.Contains(t.Indulas))
                {
                    Ido.Add(t.Indulas);
                }
            }
            Ido.Sort();
            Ido.Reverse();
            foreach (var i in Ido)
            {
                //Console.WriteLine(i);
            }
            Console.WriteLine("taxi_id; indulas; idotartam; tavolsag; viteldij; borravalo; fizetes_modja");
            sw.WriteLine("taxi_id; indulas; idotartam; tavolsag; viteldij; borravalo; fizetes_modja");
            foreach (var i in Ido)
            {
                foreach (var t in TaxiList)
                {
                    if(t.UtazasiIdo>0 && t.Viteldij>0 && t.Tavolsag!=0 && i==t.Indulas)
                    {
                        Console.WriteLine("{0,-6};{1,-20};{2,-5};{3,-5};{4,-5};{5,-5};{6,-5}",t.Azonosito,t.Indulas,t.UtazasiIdo,t.Tavolsag,t.Viteldij,t.Borravalo,t.Fizetesmod);
                        sw.WriteLine("{0};{1};{2};{3};{4};{5};{6}", t.Azonosito, t.Indulas, t.UtazasiIdo, t.Tavolsag, t.Viteldij, t.Borravalo, t.Fizetesmod);
                    }
                }
            }
            sw.Close();
        }

        private static void Feladat7LeghosszabbUt()
        {
            Console.WriteLine("\n7.Feladat: Leghosszab fuvar");
            double MaxFuvarHosszaIdo = double.MinValue;
            double MaxFuvarHossza = 0;
            int MaxFuvarAzon = 0;
            double MaxFuvarDij = 0;
            foreach (var t in TaxiList)
            {
                if(t.UtazasiIdo>MaxFuvarHosszaIdo)
                {
                    MaxFuvarHosszaIdo = t.UtazasiIdo;
                    MaxFuvarHossza = t.Tavolsag;
                    MaxFuvarAzon = t.Azonosito;
                    MaxFuvarDij = t.Viteldij;
                }
           
            }
            Console.WriteLine("\n\tFuvar hossza : {0} másodperc\n\tTaxi azonosítója: {1}\n\tMegetett távolság: {2} km\n\tViteldíj: {3} $", MaxFuvarHosszaIdo, MaxFuvarAzon, MaxFuvarHossza, MaxFuvarDij);

        }

        private static void Feladat6OsszesKM()
        {
            Console.WriteLine("\n6.Feladat: Megtett kilómeterek száma");
            double OsszesKM = 0;
            double OsszesMerfold = 0;
            foreach (var t in TaxiList)
            {
                OsszesMerfold+= t.Tavolsag;
                OsszesKM = OsszesMerfold * 1.6;
            }
           Console.WriteLine("\tÖsszes megtett kilómeter: {0:0.00} km", OsszesKM);
           Console.WriteLine("\tÖsszes megtett merföld  : {0:0.00} mérföld", OsszesMerfold);
        }

        private static void Feladat5FizetesiModok()
        {
            Console.WriteLine("\n5.Feladat: Fizetési módok");
            Statisztika = new Dictionary<string, int>();
            FizetesiM = new List<string>();
            foreach (var t in TaxiList)
            {
                if(!FizetesiM.Contains(t.Fizetesmod))
                {
                    FizetesiM.Add(t.Fizetesmod);
                }
            }
            foreach (var f in FizetesiM)
            {
              //  Console.WriteLine("\t{0}",f);
            }
            foreach (var f in FizetesiM)
            {
                int db = 0;
                foreach (var t in TaxiList)
                {
                    if (f==t.Fizetesmod)
                    {
                        db++;
                       
                    }
                    
                }
                //Console.WriteLine("\t{0, -10} : {1} db", f, db);
                if (!Statisztika.ContainsKey(f))
                {
                    Statisztika.Add(f, db);
                }
            }
            foreach (var s in Statisztika)
            {
                Console.WriteLine("\t{0, -10} : {1} db", s.Key, s.Value);
            }
            
        }

        private static void Feladat4Bevetele6185nek()
        {
            Console.WriteLine("\n4.Feladat: 6185-ös jármű bevétele");
            double bevetel = 0;
            double bevetelborravaloval = 0;
            foreach (var t in TaxiList)
            {
                if(t.Azonosito==6185)
                {
                    bevetel += t.Viteldij;
                    bevetelborravaloval += t.Viteldij + t.Borravalo;
                }

            }
            Console.WriteLine("\tA 6185-ös jármű bevétele: {0} $", bevetel);
            Console.WriteLine("\tA 6185-ös jármű bevétele borravalóval: {0} $", bevetelborravaloval);

        }

        private static void Feladat3FeljegyzesekSzama()
        {
            Console.WriteLine("\n3.Feladat: Feljegyzesek száma");
            Console.WriteLine("\tfeljegyzsek száma a listában: {0} db", TaxiList.Count);
            int db = 0;
            foreach (var t in TaxiList)
            {
                db++;
            }
            Console.WriteLine("\tfeljegyzsek száma a listában: {0} db", db);
        }

        private static void Feladat2Beolvasas()
        {
            Console.WriteLine("\n2.Feladat: Adatok beolvasása");
            TaxiList = new List<Taxi>();
            var sr = new StreamReader(@"fuvar.csv", Encoding.UTF8);
            int db = 0;
            while(!sr.EndOfStream)
            {
                db++;
                TaxiList.Add(new Taxi(sr.ReadLine()));
            }
            sr.Close();
            Console.WriteLine("\tBeolvasott elemek száma:{0}",db);
            Console.WriteLine("\tSikeres beolvasás");
        }
    }
}
