using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.cms.presentation.Trees;
using umbraco.BusinessLogic;
using umbraco.DataLayer;

namespace atomicf1.cms.presentation.Trees
{
    public class loadCircuits : BaseTree
    {
        private ICircuitRepository _repository;

        public loadCircuits(string application) : base(application)
        {
            _repository = new CircuitRepository();
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
            var circuits = _repository.GetAll();
            foreach(var circuit in circuits) {
                XmlTreeNode xNode = XmlTreeNode.Create(this);
                xNode.NodeID = circuit.Id.ToString();
                xNode.Text = circuit.Name + " - " + circuit.Country;
                xNode.Icon = "map.png";
                xNode.Action = "javascript:openCircuits(" + circuit.Id + ")";
                tree.Add(xNode);
            }
        }

        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
                @"
                    function openCircuits(id) 
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editCircuit.aspx?id=' + id;
                    }
                ");
        }
    }
}