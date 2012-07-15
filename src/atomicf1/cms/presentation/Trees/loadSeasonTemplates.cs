using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.cms.presentation.Trees;
using umbraco.BusinessLogic;
using umbraco.DataLayer;
using umbraco.interfaces;
using umbraco.BusinessLogic.Actions;
using Action = System.Action;

namespace atomicf1.cms.presentation.Trees
{
    public class loadSeasonTemplates : BaseTree
    {
        private ISeasonRepository _repository;

        public loadSeasonTemplates(string application) : base(application)
        {
            _repository = new SeasonRepository();
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.Icon = FolderIcon;
            rootNode.OpenIcon = FolderIconOpen;
            rootNode.NodeType = TreeAlias;
            rootNode.NodeID = "init";
        }

        public override void Render(ref XmlTree tree)
        {
            if (this.NodeKey == string.Empty)
            {

                var seasons = _repository.GetAll().OrderBy(s => s.Year);                
                foreach (var season in seasons) {
                    var node = XmlTreeNode.Create(this);
                    node.NodeID = season.Id.ToString();
                    node.Text = season.Name;
                    node.Icon = "calendar.png";
                    node.Action = "javascript:openSeasonTemplates(" + season.Id + ")";
                    node.NodeType = "season";

                    TreeService treeService = new TreeService(-1, TreeAlias, ShowContextMenu, IsDialog, DialogMode, app, string.Format("Season-{0}", season.Id));
                    node.Source = season.Races.Count() > 0 ? treeService.GetServiceUrl() : "";

                    node.Menu.Clear();
                    node.Menu.AddRange(new List<IAction> { ActionNew.Instance, ActionDelete.Instance, ContextMenuSeperator.Instance, ActionRefresh.Instance });

                    tree.Add(node);
                }


            } else {

                string keyType = this.NodeKey.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0];
                int keyId = int.Parse(this.NodeKey.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]);

                switch (keyType) {
                    case "Season":

                        var season = _repository.GetById(keyId);

                        if (season != null) {

                            foreach (var race in season.Races)
                            {
                                var node = XmlTreeNode.Create(this);
                                node.NodeID = race.Id.ToString();
                                node.Text = race.Circuit.Name;
                                node.Icon = "map_go.png";
                                node.NodeType = "seasonRace";
                                node.Action = "javascript:openSeasonRace(" + race.Id + "," + season.Id + ")";

                                node.Menu.Clear();
                                if (race.GetQualificationResults().Count() == 0 && race.GetRaceResults().Count() == 0)                                
                                    node.Menu.Add(ActionDelete.Instance);

                                tree.Add(node);
                            }
                        }

                        break;
                }
            }
        }

        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
                @"
                    function openSeasonTemplates(id) 
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editSeason.aspx?id=' + id;
                    }

                    function openSeasonRace(id, seasonid)
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editSeasonRace.aspx?id=' + id + '&seasonid=' + seasonid;
                    }
                ");
        }
    }
}