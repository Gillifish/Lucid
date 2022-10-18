using System;

namespace PasswordManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                DisplayCommands();
            }

            if(args.Length != 0)
            {
                if(args[0] == "add")
                {
                    AddProcess();
                }
                if(args[0] == "remove")
                {
                    RemoveProcess();
                }

                if(args[0] == "list")
                {
                    ListProcess();
                }

                if(args[0] == "h" || args[0] == "help")
                {
                    DisplayCommands();
                }

                if(args[0] == "wipe")
                {
                    WipeDatabase();
                }
            }
        }

        public static void DisplayCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: lucid [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine(" -add           Adds an account");
            Console.WriteLine(" -remove        Removes an account");
            Console.WriteLine(" -list          Lists all saved accounts");
            Console.WriteLine(" -h | -help     Displays all commands");
            Console.WriteLine(" -wipe          Deletes all data from database");
        }

        public static void AddProcess()
        {
            string accName = "";
            string user = "";
            string pass = "";
            bool info = true;

            Console.WriteLine("[Lucid] Starting account creation...");

            while(info)
            {
                var acc = CreateAccount();

                Console.WriteLine($"Account Name: {acc[0]}\nUsername: {acc[1]}\nPassword: {acc[2]}");
                Console.WriteLine("Is this information correct? [y/n]");
                
                while(true)
                {
                    var ans = Console.ReadLine();

                    if(ans == "y")
                    {
                        accName = acc[0];
                        user = acc[1];
                        pass = acc[2];
                        info = false;
                        break;
                    }
                    if(ans == "n")
                    {
                        acc = CreateAccount();
                        Console.WriteLine($"Account Name: {acc[0]}\nUsername: {acc[1]}\nPassword: {acc[2]}");
                        Console.WriteLine("Is this information correct? [y/n]");
                    }
                }
            }

            var NewAccount = new Account 
            {
                AccountName = accName,
                Username = user,
                Password = pass
            };

            Console.WriteLine("[Lucid] Adding account...");
            
            //TODO: Add function for adding database entries

            Console.WriteLine("[Lucid] Account successfully added");
        }

        public static void RemoveProcess()
        {
            string accName = "";
            string user = "";

            Console.WriteLine("[Lucid] Select an account to remove by entering the account name and username");
            Console.WriteLine("Enter the account name: ");
            accName = Console.ReadLine();

            Console.WriteLine("Enter the username: ");
            user = Console.ReadLine();

            Console.WriteLine("[Lucid] Removing account...");
            
            //TODO: Add function for removing database entries

            Console.WriteLine("[Lucid] Account removed");
        }

        public static void ListProcess()
        {
            Console.WriteLine("[LUCID] Now listing all accounts...");
            

            //TODO: Add function for listing database entries
        }

        public static string[] CreateAccount()
        {
            string[] acc = new string[3];

            Console.WriteLine("Enter Account Name:");
            acc[0] = Console.ReadLine();

            Console.WriteLine("Enter Username:");
            acc[1] = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            acc[2] = Console.ReadLine();

            return acc;
        }

        public static void WipeDatabase()
        {
            Console.WriteLine("[Lucid] WARNING: You have chosen to wipe the database!");
            Console.WriteLine("[Lucid] This action is destructive and data cannot be recovered!");
            Console.WriteLine();
            Console.WriteLine("Delete all data? [y/n]");

            var ans = Console.ReadLine();

            if(ans == "y")
            {
                Console.WriteLine("[Lucid] Wiping Database...");
                
                //TODO: Add function for clearing database

                Console.WriteLine("[Lucid] Database wiped");
            }

            if(ans != "y" || ans == "n")
            {
                Console.WriteLine("[Lucid] Database unchanged");
            }
        }
    }
}