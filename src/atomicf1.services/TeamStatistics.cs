﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.domain;

namespace atomicf1.services
{
    public class TeamStatistics 
    {
        public TeamStatistics(Team team)
        {
            Team = team;
        }

        public Team Team { get; private set; }
        public int Wins { get; set; }
        public int Points { get; set; }
        public int Races { get; set; }
        public int Poles { get; set; }
    }
}
