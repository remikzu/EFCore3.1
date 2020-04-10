using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            /*var samuraiRemik = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "%San")).ToList();
            foreach (var samurai in samuraiRemik)
            {
                Console.WriteLine(samurai.Name);
            }*/
            //InsertVariousTypes();
            //InsertMultipleSamurais();
            //AddSamurai();
            //GetSamurais("After Add:");
            //GetSamuraisUsingLINQMethods();
            //QueryFilters();
            //RetrieveAndUpdateMultipleSamurais();
            //RemoveSamurai();
            //InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
            //InsertNewSamuraiWithAQuote();
            //InsertNewSamuraiWithMultipleQuotes();
            //AddQuoteToExistingSamuraiWhileTracked();
            //AddQuoteToExistingSamuraiNotTracked(1);
            //AddQuoteToExistingSamuraiNotTracked_Easy(5);
            //EagerLoadSamuraiWithQuotes();
            //RetrieveAndUpdateMultipleSamurais();
            //ProjectSomeProperties();
            //ProjectSamuraisWithQuotes();
            //ExplicitLoadQuotes();
            //FilteringWithRelatedData();
            //ModifyingRelatedDataWhenTracked();
            //ModifyingRelatedDataWhenNotTracked();
            //JoinBattleAndSamurai();
            //EnlistSamuraiIntoABattle();
            //RemoveJoinBetweenSamuraiAndBattleSimple();
            //JoinBattleAndSamurai();
            //GetSamuraiWithBattles();
            //AddNewSamuraiWithHorse();
            //AddNewHorseToSamuraiUsingId();
            //AddNewHorseToSamuraiObject();
            //AddNewHorseToDisconnectedSamuraiObject();
            //ReplaceAHorse();
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
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Remik");
            samurai.Name += "San";
            /*var samuraiRemik = _context.Samurais.Where(s => EF.Functions.Like(s.Name, "%Remik%")).ToList();
            foreach (var samurai in samuraiRemik)
            {
                Console.WriteLine(samurai.Name);
            }*/
            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultipleSamurais()
        {
            var samurais = _context.Samurais.Skip(1).Take(3).ToList();
            samurais.ForEach(s => s.Name += "San");
            _context.SaveChanges();
        }
        private static void RemoveSamurai()
        {
            var samurai = _context.Samurais.Find(18);
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of Okehazama",
                StartDate = new DateTime(1560, 05, 01),
                EndDate = new DateTime(1560, 06, 15)
            });
            _context.SaveChanges();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        {
            var battle = _context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(1560, 06, 30);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
        private static void InsertNewSamuraiWithAQuote()
        {
            var samurai = new Samurai
            {
                Name = "Kambei Shimada",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "I've come to save you"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void InsertNewSamuraiWithMultipleQuotes()
        {
            var samurai = new Samurai
            {
                Name = "Kyuzo",
                Quotes = new List<Quote>
                {
                    new Quote { Text = "Watch out for my sharp sword!"},
                    new Quote { Text = "I told you to watch out for the sharp sword! Oh well!"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.Find(1);
            samurai.Quotes.Add(new Quote
            {
                Text = "I bet you're happy that I've saved you!"
            });
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "Now that I saved you, will you feed me dinner?"
            });
            //now creating a new SamuraiContext(), in case we don't know if we are connected or not
            using(var newContext = new SamuraiContext())
            {
                //First we need to get and update that samurai, then we'll save changes
                //newContext.Samurais.Update(samurai);
                //with a bit more performance:
                newContext.Samurais.Attach(samurai);
                newContext.SaveChanges();
            }
        }
        /// <summary>
        /// With a foreign key being tracked
        /// </summary>
        /// <param name="samuraiId"></param>
        private static void AddQuoteToExistingSamuraiNotTracked_Easy(int samuraiId)
        {
            var quote = new Quote
            {
                Text = "Now that I saved you, will you feed me dinner again?",
                SamuraiId = samuraiId
            };
            using (var newContext = new SamuraiContext())
            {
                newContext.Quotes.Add(quote);
                newContext.SaveChanges();
            }
        }
        private static void EagerLoadSamuraiWithQuotes()
        {
            var samuraiWithQuotes = _context.Samurais.Include(s => s.Quotes).ToList();
            var samuraiWithAnyQuotes = _context.Samurais
                .Select(s => new
                {
                    Samurai = s,
                    Quotes = s.Quotes.Where(q => q.Text.Contains(" "))
                })
                .ToList();
        }
        private static void ProjectSomeProperties()
        {
            var someProperties = _context.Samurais.Select(s => new { s.Id, s.Name }).ToList();
            var idsAndNames = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
        public struct IdAndName
        {
            public IdAndName(int id, string name)
            {
                Id = id;
                Name = name;
            }
            public int Id;
            public string Name;
        }
        private static void ProjectSamuraisWithQuotes()
        {
            /*var somePropertiesWithQuotes = _context.Samurais
                .Select(s => new { s.Id, s.Name, 
                    HappyQuotes = s.Quotes.Where(q => q.Text.Contains("happy")) 
                })
                .ToList();*/
            var samuraiWithHappyQuotes = _context.Samurais
                .OrderBy(s => s.Quotes.Count())
                .Select(s => new
                {
                    Samurai = s,
                    HappyQuotes = s.Quotes.Where(q => q.Text.Contains("happy"))
                })
                .ToList();
            //var firstSamurai = samuraiWithHappyQuotes[0].Samurai.Name += " The Happies";
        }

        private static void ExplicitLoadQuotes()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Contains("Remik"));
            //for collection, where's a data
            _context.Entry(samurai).Collection(s => s.Quotes).Load();
            //for reference, there's no data yet in database
            _context.Entry(samurai).Reference(s => s.Horse).Load();
        }
        private static void FilteringWithRelatedData()
        {
            var samurais = _context.Samurais
                                   .Where(s => s.Quotes.Any(q => q.Text.Contains("Happy")))
                                   .ToList();
        }
        private static void ModifyingRelatedDataWhenTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 24);
            samurai.Quotes[0].Text = " Did you hear that?";
            samurai.Quotes.Remove(samurai.Quotes[1]);
            _context.SaveChanges();
        }
        private static void ModifyingRelatedDataWhenNotTracked()
        {
            var samurai = _context.Samurais.Include(s => s.Quotes).FirstOrDefault(s => s.Id == 24);
            var quote = samurai.Quotes[0];
            quote.Text += " Did you hear that again?";
            using (var newContext = new SamuraiContext())
            {
                //newContext.Update(quote);
                newContext.Entry(quote).State = EntityState.Modified;
                newContext.SaveChanges();
            }
        }
        private static void JoinBattleAndSamurai()
        {
            //Samurai and Battle already exist and we have their IDs
            var sbJoin = new SamuraiBattle { SamuraiId = 1, BattleId = 1 };
            _context.Add(sbJoin);
            _context.SaveChanges();
        }
        private static void EnlistSamuraiIntoABattle()
        {
            var battle = _context.Battles.Find(1);
            battle.SamuraiBattles
                .Add(new SamuraiBattle { SamuraiId = 5 });
            _context.SaveChanges();
        }

        private static void RemoveJoinBetweenSamuraiAndBattleSimple()
        {
            var join = new SamuraiBattle { BattleId = 1, SamuraiId = 1 };
            _context.Remove(join);
            _context.SaveChanges();
        }
        private static void GetSamuraiWithBattles()
        {
            var samuraiWithBattle = _context.Samurais
                .Include(s => s.SamuraiBattles)
                .ThenInclude(sb => sb.Battle)
                .FirstOrDefault(samurai => samurai.Id == 2);

            var samuraiWithBattlesCleaner = _context.Samurais.Where(s => s.Id == 2)
                .Select(s => new
                {
                    Samurai = s,
                    Battles = s.SamuraiBattles.Select(sb => sb.Battle)
                })
                .FirstOrDefault();
        }
        private static void AddNewSamuraiWithHorse()
        {
            var samurai = new Samurai { Name = "Jina Ujichika" };
            samurai.Horse = new Horse { Name = "Silver" };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void AddNewHorseToSamuraiUsingId()
        {
            var horse = new Horse { Name = "Scout", SamuraiId = 2 };
            _context.Add(horse);
            _context.SaveChanges();
        }

        private static void AddNewHorseToSamuraiObject()
        {
            var samurai = _context.Samurais.Find(4);
            samurai.Horse = new Horse { Name = "Black Beauty" };
            _context.SaveChanges();
        }
        private static void AddNewHorseToDisconnectedSamuraiObject()
        {
            var samurai = _context.Samurais.AsNoTracking().FirstOrDefault(s => s.Id == 3);
            samurai.Horse = new Horse { Name = "Mr. Ed" };
            using (var newContext = new SamuraiContext())
            {
                newContext.Attach(samurai);
                newContext.SaveChanges();
            }
        }
        private static void ReplaceAHorse()
        {
            var samurai = _context.Samurais.Include(s => s.Horse).FirstOrDefault(s => s.Id == 3);
            samurai.Horse = new Horse { Name = "Trigger" };
            _context.SaveChanges();
        }
        private static void GetSamuraiWithClan()
        {
            var samurai = _context.Samurais.Include(s => s.Clan).FirstOrDefault();
        }
        private static void GetClanWithSamurais()
        {
            //var clan = _context.Clans.Include(c => c.???)
            var clan = _context.Clans.Find(3);
            var samuraisForClan = _context.Samurais.Where(s => s.Clan.Id == 3).ToList();
        }
    }
}