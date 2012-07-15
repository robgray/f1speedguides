using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsRaceGroup : BaseLoadResultsTreeCommand
    {
        public loadResultsRaceGroup(BaseTree tree) : base(tree) { }

        public override void Populate(ref umbraco.cms.presentation.Trees.XmlTree tree, int keyId)
        {
            var season = _seasonRepository.GetById(keyId);
            var race = season.Races.First(r => r.Id == keyId);

            var quali = XmlTreeNode.Create(_baseTree);
            quali.NodeID = race.Id.ToString();
            quali.Text = "Qualifying Results";
            quali.Icon = "folder.gif";
            quali.NodeType = "qualiResults";

            quali.Menu.Clear();
            quali.Menu.AddRange(new List<IAction> { ActionNew.Instance, ActionDelete.Instance, ContextMenuSeperator.Instance, ActionRefresh.Instance });

            var treeService = GetTreeService(keyId, string.Format("Qualifying-{0}", race.Id));
            quali.Source = race.GetQualificationResults().Count() > 0 ? treeService.GetServiceUrl() : "";

            tree.Add(quali);

            var raceResults = XmlTreeNode.Create(_baseTree);
            raceResults.NodeID = "r" + race.Id.ToString();
            raceResults.Text = "Race Results";
            raceResults.Icon = "folder.gif";
            raceResults.NodeType = "raceResults";

            raceResults.Menu.Clear();
            raceResults.Menu.AddRange(new List<IAction> { ActionNew.Instance, ActionDelete.Instance, ContextMenuSeperator.Instance, ActionRefresh.Instance });

            treeService = GetTreeService(keyId, string.Format("RaceResult-{0}", race.Id));
            raceResults.Source = race.GetRaceResults().Count() > 0 ? treeService.GetServiceUrl() : "";

            tree.Add(raceResults);
        }
    }
}