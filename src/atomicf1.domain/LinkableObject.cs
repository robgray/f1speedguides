using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using atomicf1.common;

namespace atomicf1.domain
{    
    public class LinkableObject<T> : DomainObject<T>
    {        
        public virtual string Name { get; set; }

        private string _url;
        
        public virtual string Url
        {
            get
            {
                if (string.IsNullOrEmpty(_url))
                {
                    return UrlHelpers.UrlFriendly(Name);
                }
                return UrlHelpers.UrlFriendly(_url);
            }
            set { _url = value; }
        }
    }
}
