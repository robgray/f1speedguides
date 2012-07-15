using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using System.Web.Security;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;

namespace atomicf1.cms.membership
{
    public class DriverProfile : ProfileBase
    {
        static IDriverRepository driverRepo = new DriverRepository();
        private Driver _driver;
        
        public DriverProfile()
        {
            
        }

        public static DriverProfile GetByDriverId(int driverId)
        {
            foreach(MembershipUser user in Membership.GetAllUsers())
            {
                var profile = GetDriverProfile(user.UserName);
                if (profile.Driver != null && profile.Driver.Id == driverId)
                    return profile;
            }
            return null;
        }

        public static DriverProfile GetDriverProfile(string username)
        {
            return Create(username) as DriverProfile;
        }

        public static DriverProfile GetDriverProfile()
        {            
            return Create(Membership.GetUser().UserName) as DriverProfile;            
        }

        [SettingsAllowAnonymous(false)]
        public Driver Driver
        {
            get
            {
                var driverId = (int) base["DriverId"];
                if (_driver == null && driverId > 0)
                {
                    _driver = driverRepo.GetById(driverId);
                }
                                    
                return _driver;
            }
            set
            {
                base["DriverId"] = value.Id;
                _driver = value;
            }
        }

        [SettingsAllowAnonymous(false)]
        public int AtomicId
        {
            get { return _driver.AtomicUserId; }            
        }   
    }
}