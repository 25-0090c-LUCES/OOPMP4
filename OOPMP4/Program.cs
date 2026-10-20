namespace OOPMP4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(@"
█▀▀ █▀█ █▀▄▀█ █▀▀   █▀▀ █▀█ █▀▄ █▀▀
█▄█ █▀█ █ ▀ █ ██▄   █▄▄ █▄█ █▄▀ ██▄
");
                Console.ResetColor();
                Console.WriteLine("1. Start");
                Console.WriteLine("2. Instructions");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("Enter number of choice: ");

                string input = Console.ReadLine();

                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("Please enter a number.");
                    Thread.Sleep(1200);
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        StartGame();
                        break;


                    case 2:
                        Infos();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Thank you for playing. Goodbye!");
                        Console.ReadKey();
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(1200);
                        break;
                }
            }
        }
        static void Infos()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("========================================");
            Console.WriteLine("         GAME INSTRUCTIONS ");
            Console.WriteLine("========================================");

            Console.ResetColor();

            Console.WriteLine(@"
HOW TO PLAY
----------------------------------------
1. Guess the secret 3-digit number (digits from 1 to 6).
2. No digits are repeated in the secret number.
3. You have 6 attempts to guess the correct sequence of the numbers.
4. Correct Number shows how many digits you guessed correctly in the secret number.
5. Correct Position shows how many digits you guessed correctly  in the right position.
6. Guess all the 3 numbers in a correct position you win.


Press any key to return to the menu.
");
            Console.ReadKey();
        }
        static string RandomNums;
        static void StartGame()
        {
            Console.Clear();

            Random RNG = new Random();
            Random RNG2 = new Random();
            Random RNG3 = new Random();
            int Rn1;
            int Rn2;
            int Rn3;
            Rn1 = RNG.Next(1, 7);
            while (true)
            {
                Rn2 = RNG2.Next(1, 7);
                if (Rn1 == Rn2)
                {
                    Rn2 = RNG2.Next(1, 7);
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                Rn3 = RNG3.Next(1, 7);

                if (Rn1 == Rn3 || Rn2 == Rn3)
                {
                    Rn3 = RNG3.Next(1, 7);
                }
                else
                {
                    break;
                }
            }
            RandomNums = $"{Rn1}{Rn2}{Rn3}";

            
            int attempts = 0;
            int maxattempts = 6;
        

            while (attempts < maxattempts)
            {

                int correctnum = 0;
                int correctpos = 0;
                Console.Write("\nEnter Guess: ");
                string guess = Console.ReadLine();
                for (int i = 0; i < guess.Length; i++)
                {
                    char a = guess[i];
                    for (int j = 0; j < RandomNums.Length; j++)
                    {
                        char b = RandomNums[j];
                        if (a == b)
                        {
                            correctnum++;

                        }
                    }
                }
                Console.WriteLine("Correct Number: " + correctnum);
                for (int i = 0; i < guess.Length; i++)
                {
                    if (guess[i] == RandomNums[i])
                    {
                        correctpos++;
                    }
                }
                Console.WriteLine("Correct Position: " + correctpos);
                attempts++;
                
                if (attempts > maxattempts)
                {
                    Console.WriteLine("\nLimit of Attempts Reached. The correct number was: " + RandomNums);
                    Console.WriteLine("Thank you for playing. Try Again");
                    Console.ReadKey();
                }
                if(correctpos == 3)
                {
                    Console.WriteLine("Woah Amazing! You Guessed the correct number: " + RandomNums);
                    Console.WriteLine("Press any key to play again.");
                    Console.ReadKey();
                    break;
                    
                }

            }
            
           
        }

    }

}

