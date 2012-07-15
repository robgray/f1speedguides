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
    public class seasonTemplateTasks : BaseTasks
    {
        private ISeasonRepository _repository;

        public seasonTemplateTasks()
        {
            _repository = new SeasonRepository();
        }

        public override bool Delete()
        {
            var season = _repository.GetById(ParentID);
            _repository.Delete(season);

            return true;
        }

        public override bool Save()
        {
            var season = new Season {Name = Alias};
            _repository.Save(season);

            _returnUrl = BasePageDirectory + "editSeason.aspx?id=" + season.Id;

            return true;
        }
    }
}