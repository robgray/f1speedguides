using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using atomicf1.services;
using atomicf1.domain.achievements;

namespace atomicf1.controls
{
    public partial class AchievementsDetailed : System.Web.UI.UserControl
    {
        private IAchievementManager _manager;

        protected void Page_Load(object sender, EventArgs e)
        {
            _manager = new AchievementManager();

            AchievementsRepeater.DataSource = _manager.GetAllAchievements();
            AchievementsRepeater.DataBind();
        }

        protected void AchievementsRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = e.Item;
            if ((item.ItemType == ListItemType.Item) ||
                (item.ItemType == ListItemType.AlternatingItem))
            {
                var DriverRepeater = (Repeater) item.FindControl("DriversRepeater");
                var achievement = (Achievement)item.DataItem;

                DriverRepeater.DataSource = _manager.GetDriversWithAchievement(achievement);
                DriverRepeater.DataBind();
            }
        }     
    }    
}