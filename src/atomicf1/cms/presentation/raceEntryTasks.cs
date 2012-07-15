using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.cms.presentation
{
    public class raceEntryTasks : BaseTasks
    {
        private IRaceRepository _repository;

        public raceEntryTasks()
        {
            _repository = new RaceRepository();
        }

        public override bool Delete()
        {
            var raceEntryId = ParentID;

            var temp = _repository.GetAll().SelectMany(x => x.Entries);
            var entry = temp.FirstOrDefault(x => x.Id == raceEntryId);

            if (entry != null) {
                var race = entry.Race;
                race.Withdraw(entry);

                _repository.Save(race);

                return true;
            }
            return false;
        }

        public override bool Save()
        {
            throw new NotImplementedException();
        }
    }
}