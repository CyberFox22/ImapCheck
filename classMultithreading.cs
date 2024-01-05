using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

namespace CyberFox;

    class Multithredings {

        public static void ParallelMultithredings (List<Dictionary<string, string>> dataArray, int colPotokov) {

            ImapLoginChecker checker = new ImapLoginChecker();

            List<string> okImap  = new List<string>();
            List<string> badImap = new List<string>();

            string? strOk, strBad;

            Parallel.ForEach(dataArray, new ParallelOptions { MaxDegreeOfParallelism = colPotokov }, entry => {
                string email    = entry["mail"];
                string password = entry["password"];
                string server   = entry["server"];
                int port        = int.Parse(entry["port"]);

                bool isLoginSuccessful = checker.CheckLogin(email, password, server, port);

                if (isLoginSuccessful) {
                    
                    Console.Write($"Successful authentication for {email} ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Ok\n");
                    Console.ResetColor();

                    strOk = email+":"+password+":"+server+":"+port;
                    okImap.Add(strOk);
                }else{

                    Console.Write($"Unsuccessful authentication for {email} ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Bad\n");
                    Console.ResetColor();

                    strBad = email+":"+password+":"+server+":"+port;
                    badImap.Add(strBad);                    
                }
            });

            SaveFail.SaveOkImap(okImap);
            SaveFail.SaveBadImap(badImap);

        }
        
    }