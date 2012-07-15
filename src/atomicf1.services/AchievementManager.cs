using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using atomicf1.common;
using atomicf1.domain;
using atomicf1.domain.achievements;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using System.Runtime.Caching;

namespace atomicf1.services
{
    public class AchievementManager : IAchievementManager
    {
        private IDriverRepository _driverRepository;

        public AchievementManager() : this(new DriverRepository()) { }        

        public AchievementManager(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        
        public IList<Achievement> GetAchievements(Driver driver)
        {
            if (driver == null) return new List<Achievement>();

            var key = string.Format("DriverAchievements-{0}", driver.Id);

            if (!CacheHelper.Contains(key))
            {
                var achievements = GetAllAchievements();

                foreach (var achievement in achievements)
                    achievement.Unlock(driver);

                CacheHelper.Insert(achievements, key);
            }

            return CacheHelper.Get<IList<Achievement>>(key);
        }

        public IList<Achievement> GetAllAchievements()
        {           
            var achievementTypes = Assembly.Load(new AssemblyName("atomicf1.domain")).GetTypes().Where(t => t.IsSubclassOf(typeof(Achievement)));
            var achievements = new List<Achievement>();

            foreach (var achievementType in achievementTypes)
            {
                var achievement = (Achievement)Activator.CreateInstance(achievementType);
                achievements.Add(achievement);                
            }
                        
            return achievements;
        }

        public IList<Driver> GetDriversWithAchievement(Achievement achievement)
        {
            var key = string.Format("Achievement-{0}", achievement.Name);

            if (!CacheHelper.Contains(key))
            {
                IList<Driver> drivers = _driverRepository.GetAll().Where(achievement.HasEarntAchievement).ToList();
                CacheHelper.Insert(drivers, key);
            }

            return CacheHelper.Get<IList<Driver>>(key);
        }

        public IDictionary<Achievement, IList<Driver>> GetAchievementDetails()
        {
            var achievements = GetAllAchievements();

            IDictionary<Achievement, IList<Driver>> details = new Dictionary<Achievement, IList<Driver>>();
            foreach (var achievement in achievements)
            {
                details.Add(achievement, GetDriversWithAchievement(achievement));
            }

            return details;
        }

        public IList<Achievement> GetAchievementsForRaceEntry(RaceEntry raceEntry)
        {
            var key = string.Format("AchievementRaceEntry-{0}", raceEntry == null ? 0 : raceEntry.Id);

            if (!CacheHelper.Contains(key))
            {
                var achievements = GetAllAchievements();
                IList<Achievement> awardedAchievements = new List<Achievement>();

                foreach (var achievement in achievements)
                {
                    if (achievement.HasEarntAchievementAt(raceEntry))
                        awardedAchievements.Add(achievement);
                }

                CacheHelper.Insert(awardedAchievements, key);
            }

            return CacheHelper.Get<IList<Achievement>>(key);
        }
    }
    
    public class AchievementEqualityComparer :IEqualityComparer<Achievement>
    {

        #region IEqualityComparer<Achievement> Members

        public bool Equals(Achievement x, Achievement y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Achievement obj)
        {
            return obj.GetHashCode();
        }

        #endregion
    }
}
