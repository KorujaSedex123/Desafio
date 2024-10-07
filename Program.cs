using System;
using System.Threading;

namespace PasswordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string correctPassword = "Encapsulamento2024!";
            string userInput;
            int attempts = 0;
            int maxAttempts = 5;

            Console.Clear();
            PrintBorder();
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCentered("Bem-vindo ao jogo de adivinhação de senha!");
            Console.ResetColor();
            PrintBorder();
            Console.WriteLine();
            Console.WriteLine($"Você tem {maxAttempts} tentativas para adivinhar a senha correta.");

            while (attempts < maxAttempts)
            {
                Console.Write("Digite a senha: ");
                userInput = Console.ReadLine();
                attempts++;

                if (userInput == correctPassword)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Parabéns! Você adivinhou a senha correta.");
                    Console.ResetColor();
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Senha incorreta. Tente novamente.");
                    Console.ResetColor();
                    Console.WriteLine($"Tentativas restantes: {maxAttempts - attempts}");
                }
            }

            if (attempts == maxAttempts)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Você excedeu o número de tentativas. Jogo encerrado.");
                Console.ResetColor();
            }

            // Animação de saída
            Console.WriteLine();
            AnimateText("Jogo encerrado.");

            // Pausa para permitir que o usuário leia a mensagem final
            Console.WriteLine();
            Console.WriteLine("Pressione Enter para sair...");
            Console.ReadLine();
        }

        static void PrintBorder()
        {
            int width = Console.WindowWidth;
            Console.WriteLine(new string('=', width));
        }

        static void PrintCentered(string text)
        {
            int windowWidth = Console.WindowWidth;
            int textLength = text.Length;
            int spaces = (windowWidth - textLength) / 2;
            Console.WriteLine(new string(' ', spaces) + text);
        }

        static void AnimateText(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(100); // Pausa de 100 milissegundos entre cada caractere
            }
            Console.WriteLine();
        }
    }
}
