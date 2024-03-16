using System;

namespace TebakKata_Tes
{
    class HowToPlayPage
    {
        public static void DisplayHowToPlay()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("           Cara Bermain");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Masukkan kata kunci untuk menebak kata yang dimaksud.");
            Console.WriteLine("2. Tebak huruf demi huruf hingga berhasil menebak kata secara lengkap.");
            Console.WriteLine("3. Jika Anda salah menebak sebanyak 3 kali, permainan akan berakhir.");
            Console.WriteLine("===================================");
            Console.WriteLine("Tekan tombol apapun untuk kembali ke menu utama...");
            Console.ReadKey();
        }
    }
}
