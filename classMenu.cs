using System;
using System.Timers;

namespace CyberFox;

public class MenuProgram() {


    public static void StartLogo() {

        Console.WriteLine(@"
░█████╗░██╗░░░██╗██████╗░███████╗██████╗░  ███████╗░█████╗░██╗░░██╗
██╔══██╗╚██╗░██╔╝██╔══██╗██╔════╝██╔══██╗  ██╔════╝██╔══██╗╚██╗██╔╝
██║░░╚═╝░╚████╔╝░██████╦╝█████╗░░██████╔╝  █████╗░░██║░░██║░╚███╔╝░
██║░░██╗░░╚██╔╝░░██╔══██╗██╔══╝░░██╔══██╗  ██╔══╝░░██║░░██║░██╔██╗░
╚█████╔╝░░░██║░░░██████╦╝███████╗██║░░██║  ██║░░░░░╚█████╔╝██╔╝╚██╗
░╚════╝░░░░╚═╝░░░╚═════╝░╚══════╝╚═╝░░╚═╝  ╚═╝░░░░░░╚════╝░╚═╝░░╚═╝
        ");

    }


    public static void StartMenuOpisanie() {

        char resultStarta;

        Console.WriteLine("In this program, you can validate your list of email addresses.\nYou should save this list to a file.: base/imap.txt \n\nFile format:");
        Console.WriteLine("mail1@domen.com:password\nmail2@domen.com:password\nmail3@domen.com:password\nmail4@domen.com:password\n");
        Console.WriteLine("The execution result will be saved in files in the same folder where your validation list is located.");

        Console.WriteLine("\n\nIf you are ready to proceed, press: y / n ");
        Console.Write("Make your choice: ");
        resultStarta = Convert.ToChar(Console.Read());

        ObrabotkaFailImap(resultStarta);

    }

    public static void ObrabotkaFailImap(char _resultStarta) {

        char resultStarta = _resultStarta;

        if (resultStarta == 'y') {
            
            List<Dictionary<string, string>> emailData = new List<Dictionary<string, string>>();
            
            Fail failInstance = new Fail();

            failInstance.FailOpen("base/imap.txt", failInstance.emailData, 0);

            Console.WriteLine("\n\nWe found in the file: " + failInstance.GetColStr() + " strings.\n");

            ImapLoginChecker imapCeck = new ImapLoginChecker();

            if (failInstance.GetColStr() > 0) {    
                MenuProgram.SelectParallel(failInstance.emailData);
            }else{
                Console.WriteLine("The IMAP address file has no entries. Please add entries and try again!");
                MenuProgram.StartMenuOpisanie();
            }

        }else if (resultStarta == 'n') {
            Console.WriteLine("The program has been stopped!");
        }else{
            System.Console.WriteLine("\n\n");
            MenuProgram.StartMenuOpisanie();
        }

    }

    public static void SelectParallel(List<Dictionary<string, string>> emailData) {

        int resultParallel;
        string? input;

        Console.ReadLine();
        Console.Write("\nSpecify the number of processing threads: ");
        input = Console.ReadLine();

        if (int.TryParse(input?.Trim(), out resultParallel)) {
            Multithredings.ParallelMultithredings(emailData, resultParallel);
            
            //Console.WriteLine($"\n\nSelected number of threads: {resultParallel}\n\n\n");         
        }else{
            Console.WriteLine("You entered a non-numeric value!");
            MenuProgram.SelectParallel(emailData);
        }      

    }


}