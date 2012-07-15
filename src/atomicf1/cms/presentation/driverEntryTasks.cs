using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.cms.presentation
{
    public class driverEntryTasks : BaseTasks
    {
        private readonly IDriverRepository _repository;

        public driverEntryTasks()
        {
            _repository = new DriverRepository();
        }

        public override bool Delete()
        {
            var driver = _repository.GetById(ParentID);
            _repository.Delete(driver);
            
            return true;
        }

        public override bool Save()
        {
            var driver = new Driver { Name = Alias };
            _repository.Save(driver);

            _returnUrl = BasePageDirectory + "editDriver.aspx?id=" + driver.Id;

            return true;
        }
    }
}