using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PasswordManager
{
    public class AccountContext : DbContext 
    {
        public DbSet<Account> Accounts {get; set;}
        public string DbPath {get;}

        public AccountContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "Accounts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class DBAccess
    {
        public static void ListAccounts()
        {
            using(var db = new AccountContext())
            {
                foreach (var item in db.Accounts)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine();
                }
            }
        }
        public static void AddEntry(Account acc)
        {
            using(var db = new AccountContext())
            {
                db.Add(new Account {
                    AccountName = acc.AccountName,
                    Username = acc.Username,
                    Password  = acc.Password
                });
                db.SaveChanges();
            }       
        }

        public static void RemoveEntryByAccName(string accName, string user)
        {
            using(var db = new AccountContext())
            {
                foreach (var item in db.Accounts)
                {
                    if(item.AccountName == accName && item.Username == user)
                    {
                        db.Remove(item);
                        db.SaveChanges();
                        break;
                    }
                }
            }
        }

        public static void ClearData()
        {
            using(var db = new AccountContext())
            {
                foreach (var item in db.Accounts)
                {
                    db.Remove(item);
                }

                db.SaveChanges();
            }
        }
    }

    public class Account
    {
        public int Id {get; set;}
        public string AccountName {get; set;}
        public string Username {get; set;}
        public string Password {get; set;}

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