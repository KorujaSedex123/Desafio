using System;

namespace PasswordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string correctPassword = "Encapsulamento2024!";
            string[] phrases = {
                "Encapsulamento é o conceito de esconder os detalhes internos de um _____.",
                "Herança permite que uma classe herde atributos e métodos de outra _____.",
                "Polimorfismo é a capacidade de um objeto assumir várias _____.",
                "Uma classe é um modelo ou blueprint a partir do qual _____ são criados.",
                "Um objeto é uma instância de uma _____.",
                "Abstração é o processo de ocultar os detalhes de implementação e mostrar apenas a _____.",
                "Um construtor é um método especial usado para inicializar _____.",
                "A sobrecarga de métodos permite que uma classe tenha mais de um método com o mesmo nome, mas com diferentes _____.",
                "Uma interface define um contrato que uma classe deve _____.",
                "A composição é uma relação onde um objeto é composto de outros _____."
            };
            string[][] options = {
                new string[] { "a) objeto", "b) método", "c) atributo", "d) interface" },
                new string[] { "a) classe", "b) objeto", "c) método", "d) atributo" },
                new string[] { "a) formas", "b) métodos", "c) atributos", "d) interfaces" },
                new string[] { "a) objetos", "b) métodos", "c) atributos", "d) interfaces" },
                new string[] { "a) classe", "b) método", "c) atributo", "d) interface" },
                new string[] { "a) interface", "b) classe", "c) método", "d) atributo" },
                new string[] { "a) objetos", "b) métodos", "c) atributos", "d) interfaces" },
                new string[] { "a) assinaturas", "b) objetos", "c) atributos", "d) interfaces" },
                new string[] { "a) implementar", "b) herdar", "c) encapsular", "d) polimorfizar" },
                new string[] { "a) objetos", "b) métodos", "c) atributos", "d) interfaces" }
            };
            int[] correctAnswers = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int maxAttempts = 3;
            bool allCorrect = true;

            Console.Clear();
            PrintBorder();
            Console.ForegroundColor = ConsoleColor.Cyan;
            PrintCentered("Bem-vindo ao jogo de completar frases sobre POO!");
            Console.ResetColor();
            PrintBorder();
            Console.WriteLine();
            Console.WriteLine("Complete corretamente todas as frases para liberar a senha.");

            for (int i = 0; i < phrases.Length; i++)
            {
                int attempts = 0;
                bool correct = false;

                while (attempts < maxAttempts && !correct)
                {
                    Console.WriteLine($"Frase {i + 1}: {phrases[i]}");
                    for (int j = 0; j < options[i].Length; j++)
                    {
                        Console.WriteLine(options[i][j]);
                    }
                    Console.Write("Escolha a alternativa correta (a-d): ");
                    string userInput = Console.ReadLine();
                    int userChoice = Array.IndexOf(new string[] { "a", "b", "c", "d" }, userInput.ToLower());

                    if (userChoice >= 0 && userChoice <= 3)
                    {
                        attempts++;
                        if (userChoice == correctAnswers[i])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Resposta correta!");
                            Console.ResetColor();
                            correct = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Resposta incorreta. Tente novamente.");
                            Console.ResetColor();
                            Console.WriteLine($"Tentativas restantes: {maxAttempts - attempts}");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Entrada inválida. Por favor, escolha uma letra entre a e d.");
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }

                if (!correct)
                {
                    allCorrect = false;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Você não conseguiu completar todas as frases corretamente.");
                    Console.ResetColor();
                    break;
                }
            }

            if (allCorrect)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Parabéns! Você completou todas as frases corretamente. A senha é: {correctPassword}");
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
                System.Threading.Thread.Sleep(100); // Pausa de 100 milissegundos entre cada caractere
            }
            Console.WriteLine();
        }
    }
}
