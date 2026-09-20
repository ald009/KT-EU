using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KT_EU
{

    class Eu
    {

        public string Name;
        public DateTime Date;
        public Eu(string name, DateTime date) {
           Name = name;
           Date = date;

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader be = new StreamReader("EUcsatlakozas.txt");

            List<Eu> list = new List<Eu>();
            string line;
            while (( line = be.ReadLine()) != null)
            {
                string[] darab = line.Split(';');

                string name = darab[0];
                DateTime date = DateTime.Parse(darab[1]);

                list.Add(new Eu(name, date));
            }

            be.Close();

            int db2018 = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Date.Year <= 2018)
                {
                    db2018++;
                }
            }

            Console.WriteLine("3. feladat: EU tagállamainak száma: " + db2018 + " db");


            
            int db2007 = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Date.Year == 2007)
                {
                    db2007++;
                }
            }

            Console.WriteLine("4. feladat: 2007-ben " + db2007 + " ország csatlakozott.");


                
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == "Magyarország")
                {
                    Console.WriteLine("5. feladat: Magyarország csatlakozásának dátuma: "
                        + list[i].Date.ToString("yyyy.MM.dd"));
                }
            }


            
            bool voltMajus = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Date.Month == 5)
                {
                    voltMajus = true;
                }
            }

            if (voltMajus)
            {
                Console.WriteLine("6. feladat: Májusban volt csatlakozás!");
            }
            else
            {
                Console.WriteLine("6. feladat: Májusban nem volt csatlakozás!");
            }


            
            int maxIndex = 0;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i].Date > list[maxIndex].Date)
                {
                    maxIndex = i;
                }
            }

            Console.WriteLine("7. feladat: Legutoljára csatlakozott ország: "
                + list[maxIndex].Name);


            
            Console.WriteLine("8. feladat: Statisztika");

            int[,] stat = new int[100, 2];
            int db = 0;

            for (int i = 0; i < list.Count; i++)
            {
                int ev = list[i].Date.Year;
                bool van = false;

                for (int j = 0; j < db; j++)
                {
                    if (stat[j, 0] == ev)
                    {
                        stat[j, 1]++;
                        van = true;
                    }
                }

                if (van == false)
                {
                    stat[db, 0] = ev;
                    stat[db, 1] = 1;
                    db++;
                }
            }

            for (int i = 0; i < db; i++)
            {
                Console.WriteLine(stat[i, 0] + " - " + stat[i, 1] + " ország");
            }




        }
    }
}
