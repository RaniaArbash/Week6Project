using System;
using System.IO;
using SQLite;
using Week6Project.Droid;
using Week6Project.Persistence;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLiteDb))]
namespace Week6Project.Droid
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
