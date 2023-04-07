using System;
using Lucid.Database;
using Lucid.IO;

public class Program
{
    public static void Main(string[] args)
    {
        AccountDB db = new AccountDB("LucidDB.json");

        if (args.Length == 0)
        {
            Control.DisplayCommands();
            Environment.Exit(0);
        } 

        switch (args[0].ToLower())
        {
            case "h": case "help":
                Control.DisplayCommands();
                break;
            case "a": case "add":
                Control.Add(db);
                break;
            case "rm": case "remove":
                Control.Remove(db);
                break;
            case "l": case "list":
                Control.List(db);
                break;
            case "wipe":
                Control.Wipe(db);
                break;
            default:
                Console.WriteLine("[ERROR] Unkown command...");
                Control.DisplayCommands();
                break;
        }
    }
}
