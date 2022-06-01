using System;
using System.IO;
using SQLite;
using Turnverein.Services;

using Xamarin.Forms;

[assembly: Dependency(typeof(Turnverein.iOS.Services.SQLite))]

namespace Turnverein.iOS.Services
{
    internal class SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var librarypath = Path.Combine(documentsPath,"..", "Library");
            var path = Path.Combine(librarypath, sqliteFileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}