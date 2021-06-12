namespace SocialNetwork
{
    class Textnachricht : Nachricht
    {
        private string _nachricht;
        private string _username;

        public Textnachricht() { }

        public Textnachricht(string uname, string message)
          : base(uname, message)
        {

            _username = uname;
            _nachricht = message;

        }

        public override string getNachricht( )
        {
            string _fullTextMessage = ($"{_nachricht} {_username} {_likes}");
            return _fullTextMessage;
        }
    }

}
