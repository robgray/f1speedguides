using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class loadDrivers : BaseTree
    {
        private IDriverRepository _driverRepository;

        public loadDrivers(string application) : base(application)
        {
            _driverRepository = new DriverRepository();
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
            var drivers = _driverRepository.GetAll();

            foreach(var driver in drivers) {
                var dNode = XmlTreeNode.Create(this);
                dNode.NodeID = driver.Id.ToString();
                dNode.Text = driver.Name;
                dNode.Icon = "user.png";
                dNode.Action = "javascript:openDrivers(" + driver.Id + ")";
                tree.Add(dNode);
            }            
        }

        public override void RenderJS(ref System.Text.StringBuilder Javascript)
        {
            Javascript.Append(
                @"
                    function openDrivers(id) 
                    {
                        parent.right.document.location.href = 'plugins/atomicf1/editDriver.aspx?id=' + id;
                    }
                ");
        }
    }
}