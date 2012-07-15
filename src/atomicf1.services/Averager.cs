using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace atomicf1.services
{
    public class IntAverager<TEntity> : IAverager<TEntity, int>
    {
        private IList<int> values;
        private TEntity _entity;

        public IntAverager(TEntity entity)
        {
            _entity = entity;
            values = new List<int>();
        }

        public TEntity Entity
        {
            get { return _entity;  }
        }

        public void Add(int value)
        {
            values.Add(value);
        }

        public double Average
        {
            get { return values.Average(); }
        }
    }
}
