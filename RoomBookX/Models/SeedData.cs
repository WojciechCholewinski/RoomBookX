using Microsoft.EntityFrameworkCore;
using RoomBookX.Data;

namespace RoomBookX.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RoomBookXContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RoomBookXContext>>()))
            {
                if (context == null || context.Reservation == null)
                {
                    throw new ArgumentNullException("Null RoomBookXContext");
                }

                // Look for any Reservations.
                if (context.Reservation.Any())
                {
                    return;   // DB has been seeded
                }

                context.Reservation.AddRange(
                    new Reservation
                    {
                        CustomerName = "Wojciech",
                        CustomerSurname = "Kowalski",
                        RoomNumber = "225D",
                        Capacity = 25,
                        Price = 99.99M,
                        StartTime = DateTime.Parse("2022-5-10"),
                        EndTime = DateTime.Parse("2022-6-13")
                    },

                    new Reservation
                    {
                        CustomerName = "Maria",
                        CustomerSurname = "Luna",
                        RoomNumber = "16",
                        Capacity = 42,
                        Price = 150.00M,
                        StartTime = DateTime.Parse("2023-2-12"),
                        EndTime = DateTime.Parse("2023-2-12")
                    },

                    new Reservation
                    {
                        CustomerName = "Tomasz",
                        CustomerSurname = "Kwadratowski",
                        RoomNumber = "2",
                        Capacity = 12,
                        Price = 40.99M,
                        StartTime = DateTime.Parse("2023-4-09"),
                        EndTime = DateTime.Parse("2023-4-17")
                    },

                    new Reservation
                    {
                        CustomerName = "Joanna",
                        CustomerSurname = "Mazur",
                        RoomNumber = "112",
                        Capacity = 150,
                        Price =160M,
                        StartTime = DateTime.Parse("2023-1-20"),
                        EndTime = DateTime.Parse("2023-1-22")
                    },

                    new Reservation
                    {
                        CustomerName = "Krystian",
                        CustomerSurname = "Furman",
                        RoomNumber = "64g",
                        Price = 129.99M,
                        StartTime = DateTime.Parse("2023-7-02"),
                        EndTime = DateTime.Parse("2023-7-13")
                    },

                    new Reservation
                    {
                        CustomerName = "Tomasz",
                        CustomerSurname = "Kowalski",
                        RoomNumber = "655",
                        Capacity = 80,
                        Price = 299.00M,
                        StartTime = DateTime.Parse("2023-9-01"),
                    },

                    new Reservation
                    {
                        CustomerName = "Zofia",
                        CustomerSurname = "Kwit",
                        RoomNumber = "78",
                        Capacity = 190,
                        Price = 99.00M,
                        StartTime = DateTime.Parse("2022-3-30"),
                        EndTime = DateTime.Parse("2022-5-08")
                    },

                    new Reservation
                    {
                        CustomerName = "Anna",
                        CustomerSurname = "Wesołowska",
                        RoomNumber = "98G",
                        Capacity = 100,
                        Price = 359.98M,
                        StartTime = DateTime.Parse("2023-9-06")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
