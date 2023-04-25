namespace Lucid.Database
{
    /*
        Account class for storing data.
    */
    public class Account
    {
        public string AccountName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return @$"------------
{AccountName}
------------
Username: {Username}
Password: {Password}";
        }
    }
}
