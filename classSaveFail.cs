using System;
using System.Collections.Generic;
using System.IO;

namespace CyberFox;

public static class SaveFail {

    public static void SaveOkImap(List<string> okImap) {
        
        string  nameFailImapOk  = "base/okimap.txt";

        if (okImap.Count > 0) {

            using (StreamWriter writer = new StreamWriter(nameFailImapOk)) {
                foreach (string line in okImap){
                    writer.WriteLine(line);
                }
            }
        }
        System.Console.Write("\n\nEmail accounts in status ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Ok: {okImap.Count}     ");
        Console.ResetColor();

    }


    public static void SaveBadImap(List<string> badImap) {

        string  nameFailImapBad = "base/badimap.txt";
        
        if (badImap.Count > 0) {
        
            using (StreamWriter writer = new StreamWriter(nameFailImapBad)) {
                
                foreach (string line in badImap){
                    writer.WriteLine(line);
                }
            }
        }   

        System.Console.Write("Email accounts in status ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Bad: {badImap.Count}\n\n\n");
        Console.ResetColor();

    }


}