﻿using System;

namespace TebakKata_Tes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30); // Set ukuran jendela konsol agar cukup besar

            Console.WriteLine("".PadLeft(45)); // Menambah spasi untuk menjaga judul berada di tengah
            Console.WriteLine("==========================================");
            Console.WriteLine("".PadLeft(45));
            Console.WriteLine("          Selamat Datang di Game Tebak Kata!");
            Console.WriteLine("".PadLeft(45));
            Console.WriteLine("==========================================\n");

            TebakKata game = new TebakKata();

            // Meminta pengguna untuk memasukkan kata kunci
            Console.Write("Masukkan Kata Kunci: ");
            string secretWord = Console.ReadLine();
            // Validasi kata kunci
            while (!IsValidSecretWord(secretWord))
            {
                Console.WriteLine("\nKata kunci hanya boleh terdiri dari huruf dan spasi.");
                Console.Write("Masukkan Kata Kunci: ");
                secretWord = Console.ReadLine();
            }
            game.SetSecretWord(secretWord);

            int wrongGuessCount = 0; // Menghitung jumlah tebakan yang salah
            while (!game.IsGameOver() && wrongGuessCount < 3) // Permainan berakhir jika berhasil menebak atau tebakan salah mencapai 3 kali
            {
                Console.Clear(); // Membersihkan layar untuk tampilan yang lebih rapi
                DisplayGameHeader();
                game.DisplayProgress();
                game.DisplayGuessedLetters();

                char guess = game.GetValidGuess();
                if (!game.Guess(guess))
                {
                    wrongGuessCount++; // Menambah jumlah tebakan yang salah jika tebakan tidak benar
                }
            }

            Console.WriteLine("\n==========================================");
            if (wrongGuessCount < 3)
            {
                Console.WriteLine("\nSelamat! Anda berhasil menebak kata: " + game.GetSecretWord());
            }
            else
            {
                Console.WriteLine("\nAnda sudah salah menebak sebanyak 3 kali. Game berakhir.");
            }
            Console.WriteLine("==========================================");
        }

        // Menampilkan header permainan
        private static void DisplayGameHeader()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("               Tebak Kata");
            Console.WriteLine("==========================================");
        }

        // Validasi kata kunci
        private static bool IsValidSecretWord(string word)
        {
            foreach (char c in word)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }
}