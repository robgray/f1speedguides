using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public interface ILoadResultsTreeCommand
    {
        void Populate(ref XmlTree tree, int keyId);
    }
}
