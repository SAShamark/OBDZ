using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    public class Program
    {
        private static readonly List<Train> Trains = new List<Train>();
        private static int _trainIdCounter = 1;
        private static int _ticketIdCounter = 1;
        private static int _passengerIdCounter = 1;

        public static void Main()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Оберіть операцію:");
                Console.WriteLine("1. Створити поїзд");
                Console.WriteLine("2. Переглянути всі поїзди");
                Console.WriteLine("3. Оновити інформацію про поїзд");
                Console.WriteLine("4. Видалити поїзд");
                Console.WriteLine("5. Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateTrain();
                        break;
                    case "2":
                        ReadTrains();
                        break;
                    case "3":
                        UpdateTrain();
                        break;
                    case "4":
                        DeleteTrain();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private static void CreateTrain()
        {
            Console.WriteLine("Створення нового поїзда:");

            Console.Write("Номер поїзда: ");
            string trainNumber = Console.ReadLine();

            Console.Write("Станція відправлення: ");
            string departureStation = Console.ReadLine();

            Console.Write("Станція прибуття: ");
            string arrivalStation = Console.ReadLine();

            var train = new Train
            {
                TrainId = _trainIdCounter++,
                TrainNumber = trainNumber,
                DepartureStation = departureStation,
                ArrivalStation = arrivalStation,
                Tickets = new List<Ticket>()
            };

            Trains.Add(train);

            Console.WriteLine("Поїзд успішно створено.");
        }

        private static void ReadTrains()
        {
            Console.WriteLine("Список усіх поїздів:");

            foreach (var train in Trains)
            {
                Console.WriteLine($"ID: {train.TrainId}, Номер: {train.TrainNumber}, Відправлення: {train.DepartureStation}, Прибуття: {train.ArrivalStation}");
            }
        }

        private static void UpdateTrain()
        {
            Console.Write("Введіть ID поїзда, який потрібно оновити: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невірний формат ID.");
                return;
            }

            var train = Trains.FirstOrDefault(t => t.TrainId == id);
            if (train == null)
            {
                Console.WriteLine("Поїзд з таким ID не знайдено.");
                return;
            }

            Console.WriteLine($"Поточна інформація про поїзд ID {id}:");
            Console.WriteLine($"Номер: {train.TrainNumber}, Відправлення: {train.DepartureStation}, Прибуття: {train.ArrivalStation}");

            Console.WriteLine("Введіть нову інформацію:");

            Console.Write("Новий номер поїзда: ");
            train.TrainNumber = Console.ReadLine();

            Console.Write("Нова станція відправлення: ");
            train.DepartureStation = Console.ReadLine();

            Console.Write("Нова станція прибуття: ");
            train.ArrivalStation = Console.ReadLine();

            Console.WriteLine("Інформація про поїзд оновлена успішно.");
        }

        private static void DeleteTrain()
        {
            Console.Write("Введіть ID поїзда, який потрібно видалити: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Невірний формат ID.");
                return;
            }

            var train = Trains.FirstOrDefault(t => t.TrainId == id);
            if (train == null)
            {
                Console.WriteLine("Поїзд з таким ID не знайдено.");
                return;
            }

            Trains.Remove(train);

            Console.WriteLine($"Поїзд з ID {id} видалено успішно.");
        }
    }
}