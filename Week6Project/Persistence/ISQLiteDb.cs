using System;
using SQLite;
namespace Week6Project.Persistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }


}
