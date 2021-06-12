namespace SocialNetwork
{
    class Bildnachricht : Nachricht
    {
        private string _filenachricht;
        private string _username;

        public Bildnachricht() { }

        public Bildnachricht(string uname, string message)
          : base(uname, message)
        {
            _username = uname;
            _filenachricht = message;
        }

        public override string getNachricht() 
        {
            string _fullTextMessage = ($"{_filenachricht} {_username} {_likes}");
            return _fullTextMessage;
        }
    }
}
