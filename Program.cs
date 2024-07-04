using System;

namespace CrocodileManager
{
    class Program
    {
        private static readonly CrocodileService service = new();
        static void Main()
        {
            service.RegisterHandler(Console.WriteLine);

            // service.CreateCrocodile("", -100, 2.5, 8, Genders.Male); // демонстрация фильтрации некорректных
                                                                     // значений, данный объект не будет создан
            service.CreateCrocodile("Cate", 70, 2.5, 8, Genders.Female);
            service.CreateCrocodile("Tom", 55, 1.9, 5, Genders.Female);
            service.CreateCrocodile("Bot", 95, 2.7, 9, Genders.None);
            service.CreateCrocodile("Bob", 80, 2.3, 7, Genders.Male);
            service.CreateCrocodile("Jack", 85, 2.1, 11, Genders.Male);

            Showmenu();
        }

        static void Showmenu()
        {
            string? userChoice;
            do
            {
                Console.WriteLine("1. Get info about all crocodiles\n2. Find longest crocodiles" +
                    "\n3. Find biggest crocodile\n4. Find oldest crocodile\n0. Exit");
                userChoice = Console.ReadLine();
                Console.Clear();

                switch (userChoice)
                {
                    case "1":
                        service.GetAllCrocodiles();
                        break;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Please, enter length: ");
                        double length;
                        bool isParsed = double.TryParse(Console.ReadLine(), out length);

                        if (isParsed)
                            service.FindLongCrocodiles(length);
                        else
                            Console.WriteLine("Uncorrect value");
                        break;
                    case "3":
                        service.FindBiggestCrocodile();
                        break;
                    case "4":
                        service.FindOldestCrocodile();
                        break;
                }
            } while (userChoice != "0");
        }
    }
}
