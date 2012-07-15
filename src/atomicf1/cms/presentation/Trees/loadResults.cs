using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.BusinessLogic;
using umbraco.BusinessLogic.Actions;
using umbraco.DataLayer;
using umbraco.cms.presentation.Trees;
using umbraco.interfaces;
using Action = System.Action;

namespace atomicf1.cms.presentation.Trees
{
    public class loadResults : BaseTree
    {
        private ISeasonRepository _seasonRepository;
        
        public loadResults(string application) : base(application)
        {
            _seasonRepository = new SeasonRepository();
        }

        protected override void CreateRootNode(ref XmlTreeNode rootNode)
        {
            rootNode.Icon = FolderIcon;
            rootNode.OpenIcon = FolderIconOpen;
            rootNode.NodeType = TreeAlias;
            rootNode.NodeID = "-1";

            rootNode.Menu.Clear();
            rootNode.Menu.Add(ActionRefresh.Instance);
        }

        public override void Render(ref XmlTree tree)
        {
            if (this.NodeKey == string.Empty) {
                
                PopulateSeasons(ref tree);

            }
            else
            {
                string keyType = this.NodeKey.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[0];
                int keyId = int.Parse(this.NodeKey.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries)[1]);
                
                var factory = new LoadResultsTreeCommandFactory(this);
                var command = factory.GetLoader(keyType);
                command.Populate(ref tree, keyId);
            }
            
        }

        protected void PopulateSeasons(ref XmlTree tree)
        {
            var seasons = _seasonRepository.GetAll().OrderBy(s => s.Year);

            foreach (var season in seasons)
            {

                var node = XmlTreeNode.Create(this);
                node.NodeID = season.Id.ToString();
                node.Text = season.Name;
                node.Icon = "folder.gif";
                node.OpenIcon = "folder_o.gif";                    

                var treeService = new TreeService(-1, TreeAlias, ShowContextMenu, IsDialog, DialogMode, app, string.Format("Season-{0}", season.Id));
                node.Source = treeService.GetServiceUrl();

                node.Menu.Clear();
                node.Menu.Add(ActionRefresh.Instance);
                
                tree.Add(node);

            }
        }
              
        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
               @"
                    function openSeasonEntry(id) 
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editSeasonEntry.aspx?id=' + id;
                    }
                    function openRaceEntry(id, raceid)
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editRaceEntry.aspx?id=' + id + '&raceid=' + raceid;
                    }                    
                ");
        }
    }
}