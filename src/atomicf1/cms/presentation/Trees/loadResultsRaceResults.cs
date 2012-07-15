using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsRaceResults : BaseLoadResultsTreeCommand
    {
        public loadResultsRaceResults(BaseTree tree) : base(tree) { }

        public override void Populate(ref XmlTree tree, int keyId)
        {
            var reader =
                            Application.SqlHelper.ExecuteReader(
                                @"
                            SELECT Res.RaceResultId, D.Name 
                            FROM Result Res INNER JOIN DriverContract DC ON Res.DriverContractId = DC.DriverContractId
                            INNER JOIN Driver D ON DC.DriverId = D.DriverId
                            WHERE Res.ResultType=2 AND Res.RaceId = @raceId
                            ORDER BY [Time]",
                                Application.SqlHelper.CreateParameter("@raceId", keyId));

            while (reader.Read())
            {

                var rNode = XmlTreeNode.Create(_baseTree);
                rNode.NodeID = reader.GetInt("RaceResultId").ToString();
                rNode.Text = reader.GetString("Name");
                rNode.Icon = "medal_gold_3.png";
                rNode.NodeType = "raceResults";
                rNode.Action = "javascript:openRaceResult(" + reader.GetInt("RaceResultId") + ")";
                rNode.Menu.Clear();
                rNode.Menu.Add(ActionDelete.Instance);

                tree.Add(rNode);

            }

        }
    }
}