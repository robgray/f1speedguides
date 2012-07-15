using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using atomicf1.domain.Repositories;
using atomicf1.persistence;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public abstract class BaseLoadResultsTreeCommand : ILoadResultsTreeCommand
    {
        protected BaseTree _baseTree;
        protected ISeasonRepository _seasonRepository;

        public BaseLoadResultsTreeCommand(BaseTree tree)
        {
            _baseTree = tree;
            _seasonRepository = new SeasonRepository();
        }

        public abstract void Populate(ref XmlTree tree, int keyId);

        public TreeService GetTreeService(int keyId, string nodeKey)
        {
            return new TreeService(keyId, _baseTree.TreeAlias, _baseTree.ShowContextMenu, _baseTree.IsDialog, _baseTree.DialogMode, _baseTree.app, nodeKey);
        }
    }
}