using System.IO;
using SQLite;
using Turnverein.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Turnverein.Droid.Services.SQLite))]

namespace Turnverein.Droid.Services
{
    internal class SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "TestDB.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var connection = new SQLiteConnection(path);

            return connection;
        }
    }
}