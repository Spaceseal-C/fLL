using System;
using System.Collections.Generic;
using System.IO;

namespace fLL
{

    class fLL
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            String fnev = "";
            Console.Write("Kérem  a beolvasandó file nevét:");
            fnev = Console.ReadLine(); //a file nevét kéri be amiben el van választva a szöveg.
            Console.Clear();
            int n = 0;
            n = nu(n, fnev);
            bool meow = false;
            if (ellenorzes(n, meow))
            {
                String[,] szavak = new String[n, 2];
                int e = n; //random szám
                szavak = m(szavak, fnev);
                while (true)
                {
                    e = kivalaszt(e, n); //randomizálás
                    Console.WriteLine(szavak[e, 0]);
                    String s = "";
                    while (s != szavak[e, 1])
                    {
                        s = Console.ReadLine();
                    }
                    Console.Clear();
                }
            }
        }
        static int nu(int nm, string fnev)
        {
            
            StreamReader sr = new StreamReader(fnev + ".txt");
            while (!sr.EndOfStream)
            {
                sr.ReadLine();
                nm += 1;
            }
            return nm;
        }
        static string[,] m(String[,] magyara, string fnev)
        {
            StreamReader sr = new StreamReader(fnev + ".txt");
            List<string> magyar = new List<string>();
            while (!sr.EndOfStream)
            {
                magyar.Add(sr.ReadLine());
            }
            int cal = 0; //segedvaltozo, megszamlalja, hogy hanyadik elem jon a tombben
            string[] magy = new string[2]; 
            foreach (string item in magyar)
            {
                magy = item.Split(';');
                magyara[cal, 0] = magy[0];
                magyara[cal, 1] = magy[1];
                cal++;
            }
            return magyara;
        }
        static bool ellenorzes(int n, bool meow) //ellenőrzi, hogy a fileban van-e szöveg.
        {
            meow = true;
            if (n == 0)
            {
                Console.WriteLine("A fileban nem található szöveg.");
                meow = false;
                Console.ReadLine();
            }
            return meow;
        }
        static int kivalaszt(int s, int h)
        {
            s = r.Next(0, h);
            return s;
        }
    }
}