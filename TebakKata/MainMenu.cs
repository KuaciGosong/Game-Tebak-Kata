using System;

namespace TebakKata_Tes
{
    class MainMenu
    {
        public static string DisplayMainMenu()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("          Selamat Datang");
            Console.WriteLine("        di Game Tebak Kata");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Mulai Game");
            Console.WriteLine("2. Cara Bermain");
            Console.WriteLine("3. Tentang Game");
            Console.WriteLine("4. Keluar");
            Console.WriteLine("===================================");

            bool firstTime = true;
            string input;
            do
            {
                if (!firstTime)
                {
                    Console.Clear();
                    Console.Write("\nPilihan Tidak Valid!");
                }
                Console.Write("\nMasukkan Pilihan (1/2/3/4): ");
                input = Console.ReadLine();
                firstTime = false;
            }
            while (input != "1" && input != "2" && input != "3" && input != "4");
            return input;
        }  
    }
}