using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsRaces : BaseLoadResultsTreeCommand
    {
        public loadResultsRaces(BaseTree tree) : base(tree) { }

        public override void Populate(ref umbraco.cms.presentation.Trees.XmlTree tree, int keyId)
        {
            var season = _seasonRepository.GetById(keyId);

            foreach (var theRace in season.Races)
            {

                XmlTreeNode rNode = XmlTreeNode.Create(_baseTree);
                rNode.NodeID = theRace.Id.ToString();
                rNode.Text = string.Format("{0} - {1}", theRace.Circuit.Country, theRace.Circuit.Name);
                rNode.Icon = "folder.gif";
                rNode.NodeType = "raceEntry";

                rNode.Menu.Clear();
                rNode.Menu.AddRange(new List<IAction> {ActionNew.Instance, ActionRefresh.Instance});

                var treeService = GetTreeService(keyId, string.Format("RaceEntry-{0}", theRace.Id));
                rNode.Source = treeService.GetServiceUrl();

                tree.Add(rNode);
            }            
        }
    }
}