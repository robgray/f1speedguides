using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.domain
{
    public abstract class Result
    {
        protected Result(RaceEntry entry)
        {
            Entry = entry;
        }

        public abstract decimal Points { get; }

        public virtual RaceEntry Entry { get; private set; }

        public virtual DriverContract Entrant { get; set; }
        
        public virtual Race Race { get; set; }

        public virtual int Position { get; set; }

        public virtual decimal Time { get; set; }

        public virtual bool Completed { get; set; }

        public virtual bool Disqualified { get; set; }

        protected abstract bool  IsPositionNotAvailable { get;  }

        public virtual string GetPositionString()
        {
            return GetPositionString(false);
        }

        public virtual string GetPositionString(bool numericOnly)
        {
            if (Disqualified) return numericOnly ? "DSQ" : "<span class=\"DSQ\">DSQ</span>";
            if (IsPositionNotAvailable) return " - ";
            if (!Completed) return numericOnly ? "DNF" : "<span class=\"DNF\">DNF</span>";
            

            if (!numericOnly)
            {
                return PositionString(Position);
            }
            else
                return string.Format("{0}", Position);
        }

        public virtual string GetQualifyingPositionString(bool numericOnly)
        {
            if (Disqualified) return numericOnly ? "DSQ" : "<span class=\"DSQ\">DSQ</span>";
            if (!Entry.DidNotQualify) return " - ";

            if (!numericOnly)
            {
                return PositionString(Entry.QualifyingPosition);
            }
            else
                return string.Format("{0}", Entry.QualifyingPosition);
        }

        private string PositionString(int position)
        {
            switch (position % 10)
            {
                case 1:
                    {
                        return Position == 11 ? "11th" : string.Format("{0}st", position);
                    }
                case 2:
                    {
                        return Position == 12 ? "12th" : string.Format("{0}nd", position);
                    }
                case 3:
                    {
                        return Position == 13 ? "13th" : string.Format("{0}rd", position);
                    }
                default:
                    {
                        return string.Format("{0}th", position);
                    }
            }
        }
    }
}
