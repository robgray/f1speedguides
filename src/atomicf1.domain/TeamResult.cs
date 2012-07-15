using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public class TeamResult
    {
        public virtual Team Team { get; set; }

        public virtual decimal Points { get; set; }

        public virtual int Position { get; set; }

        public virtual bool IsPositionNotAvailable { get { return Position == 0; } }

        public virtual string GetPositionString()
        {
            return GetPositionString(false);
        }

        public virtual string GetPositionString(bool numericOnly)
        {            
            if (IsPositionNotAvailable) return " - ";
            if (!numericOnly)
            {
                switch (Position % 10)
                {
                    case 1:
                        {
                            return Position == 11 ? "11th" : string.Format("{0}st", Position);
                        }
                    case 2:
                        {
                            return Position == 12 ? "12th" : string.Format("{0}nd", Position);
                        }
                    case 3:
                        {
                            return Position == 13 ? "13th" : string.Format("{0}rd", Position);
                        }
                    default:
                        {
                            return string.Format("{0}th", Position);
                        }
                }
            }
            else
                return string.Format("{0}", Position);
        }
    }

    public class NullTeamResult : TeamResult
    {
        public NullTeamResult(ICompetitor competitor, Season season)            
        {
            Team = new Team() { Name = competitor.Name };
            Points = 0;
            Position = 0;
        }
    }
}