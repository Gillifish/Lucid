using System;
using System.IO;
using System.Text.Json;

namespace Lucid.Database
{
    public class AccountDB
    {
        private static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string filename = path + "/LucidDBCLI.json";

        public static void GenerateFile()
        {
            Console.WriteLine("[Lucid] Generating database file...");

            File.WriteAllText(filename, "[]");
        }

        public static List<Account> ReturnData()
        {
            List<Account> accList;

            var rawData = File.ReadAllText(filename);
            accList = JsonSerializer.Deserialize<List<Account>>(rawData);

            return accList;
        }

        public static void AddEntry(Account acc)
        {
            List<Account> currentData = ReturnData();

            currentData.Add(acc);

            var serializedData = JsonSerializer.Serialize(currentData);
            File.WriteAllText(filename, serializedData);
        }

        public static void ListAccounts()
        {
            List<Account> data = ReturnData();

            foreach (var item in data)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void RemoveEntryByAccName(string accName, string user)
        {
            List<Account> data = ReturnData();

            foreach (var item in data)
            {
                if(accName == item.AccountName && user == item.Username)
                {
                    data.Remove(item);
                }

                var serializedData = JsonSerializer.Serialize(data);
                File.WriteAllText(filename, serializedData);
            }
        }

        public static void FileCheck()
        {
            if (!File.Exists(filename))
            {
                GenerateFile();
            }
        }

        public static void ClearData()
        {
            File.WriteAllText(filename, "[]");
        }
    }

    public class Account
    {
        public string AccountName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return @$"------------
{AccountName}
------------
Username: {Username}
Password: {Password}";
        }
    }
}
