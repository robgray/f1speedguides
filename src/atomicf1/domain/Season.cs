using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Season : DomainObject<int>
    {
        private IList<Race> _races;

        public Season()
        {
            _races = new List<Race>();
        }

        public virtual int Year { get; set; }

        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual IEnumerable<Race> Races
        {
            get
            {
                throw new NotImplementedException();
            }            
        }    
    
        public virtual void AddRace(Race race)
        {
            race.Season = this;
            _races.Add(race);
        }

        public virtual void RemoveRace(Race race)
        {
            if (_races.Contains(race)) {
                _races.Remove(race);
                race.Season = null;
            }
        }
    }
}
