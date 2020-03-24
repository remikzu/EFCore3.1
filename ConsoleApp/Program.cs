using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //InsertVariousTypes();
            //InsertMultipleSamurais();
            //AddSamurai();
            //GetSamurais("After Add:");
            //GetSamuraisUsingLINQMethods();
            //QueryFilters();
            RetrieveAndUpdateSamurai();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai { Name = "Remik" };
            var samurai2 = new Samurai { Name = "Radek" };
            var samurai3 = new Samurai { Name = "Tomek" };
            var samurai4 = new Samurai { Name = "Grzegorz" };
            var samurai5 = new Samurai { Name = "Kasia" };
            //context.Samurais.Add(samurai);
            //context.Samurais.Add(samurai2);
            _context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4, samurai5);
            _context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Kikuchio" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            _context.AddRange(samurai, clan);
            _context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sampson" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }

        private static void GetSamuraisUsingLINQMethods()
        {
            //var samuraisLINQMethod = context.Samurais.ToList();
            var samuraisLINQMethod2 = _context.Samurais
                                             .Where(s => s.Name == "Remik")
                                             .ToList();
            foreach (var samurai in samuraisLINQMethod2)
            {
                Console.WriteLine($"{samurai.Id}: {samurai.Name}");
            }
            //Console.WriteLine(samuraisLINQMethod2);
        }

        private static void GetSamuraisUsingLINQQuerySyntax()
        {
            var samuraisLINQQuery1 = from s in _context.Samurais
                                     select s;
            samuraisLINQQuery1.ToList();
            var samuraisLINQQuery2 = from s in _context.Samurais
                                     where s.Name == "Remik"
                                     select s;
            samuraisLINQQuery2.ToList();
        }

        private static void GetSamuraiSimpler()
        {
            var samurais = _context.Samurais.ToList();
        }

        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine($"{samurai.Id}: {samurai.Name}");
            }
        }

        private static void QueryFilters()
        {
            var name = "Sampson";
            //var samurais = _context.Samurais.FirstOrDefault(s => s.Name == name);
            var samurai = _context.Samurais.Find(2);
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "Re%"));
            var samurais = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
        }

        private static void RetrieveAndUpdateSamurai()
        {
            //var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Remik");
            //samurai.Name += "San";
            var samuraiRemik = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "%Remik%")).ToList();
            foreach (var samurai in samuraiRemik)
            {
                Console.WriteLine(samurai.Name);
            }
            //_context.SaveChanges();
        }
    }
}