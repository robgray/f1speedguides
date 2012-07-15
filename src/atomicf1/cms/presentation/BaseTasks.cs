using umbraco.interfaces;

namespace atomicf1.cms.presentation
{
    public abstract class BaseTasks : ITaskReturnUrl
    {
        protected const string BasePageDirectory = "plugins/atomicf1/";

        protected string _returnUrl;
        protected string _alias;
        protected int _typeId;
        protected int _parentId;
        protected int _userId;

        public string ReturnUrl
        {
            get { return _returnUrl; }
        }

        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
            }
        }

        public abstract bool Delete();
        
        public int ParentID
        {
            get
            {
                return _parentId;
            }
            set
            {
                _parentId = value;
            }
        }

        public abstract bool Save();
        

        public int TypeID
        {
            get
            {
                return _typeId;
            }
            set
            {
                _typeId = value;
            }
        }

        public int UserId
        {
            set { _userId = value; }
        }             
    }
}