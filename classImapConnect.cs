using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

namespace CyberFox;

class ImapLoginChecker
{
    public bool CheckLogin(string email, string password, string server, int port)
    {
        try
        {
            using (var client = new ImapClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect(server, port, SecureSocketOptions.Auto);
                client.Authenticate(email, password);

                client.Disconnect(true);

                return true; // Успешная аутентификация
            }
        }
        catch (Exception)
        {
            return false; // Неудачная аутентификация
        }
    }
}
