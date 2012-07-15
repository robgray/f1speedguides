using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco.cms.presentation.Trees;

namespace atomicf1.cms.presentation.Trees
{
    public class LoadResultsTreeCommandFactory
    {
        private BaseTree _baseTree;

        public LoadResultsTreeCommandFactory(BaseTree baseTree)
        {
            _baseTree = baseTree;
        }

        public ILoadResultsTreeCommand GetLoader(string subtreeKey)
        {
            switch (subtreeKey) {

                case "Season":
                    return new loadResultsSeason(_baseTree);                    
                case "Entries":
                    return new loadResultsEntries(_baseTree);
                case "Races":
                    return new loadResultsRaces(_baseTree);
                case "RaceEntry":
                    return new loadResultsRaceEntries(_baseTree);                
            }

            return null;
        }
    }
}