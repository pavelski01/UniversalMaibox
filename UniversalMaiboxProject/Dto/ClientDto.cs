namespace UniversalMaibox.Dto
{
    public class ClientDto
    {
        public ClientDto(
            string host, int port, string login, string passwd, bool ssl = true
        )
        {
            Host = host;
            Port = port;
            Login = login;
            Passwd = passwd;
            Ssl = ssl;
        }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Login { get; set; }
        public string Passwd { get; set; }
        public bool Ssl { get; set; }
    }
}