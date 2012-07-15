using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation
{
    public class seasonRaceTasks : BaseTasks
    {
        private ISeasonRepository _repository;

        public seasonRaceTasks()
        {
            _repository = new SeasonRepository();
        }

        public override bool Delete()
        {
            var season = _repository.GetSeasonWithRaceId(ParentID);
            if (season != null) {
                var race = season.Races.First(r => r.Id == ParentID);
                season.RemoveRace(race);

                _repository.Save(season);
            }

            
            return false;
        }

        public override bool Save()
        {
            // Custom save

            return false;
        }
    }
}