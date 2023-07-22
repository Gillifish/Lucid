using System.Text.Json;

namespace Lucid.Database
{
    public class AccountDB
    {
        private static bool DEBUG = false;
        private string filepath;
        private List<Account> accountData;

        /*
            Constructor for the AccountDB class.
            Takes a string argument for the filename and loads the file data into memory.
        */

        public AccountDB(string filename)
        {   
            if (filename.Length == 0 || filename == null)
            {
                throw new ArgumentException("filename cannot be empty or null");
            }

            string path = "";

            if (DEBUG)
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            } else 
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            }

            this.filepath = path + "/" + filename;

            if (!File.Exists(this.filepath))
            {
                File.WriteAllText(this.filepath, "[]");
            }

            this.accountData = LoadFileData(this.filepath);
        }

        /*
            This method loads the account data into the objects account list.
            Will then return the account data that was just loaded.
        */

        public List<Account> LoadFileData(string filepath)
        {
            if (!File.Exists(this.filepath))
            {
                throw new FileNotFoundException("file not found");
            }

            string rawData = File.ReadAllText(filepath);
            List<Account> data = JsonSerializer.Deserialize<List<Account>>(rawData);

            return data;
        }

        /*
            Saves data loaded into the account list into the file.
        */

        public void SaveData()
        {
            string serializedData = JsonSerializer.Serialize(this.accountData);
            File.WriteAllText(this.filepath, serializedData);
        }

        /*
            Adds an account to the database.
            Returns the account that was added.
            Throws and ArgumentNullException if the account of any of its values are null.
        */

        public Account AddEntry(Account acc)
        {
            if (acc == null || acc.AccountName == null || acc.Username == null || acc.Password == null)
            {
                throw new ArgumentNullException("Account or any of its values cannot be null");
            }

            this.accountData.Add(acc);
            SaveData();

            return acc;
        }

        // Lists all accounts to the console.

        public void ListAccounts()
        {
            foreach (var item in this.accountData)
            {
                Console.WriteLine(item.ToString());
            }
        }

        /*
            Removes an account by the account name and username.
            Returns true if the account was found
        */

        public bool RemoveEntryByAccountName(string accName, string user)
        {
            foreach (Account item in this.accountData)
            {
                if(accName == item.AccountName && user == item.Username)
                {
                    this.accountData.Remove(item);
                    SaveData();

                    return true;
                }
            }

            return false;
        }

        // Returns the filepath

        public string getFilePath() => this.filepath;

        // Returns the account data

        public List<Account> getAccountData() => this.accountData;

        // Clears all data from the file

        public void ClearData() => File.WriteAllText(this.filepath, "[]");
    }
}
