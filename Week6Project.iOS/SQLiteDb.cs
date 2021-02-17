using System;
using Week6Project.Persistence;
using Xamarin.Forms;
using SQLite;
using System.IO;
using Week6Project.iOS;

[assembly: Dependency(typeof(SQLiteDb))]

namespace Week6Project.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
