namespace SocialNetwork
{
    abstract class Nachricht
    {
        protected string _uname;
        protected int _likes;
        protected string _message;

        public Nachricht() { }

        public Nachricht(string uname, string message)
        {
            _uname = uname;
            _message = message;
        }

        public int GetLikes   // property
        {
            get { return _likes; }
            set { _likes = value; }
        }
        public string GetMessage   // property
        {
            get { return _message; }
            set { _message = value; }
        }
        public string GetUname   // property
        {
            get { return _uname; }
            set { _uname = value; }
        }

        public int GiveLike()
        {
            _likes = _likes + 1;
            return _likes;
        }
        public abstract string getNachricht( );
    }
}
