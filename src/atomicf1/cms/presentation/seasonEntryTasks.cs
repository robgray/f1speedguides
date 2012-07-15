using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic;

namespace atomicf1.cms.presentation
{
    public class seasonEntryTasks : BaseTasks
    {
        public override bool Delete()
        {
            // delete Item here.
            Application.SqlHelper.ExecuteNonQuery("DELETE FROM drivercontract WHERE drivercontractid = @id",
                Application.SqlHelper.CreateParameter("@id", ParentID));
            
            //Application.SqlHelper.ExecuteNonQuery("update drivercontract set dateterminated=getdate() where drivercontractid = @id",Application.SqlHelper.CreateParameter("@id", ParentID));

            return true;
        }

        public override bool Save()
        {
            // Custom Task
            return false;
        }
    }
}