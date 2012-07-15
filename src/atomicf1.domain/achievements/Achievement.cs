using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain.achievements
{
    public abstract class Achievement
    {
        protected readonly string _name;
        protected readonly string _description;
        protected readonly string _cssClass;
        protected bool _isUnlocked;

        protected IDictionary<int, int> _driverOccurences = new Dictionary<int, int>();
                
        protected Achievement(string name, string description, string cssClass)
        {
            _name = name;
            _description = description;
            _cssClass = cssClass;
            _isUnlocked = false;
        }

        public int Occurences { get; protected set; }

        public string Name { get { return _name;  } }
        public string Description { get { return _description;  } }
        public string CssClass 
        { 
            get
            {
                if (!IsUnlocked) return _cssClass + " Locked";
                return _cssClass;
            } 
        }
        public bool IsUnlocked { get { return _isUnlocked;  } }

        public void Unlock()
        {
            _isUnlocked = true;
        }

        public void Unlock(Driver driver)
        { 
            if (HasEarntAchievement(driver))
                Unlock();
        }

        protected abstract int Occurrences(Driver driver);

        public abstract bool AchievedAt(RaceEntry entry);

        public int TimesAchieved(Driver driver)
        {
            if (!_driverOccurences.ContainsKey(driver.Id))
            {
                _driverOccurences.Add(driver.Id, Occurrences(driver));
            }

            return _driverOccurences[driver.Id];
        }

        public bool HasEarntAchievement(Driver driver)
        {           
            return TimesAchieved(driver) > 0;
        }

        public bool HasEarntAchievementAt(RaceEntry raceEntry)
        {
            return AchievedAt(raceEntry);
        }

        protected IEnumerable<Race> GetAllRaces(Driver driver)
        {
            var seasons = driver.Contracts.Select(c => c.Season);
            var races = seasons.SelectMany(s => s.Races);

            return races.Where(r => r.GetRaceEntry(driver) != null);
        }       
    }      
}