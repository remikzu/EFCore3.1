using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            //InsertVariousTypes();
            //InsertMultipleSamurais();
            //AddSamurai();
            //GetSamurais("After Add:");
            GetSamuraisUsingLINQMethods();
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
            context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4, samurai5);
            context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Kikuchio" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            context.AddRange(samurai, clan);
            context.SaveChanges();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sampson" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamuraisUsingLINQMethods()
        {
            //var samuraisLINQMethod = context.Samurais.ToList();
            var samuraisLINQMethod2 = context.Samurais
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
            var samuraisLINQQuery1 = from s in context.Samurais
                                     select s;
            samuraisLINQQuery1.ToList();
            var samuraisLINQQuery2 = from s in context.Samurais
                                     where s.Name == "Remik"
                                     select s;
            samuraisLINQQuery2.ToList();
        }

        private static void GetSamuraiSimpler()
        {
            var samurais = context.Samurais.ToList();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine($"{samurai.Id}: {samurai.Name}");
            }
        }
    }
}