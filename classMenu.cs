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

        Console.WriteLine("В данной программе вы можете проверить на валидность свой список электронных почтовых ящиков.\nДанный список вы должны положить в файл: imap.txt \n\nФормат файла:");
        Console.WriteLine("mail1@domen.com:password\nmail2@domen.com:password\nmail3@domen.com:password\nmail4@domen.com:password");

        Console.WriteLine("\n\nЕсли вы готовы продолжить нажмите: y / n ");
        Console.Write("Сделайте сыой выбор: ");
        resultStarta = Convert.ToChar(Console.Read());

        ObrabotkaFailImap(resultStarta);

    }

    public static void ObrabotkaFailImap(char _resultStarta) {

        char resultStarta = _resultStarta;

        if (resultStarta == 'y') {
            
            List<Dictionary<string, string>> emailData = new List<Dictionary<string, string>>();
            
            Fail failInstance = new Fail();

            failInstance.FailOpen("imap.txt", failInstance.emailData, 0);

            Console.WriteLine("\n\nМы нашли в файле: " + failInstance.GetColStr() + " строк.\n\n");

            ImapLoginChecker imapCeck = new ImapLoginChecker();

            if (failInstance.GetColStr() > 0) {    
                MenuProgram.Massivimap(failInstance.emailData);
            }else{
                Console.WriteLine("В файле с адресами IMAP нет записей, добавьте записи и попробуйте сново!");
                MenuProgram.StartMenuOpisanie();
            }

        }else if (resultStarta == 'n') {
            Console.WriteLine("Программа остановлена!");
        }else{
            System.Console.WriteLine("\n\n");
            MenuProgram.StartMenuOpisanie();
        }

    }


    public static void Massivimap(List<Dictionary<string, string>> emailData) {
        foreach(var el in emailData) {

        foreach (var strArray in el) {
            
            Console.WriteLine($"{strArray.Key}: {strArray.Value}");
        }

            Console.WriteLine("\n");
        }

    }




}