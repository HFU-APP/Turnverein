using SQLite;

namespace Turnverein.Services
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
