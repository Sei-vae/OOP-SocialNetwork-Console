namespace SocialNetwork
{
    class Person
    {
        private string _nname;
        private string _vname;
        private string _pw;
        private string _uname;

        public Person() { }

        public Person(string vname, string nname, string uname, string pw)
        {
            _vname = vname;
            _nname = nname;
            _uname = uname;
            _pw = pw;
        }

        public string GetUsername   // property
        {
            get { return _uname; }
            set { _uname = value; }
        }
        public string GetNachname   // property
        {
            get { return _nname; }
            set { _nname = value; }
        }
        public string GetVorname   // property
        {
            get { return _vname; }
            set { _vname = value; }
        }
        public string GetAndSetPW   // property
        {
            get { return _pw; }
            set { _pw = value; }
        }
    }
}
