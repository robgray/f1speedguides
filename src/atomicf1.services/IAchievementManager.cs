using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;
using atomicf1.domain.achievements;

namespace atomicf1.services
{
    public interface IAchievementManager
    {
        IList<Achievement> GetAchievements(Driver driver);

        IList<Achievement> GetAllAchievements();

        IList<Driver> GetDriversWithAchievement(Achievement achievement);

        IList<Achievement> GetAchievementsForRaceEntry(RaceEntry raceEntry);        
    }
}
