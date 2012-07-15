using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class Calendar
    {
        private IList<CalendarEvent> _events;
        private string _name;

        public Calendar(string name)
        {
            _name = name + " Calendar";
            _events = new List<CalendarEvent>();
        }

        public string Name { get { return _name; } }

        public IEnumerable<CalendarEvent> Events { get { return _events;  }  }

        public void AddEvent(DateTime date, string description, int raceDistance)
        {
            _events.Add(new CalendarEvent(date, description, raceDistance));
        }

        public void Clear()
        {
            _events = new List<CalendarEvent>();
        }
    }

    public class CalendarEvent
    {
        public CalendarEvent(DateTime date, string description, int raceDistance)
        {
            Date = date;
            Description = description;
            RaceDistance = raceDistance;
        }

        public DateTime Date { get; private set; }

        public string Description { get; private set; }

        public int RaceDistance { get; private set; }
    
    }
}
