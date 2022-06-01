using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SQLite;
using Turnverein.Models;
using Xamarin.Forms;

namespace Turnverein.Services
{
    public class AccountDataBaseController
    {
        private static object locker = new object();

        private SQLiteConnection database;

        public AccountDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
        }

        public Account GetAccount()
        {
            lock (locker)
            {
                if (database.Table<Account>().Count() == 0)
                {
                    return null;    
                }
                else
                {
                    return database.Table<Account>().First();
                }
            }
        }

        public int SaveAccount(Account account)
        {
            lock (locker)
            {
                if (account.Id != 0)
                {
                    return database.Update(account);
                }
                else
                {
                    return database.Insert(account);
                }
            }
        }
        public int DeleteAccount(int id)
        {
            lock (locker)
            {
                return database.Delete<Account>(id);
            }
        }
    }
}
