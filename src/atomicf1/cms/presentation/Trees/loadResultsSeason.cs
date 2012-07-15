using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsSeason : BaseLoadResultsTreeCommand, ILoadResultsTreeCommand
    {
        public loadResultsSeason(BaseTree tree) : base(tree) { }
        
        #region ILoadResultsTreeCommand Members

        public override void Populate(ref XmlTree tree, int keyId)
        {
            Season season = _seasonRepository.GetById(keyId);

            if (season != null)
            {

                XmlTreeNode entries = XmlTreeNode.Create(_baseTree);
                entries.NodeID = season.Id.ToString();
                entries.Icon = "folder.gif";
                entries.Text = "Entrants";
                entries.NodeType = "seasonEntry";

                var treeService = GetTreeService(keyId, string.Format("Entries-{0}", season.Id));
                entries.Source = season.Entrants.Count() > 0 ? treeService.GetServiceUrl() : "";

                entries.Menu.Clear();
                entries.Menu.AddRange(new List<IAction> { ActionNew.Instance, ContextMenuSeperator.Instance, ActionRefresh.Instance });

                tree.Add(entries);

                XmlTreeNode races = XmlTreeNode.Create(_baseTree);
                races.NodeID = season.Id.ToString();
                races.Icon = "folder.gif";
                races.Text = "Races";
                races.NodeType = "seasonRaceFolder";

                treeService = GetTreeService(keyId, string.Format("Races-{0}", season.Id));
                races.Source = season.Races.Count() > 0 ? treeService.GetServiceUrl() : "";

                races.Menu.Clear();
                races.Menu.AddRange(new List<IAction> { ActionRefresh.Instance });

                tree.Add(races);

            }
        }

        #endregion
    }
}