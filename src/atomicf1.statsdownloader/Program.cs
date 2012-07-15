using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.statsdownloader
{
    public class Program
    {
        static CachedSeasonRepository seasonRepository = new CachedSeasonRepository();
        static CachedCircuitRepository circuitRepository = new CachedCircuitRepository();
        static CachedDriverContractRepository contractRepository = new CachedDriverContractRepository();
        private static CachedDriverRepository driverRepository = new CachedDriverRepository();
        private static CachedTeamRepository teamRepository = new CachedTeamRepository();
        private static IRaceRepository raceRepository = new RaceRepository();

        static void Main(string[] args)
        {
            try
            {
                var startYear = 1950;
                if (args.Length >= 1)
                    startYear = int.Parse(args[0]);
                int endYear = startYear;

                DateTime? raceDate = null;

                if (args.Length >= 2)
                {
                    if (!int.TryParse(args[1], NumberStyles.Integer, null, out endYear))
                    {
                        endYear = startYear;
                        DateTime internalRaceDate;
                        if (DateTime.TryParse(args[1], out internalRaceDate))
                        {
                            raceDate = internalRaceDate;
                        }                        
                    }
                }
                    
                for (var yearNumber = startYear; yearNumber <= endYear; yearNumber++)
                {
                    Console.Write("Starting download of {0}...", yearNumber);
                    var season = new Season(yearNumber);
                    season.GetData();
                    Console.WriteLine("   Data downloaded");

                    // Create Season
                    var f1Season = seasonRepository.FindOrCreate(season, yearNumber);

                    foreach (var race in season.Races.Where(r => !raceDate.HasValue || r.Date == raceDate.Value))
                    {
                        Console.Write("\tDownloading {0}...", race.Name);
                        race.GetData();
                        Console.WriteLine("   Data downloaded");

                        // Create Circuit if needed
                        var circuit = circuitRepository.FindOrCreate(race.Name);
                        var f1Race = race.MapDomainRace(circuit);

                        // Add race to season
                        f1Season.AddRace(f1Race);
                        if (race.Date < DateTime.Today && race.Date.Year == yearNumber)
                        {
                            foreach (var entry in race.Entries)
                            {
                                // Find driver contract.  Only be created first time its came across
                                // needs to allow for drivers not competing full season.
                                var contract = contractRepository.FindOrCreate(entry, yearNumber);
                                if (contract == null)
                                {
                                    Console.WriteLine("\t\tCreating Contract for {0} and {1} for {2}", entry.Driver,
                                                      entry.Team, yearNumber);
                                    var driver = driverRepository.FindOrCreate(entry.Driver);
                                    contract = new domain.DriverContract
                                                   {
                                                       Driver = driver,
                                                       Team = teamRepository.FindOrCreate(entry.Team),
                                                       SignedDate = new DateTime(f1Race.StartDate.Year, 1, 1),
                                                       Season = f1Season
                                                   };
                                    driver.SignContract(contract);
                                    contractRepository.SaveAndCache(contract);

                                    driverRepository.Save(driver);
                                }

                                // Enter driver/team pairing int this race and store results                            
                                var f1Entry = f1Race.Enter(contract);
                                entry.MapDomainRaceEntry(f1Entry);
                            }

                            // Save race
                            Console.WriteLine("\t\tSaving {0}", race.Name);
                            raceRepository.Save(f1Race);
                        }
                    }
                }
            } catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.WriteLine("Done!");
            Console.ReadLine();
        }
      
        static domain.Team FindOrCreateTeam(RaceEntry entry)
        {
            var team = teamRepository.GetAll().FirstOrDefault(x => x.Name == entry.Team);
            if (team == null)
            {
                team = new domain.Team {Name = entry.Team};
                teamRepository.Save(team);
            }
            return team;
        }

    }
}
