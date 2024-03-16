using System;

namespace TebakKata_Tes
{
    class AboutPage
    {
        public static void DisplayAbout()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("            Tentang Game");
            Console.WriteLine("===================================");
            Console.WriteLine("Game Tebak Kata adalah sebuah permainan sederhana");
            Console.WriteLine("yang menguji kemampuan pemain dalam menebak kata tertentu.");
            Console.WriteLine("===================================");
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
    }
}
