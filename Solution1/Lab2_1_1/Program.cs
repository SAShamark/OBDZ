using System;
using System.Collections.Generic;

namespace Lab2_1_1
{
    internal abstract class TrainTicketSystem
    {
        private static readonly List<Train> Trains = new List<Train>();

        private static void Main()
        {
            InitializeTrains();

            while (true)
            {
                Console.WriteLine("Вітаємо на сайті з продажу залізничних квитків!");
                Console.WriteLine("1. Переглянути наявні поїзди");
                Console.WriteLine("2. Бронювати квиток");
                Console.WriteLine("3. Вийти");

                Console.Write("Оберіть опцію: ");
                int choice = int.Parse(Console.ReadLine() ?? string.Empty);

                switch (choice)
                {
                    case 1:
                        ShowAvailableTrains();
                        break;
                    case 2:
                        BookTicket();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                        break;
                }
            }
        }

        static void InitializeTrains()
        {
            Trains.Add(new Train { Id = 1, Destination = "Київ", DepartureTime = new DateTime(2024, 6, 21, 8, 0, 0), AvailableSeats = 10 });
            Trains.Add(new Train { Id = 2, Destination = "Львів", DepartureTime = new DateTime(2024, 6, 21, 9, 30, 0), AvailableSeats = 5 });
            Trains.Add(new Train { Id = 3, Destination = "Одеса", DepartureTime = new DateTime(2024, 6, 21, 11, 0, 0), AvailableSeats = 8 });
        }

        static void ShowAvailableTrains()
        {
            Console.WriteLine("Наявні поїзди:");
            foreach (var train in Trains)
            {
                Console.WriteLine($"Поїзд №{train.Id} до {train.Destination}, відправлення: {train.DepartureTime}, вільні місця: {train.AvailableSeats}");
            }
        }

        static void BookTicket()
        {
            Console.Write("Введіть номер поїзда для бронювання: ");
            int trainId = int.Parse(Console.ReadLine() ?? string.Empty);

            var train = Trains.Find(t => t.Id == trainId);
            if (train != null)
            {
                if (train.AvailableSeats > 0)
                {
                    train.AvailableSeats--;
                    Console.WriteLine("Квиток заброньовано успішно!");
                }
                else
                {
                    Console.WriteLine("Немає доступних місць.");
                }
            }
            else
            {
                Console.WriteLine("Невірний номер поїзда.");
            }
        }
    }
}