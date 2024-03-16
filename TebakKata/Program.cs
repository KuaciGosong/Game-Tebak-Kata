using System;

namespace TebakKata_Tes
{
    class Program
    {
        static int skor = 0;
        static void Main(string[] args)
        {
            bool skipToGame = false;
            while (true)
            {
                if (skipToGame)
                {
                    DisplayWelcomeMessage(ref skipToGame);
                }
                Console.Clear(); // Membersihkan konsol sebelum memulai permainan baru
                string input = MainMenu.DisplayMainMenu();
                Console.WriteLine(input);
                
                Console.Clear();

                if (input == "1")
                {
                    DisplayWelcomeMessage(ref skipToGame);
                } else if (input == "2")
                {

                    HowToPlayPage.DisplayHowToPlay();
                } else if (input == "3")
                {
                    AboutPage.DisplayAbout();
                } else if (input == "4")
                {
                    return;
                }        
            }
        }

        static void DisplayWelcomeMessage(ref bool skipToGame)
        {
            Console.Clear();
            string title = "Selamat Datang di Game Tebak Kata!";
            string line = new string('=', title.Length + 8);

            Console.WriteLine(line);
            Console.WriteLine("".PadLeft((line.Length - title.Length) / 2) + title);
            Console.WriteLine(line);


            PlayGame();

            // Menanyakan apakah pemain ingin melanjutkan bermain
            Console.Write("\nApakah Anda ingin bermain lagi? (ya/tidak): ");
            string answer = Console.ReadLine().ToLower();
           
            skipToGame = answer == "ya";
        }

        static void PlayGame()
        {
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
                skor++;
                Console.WriteLine($"Skor : {skor}");
            }
            else
            {
                Console.WriteLine("\nAnda sudah salah menebak sebanyak 3 kali. Game berakhir.");
                Console.WriteLine($"Skor : {skor}");
                skor = 0;
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
