using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsEntries : BaseLoadResultsTreeCommand
    {
        public loadResultsEntries(BaseTree tree) : base(tree) { }
       
        public override void Populate(ref XmlTree tree, int keyId)
        {
            var season = _seasonRepository.GetById(keyId);

            foreach (var entrant in season.Entrants)
            {
                XmlTreeNode entry = XmlTreeNode.Create(_baseTree);
                entry.NodeID = entrant.Id.ToString();
                entry.Text = string.Format("{0} - {1}", entrant.Driver.Name, entrant.Team.Name);
                entry.Icon = "vcard.png";
                entry.NodeType = "seasonEntry";
                entry.Action = string.Format("javascript:openSeasonEntry({0})", entrant.Id);

                entry.Menu.Clear();
                
                if (!entrant.HasRacedThisSeason) entry.Menu.Add(ActionDelete.Instance);

                tree.Add(entry);
            }           
        }
    }
}