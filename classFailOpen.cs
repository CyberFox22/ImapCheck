using System;
using System.Collections.Generic;

namespace CyberFox;

class Fail {

    private string path = "imap.txt";
    private int colStr = 0;
    public List<Dictionary<string, string>> emailData = new List<Dictionary<string, string>>();

    public void FailOpen(string path, List<Dictionary<string, string>> emailData, int colStr = 0) {

        this.path      = path;
        this.emailData = emailData;
        this.colStr    = colStr;


        try {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;

                while ((line = reader.ReadLine()) != null) {
                    
                    string[] parts = line.Split(':');

                    if (parts.Length >= 2) {
                        
                        string[] emailParts = parts[0].Split('@');

                        if (emailParts.Length == 2) {

                            Dictionary<string, string> entry = new Dictionary<string, string> {
                                { "mail", parts[0] },
                                { "server", "mail." + emailParts[1] },
                                { "password", parts[1] },
                                { "port", "143" }
                            };
                            
                            emailData.Add(entry);
                        }

                    }
                    
                }
            }

            this.colStr = emailData.Count;

        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while reading the file: {e.Message}");
        }

    }

    public void DataFail() {
        
    }

    public int GetColStr() => this.colStr;
    public List<Dictionary<string, string>> GetArray() => this.emailData;

}