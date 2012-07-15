using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.cms.presentation.Trees;
using umbraco.DataLayer;
using umbraco.BusinessLogic;

namespace atomicf1.cms.presentation.Trees
{
    public class loadTeams : BaseTree
    {
        private readonly ITeamRepository _repository;

        public loadTeams(string application) : base(application)
        {
            _repository = new TeamRepository();
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
            var teams = _repository.GetAll();

            foreach (var team in teams) {
                XmlTreeNode xNode = XmlTreeNode.Create(this);
                xNode.NodeID = team.Id.ToString();
                xNode.Text = team.Name;
                xNode.Icon = "group.png";
                xNode.Action = "javascript:openTeams(" + team.Id + ")";
                tree.Add(xNode);
            }
        }


        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
                 @"
                    function openTeams(id) 
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editTeam.aspx?id=' + id;
                    }
                ");
        }
    }
}