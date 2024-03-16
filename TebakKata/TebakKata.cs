using System;
using System.Collections.Generic;
using System.Linq;

namespace TebakKata_Tes
{
    public class TebakKata
    {
        private string secretWord;
        private List<char> guessedLetters;
        private List<char> revealedLetters;

        public TebakKata()
        {
            guessedLetters = new List<char>();
            revealedLetters = new List<char>();
        }

        public void SetSecretWord(string word)
        {
            secretWord = word.ToUpper();
            // Inisialisasi revealedLetters dengan karakter garis bawah
            foreach (char c in secretWord)
            {
                if (char.IsLetter(c))
                    revealedLetters.Add('_');
                else
                    revealedLetters.Add(c); // Simpan spasi atau karakter khusus tanpa menyembunyikannya
            }
        }

        public bool IsGameOver()
        {
            return !GetCurrentProgress().Contains('_');
        }

        public bool Guess(char letter)
        {
            letter = Char.ToUpper(letter);
            if (guessedLetters.Contains(letter))
            {
                Console.WriteLine($"Anda sudah menebak huruf '{letter}'. Coba huruf lain.");
                return false;
            }

            guessedLetters.Add(letter);

            bool correctGuess = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == letter)
                {
                    revealedLetters[i] = letter;
                    correctGuess = true;
                }
            }

            if (!correctGuess)
            {
                Console.WriteLine($"Huruf '{letter}' tidak ada dalam kata.");
            }

            return correctGuess;
        }

        public string GetCurrentProgress()
        {
            return new string(revealedLetters.ToArray());
        }

        public void DisplayProgress()
        {
            Console.WriteLine("Progress Saat Ini: " + GetCurrentProgress());
        }

        public void DisplayGuessedLetters()
        {
            Console.WriteLine("Huruf yang Sudah Ditebak: " + string.Join(", ", guessedLetters));
        }

        public string GetSecretWord()
        {
            return secretWord;
        }

        public char GetValidGuess()
        {
            char guess = ' ';
            bool validGuess = false;
            while (!validGuess)
            {
                Console.Write("Tebak sebuah huruf: ");
                string input = Console.ReadLine();
                if (input.Length == 1 && char.IsLetter(input[0]))
                {
                    guess = char.ToUpper(input[0]);
                    validGuess = true;
                }
                else
                {
                    Console.WriteLine("Masukkan hanya satu huruf.");
                }
            }
            return guess;
        }
    }
}
