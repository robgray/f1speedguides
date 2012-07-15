using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic.Actions;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResultsRaceEntries : BaseLoadResultsTreeCommand
    {
        private readonly IRaceRepository _raceRepository;

        public loadResultsRaceEntries(BaseTree tree) : base(tree)
        {
            _raceRepository = new RaceRepository();
        }

        public override void Populate(ref XmlTree tree, int keyId)
        {
            var race = _raceRepository.GetById(keyId);

            if (race != null) {

                var sorted = race.Entries.OrderBy(x => x.Entrant.Driver.Name);

                foreach (var entry in sorted)
                {
                    var node = XmlTreeNode.Create(_baseTree);
                    node.NodeID = entry.Id.ToString();
                    node.Text = entry.Entrant.Driver.Name;
                    node.Icon = "medal_gold_3.png";
                    node.NodeType = "raceEntry";
                    node.Action = "javascript:openRaceEntry(" + entry.Id + "," + keyId + ")";

                    node.Menu.Clear();
                    node.Menu.Add(ActionDelete.Instance);

                    tree.Add(node);
                }
            }
        }
    }
}