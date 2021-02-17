using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SQLite;
using Week6Project.Persistence;
using Xamarin.Forms;

namespace Week6Project
{
    public class DBManager
    {
        private SQLiteAsyncConnection _connection;
        public DBManager()
        {
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();

        }

        public async Task<ObservableCollection<toDoTask>> CreateTable()
        {
            await _connection.CreateTableAsync<toDoTask>();
            var todoTaskFromDB = await _connection.Table<toDoTask>().ToListAsync();
            var allTasks = new ObservableCollection<toDoTask>(todoTaskFromDB);
            return allTasks;
        }

        public void insertNewToDo(toDoTask task)
        {
            _connection.InsertAsync(task);
        }

        public void deleteTask(toDoTask toDelete)
        {
            _connection.DeleteAsync(toDelete);
        }
        public void updateTask(toDoTask toUpdate)
        {
            _connection.UpdateAsync(toUpdate);

        }
    }
}
