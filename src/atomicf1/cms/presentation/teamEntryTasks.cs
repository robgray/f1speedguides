using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic;

namespace atomicf1.cms.presentation
{
    public class teamEntryTasks : BaseTasks
    {
        private readonly ITeamRepository _repository;

        public teamEntryTasks()
        {
            _repository = new TeamRepository();
        }

        public override bool Delete()
        {
            var team = _repository.GetById(ParentID);
            _repository.Delete(team);

            return true;
        }

        public override bool Save()
        {
            var team = new Team {Name = Alias};
            _repository.Save(team);
            
            _returnUrl = BasePageDirectory + "editTeam.aspx?id=" + team.Id;

            return true;
        }
    }
}