using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main()
        {
            var trains = new List<Train>
            {
                new Train
                {
                    TrainId = 1,
                    TrainNumber = "ABC123",
                    DepartureStation = "Київ",
                    ArrivalStation = "Львів",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            TicketId = 101,
                            Class = "Преміум",
                            Price = 500,
                            Passengers = new List<Passenger>
                            {
                                new Passenger { PassengerId = 1, Name = "Іван Петров", Age = 35 },
                                new Passenger { PassengerId = 2, Name = "Марія Сидоренко", Age = 28 }
                            }
                        },
                        new Ticket
                        {
                            TicketId = 102,
                            Class = "Економ",
                            Price = 200,
                            Passengers = new List<Passenger>
                            {
                                new Passenger { PassengerId = 3, Name = "Петро Коваль", Age = 45 }
                            }
                        }
                    }
                },
                new Train
                {
                    TrainId = 2,
                    TrainNumber = "DEF456",
                    DepartureStation = "Одеса",
                    ArrivalStation = "Харків",
                    Tickets = new List<Ticket>
                    {
                        new Ticket
                        {
                            TicketId = 201,
                            Class = "Бізнес",
                            Price = 800,
                            Passengers = new List<Passenger>
                            {
                                new Passenger { PassengerId = 4, Name = "Олена Михайлова", Age = 30 }
                            }
                        }
                    }
                }
            };

            foreach (var train in trains)
            {
                Console.WriteLine($"Поїзд №{train.TrainNumber} з {train.DepartureStation} до {train.ArrivalStation}");
                foreach (var ticket in train.Tickets)
                {
                    Console.WriteLine($"Квиток ID: {ticket.TicketId}, Клас: {ticket.Class}, Ціна: {ticket.Price:C}");
                    foreach (var passenger in ticket.Passengers)
                    {
                        Console.WriteLine($"- Пасажир: {passenger.Name}, Вік: {passenger.Age}");
                    }
                }
                Console.WriteLine();
            }
        }
    
    }
}