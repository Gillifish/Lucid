using Lucid.Database;

namespace Lucid.IO
{

    /*
        This class is what contols the I/O interactions of the LucidCLI program.
    */

    public class Control
    {
        public static void DisplayCommands()
        {
            Console.WriteLine();
            Console.WriteLine("Usage: lucid [options]");
            Console.WriteLine();
            Console.WriteLine("Options:");
            Console.WriteLine(" a  | add           Adds an account");
            Console.WriteLine(" rm | remove        Removes an account");
            Console.WriteLine(" l  | list          Lists all saved accounts");
            Console.WriteLine(" h  | help     Displays all commands");
            Console.WriteLine(" wipe          Deletes all data from database");
        }

        public static void Add(AccountDB db)
        {
            Account acc = new Account();

            Console.Write("Enter Account Name: ");
            acc.AccountName = Console.ReadLine();

            Console.Write("Enter Username: ");
            acc.Username = Console.ReadLine();

            Console.Write("Enter Password: ");
            acc.Password = Console.ReadLine();
            
            db.AddEntry(acc);

            Console.WriteLine("Account successfully added...");
        }   

        public static void Remove(AccountDB db)
        {
            Console.Write("Enter Account Name: ");
            string accName = Console.ReadLine();

            Console.Write("Enter Username: ");
            string user = Console.ReadLine();

            if (db.RemoveEntryByAccountName(accName, user))
            {
                Console.WriteLine("[LUCID] Account successfully removed.");
            } else 
            {
                Console.WriteLine("[ERROR] Unable to find account");
            }
        }

        public static void List(AccountDB db) => db.ListAccounts();
        
        public static void Wipe(AccountDB db) 
        {
            Console.WriteLine("[WARNING] This is a destructive action! Are you sure you want to continue? (y/n)");
            Console.Write(">");

            if (Console.ReadLine().ToLower().Equals("y"))
            {
                Console.WriteLine("Are you sure? (y/n)");
                Console.Write(">");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    db.ClearData();
                    Console.WriteLine("[LUCID] Data successfully cleared.");
                    return;
                }
            }

            Console.WriteLine("[LUCID] Action aborted.");
        }
    }
}