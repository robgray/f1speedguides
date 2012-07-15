using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsQualifyingResults : BaseLoadResultsTreeCommand
    {
        public loadResultsQualifyingResults(BaseTree tree) : base(tree) { }

        public override void Populate(ref XmlTree tree, int keyId)
        {
            var reader =
                            Application.SqlHelper.ExecuteReader(
                                @"
                            SELECT Res.RaceResultId, D.Name 
                            FROM Result Res INNER JOIN DriverContract DC ON Res.DriverContractId = DC.DriverContractId
                            INNER JOIN Driver D ON DC.DriverId = D.DriverId
                            WHERE Res.ResultType=1 AND Res.RaceId = @raceId
                            ORDER BY [Time]",
                                Application.SqlHelper.CreateParameter("@raceId", keyId));

            while (reader.Read())
            {

                var qNode = XmlTreeNode.Create(_baseTree);
                qNode.NodeID = reader.GetInt("RaceResultId").ToString();
                qNode.Text = reader.GetString("Name");
                qNode.Icon = "medal_silver_3.png";
                qNode.NodeType = "qualiResults";
                qNode.Action = "javascript:openQualificationResult(" + reader.GetInt("RaceResultId") + ")";
                qNode.Menu.Clear();
                qNode.Menu.Add(ActionDelete.Instance);

                tree.Add(qNode);

            }
        }
    }
}