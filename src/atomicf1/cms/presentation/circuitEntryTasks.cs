using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic;

namespace atomicf1.cms.presentation
{
    public class circuitEntryTasks : BaseTasks
    {
        private readonly ICircuitRepository _repository;

        public circuitEntryTasks()
        {
            _repository = new CircuitRepository();
        }

        public override bool Delete()
        {
            var circuit = _repository.GetById(ParentID);
            _repository.Delete(circuit);

            return true;
        }

        public override bool Save()
        {
            _returnUrl = BasePageDirectory + "editCircuit.aspx?id=" + ParentID;

            return true;
        }        
    }
}