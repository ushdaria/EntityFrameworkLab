using System;
using System.Linq;
using EntityFrameworkLab.DataContext;
using EntityFrameworkLab.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using DataContext.AppContext db = new();
            
            Animal dog = new Animal()
            {
                Name = "Borya",
                Weight = 20,
                Species = "dog"
            };

            Animal bigRat = new Animal()
            {
                Name = "Rufus",
                Weight = 0.5,
                Species = "rat"
            };

            Person person = new Person()
            {
                Name = "Dasha",
                Pets = new System.Collections.Generic.List<Animal> { bigRat, dog }
            };

            string s = "";
            while (true)
            {
   
                Console.WriteLine("1 - добавить нового человека\n2 - изменить имя человека\n3 - удалить животное\n4 - вывести БД");
                s = Console.ReadLine();
                switch (s)
                {
                    case "1":
                        db.People.Add(person);
                        db.SaveChanges();
                        break;
                    case "2":
                        var newPeople = db.People.FirstOrDefault();
                        if (newPeople is null)
                        {
                            Console.WriteLine("Изменять пока некого(");
                            continue;
                        }
                        newPeople.Name = "Masha";
                        db.People.Update(newPeople);
                        db.SaveChanges();
                        break;
                    case "3":
                        var unusedPet = db.Animals.FirstOrDefault();
                        if (unusedPet is null)
                        {
                            Console.WriteLine("Удалять больше некого(");
                            continue;
                        }
                        db.Animals.Remove(unusedPet);
                        db.SaveChanges();
                        break;
                    case "4":
                        var people = db.People.Include(p => p.Pets).ToList();
                        foreach (var p in people)
                        {
                            Console.WriteLine($"Id: {p.Id}");
                            Console.WriteLine($"Name: {p.Name}");
                            Console.WriteLine("Animals: ");
                            foreach (var pet in p.Pets)
                            {
                                Console.Write($"{pet.Name} ");
                            }
                            Console.WriteLine("\n");
                        }
                        break;
                    default:
                        return;
                }
                
            }
            
        }
    }
}
