using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Turnverein.Models;
using Xamarin.Forms;

namespace Turnverein.Services
{
    public class TokenDataBaseController
    {
        private static object locker = new object();

        private SQLiteConnection database;

        public TokenDataBaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
        }

        public Token GetToken()
        {
            lock (locker)
            {
                if (database.Table<Token>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Token>().First();
                }
            }
        }

        public int SaveToken(Token token)
        {
            lock (locker)
            {
                if (token.Id != 0)
                {
                    return database.Update(token);
                }
                else
                {
                    return database.Insert(token);
                }
            }
        }
        public int DeleteToken(int id)
        {
            lock (locker)
            {
                return database.Delete<Token>(id);
            }
        }
    }
}
