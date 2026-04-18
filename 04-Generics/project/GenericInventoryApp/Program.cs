using System;
using GenericInventoryApp.Models;
using GenericInventoryApp.Services;
using GenericInventoryApp.Helpers;

namespace GenericInventoryApp
{
    class Program
    {
        static void Main()
        {
            var bookRepo = new Repository<Book>();
            var medicineRepo = new Repository<Medicine>();

            bookRepo.Add(new Book { Id = 1, Title = "C# Basics" });
            bookRepo.Add(new Book { Id = 2, Title = "OOP Guide" });

            medicineRepo.Add(new Medicine { Id = 1, Name = "Paracetamol" });

            Console.WriteLine("Books:");
            Utility.PrintAll(bookRepo.GetAll());

            Console.WriteLine("\nMedicines:");
            Utility.PrintAll(medicineRepo.GetAll());
        }
    }
}