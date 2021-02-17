using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Week6Project.Persistence;
using Xamarin.Forms;
namespace Week6Project
{

    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        DBManager dbModel = new DBManager();
        ObservableCollection<toDoTask> allTasks;
        public MainPage()
        {
            InitializeComponent();

        }

        protected async override void OnAppearing()
        {

            allTasks = await dbModel.CreateTable();
            allTasksTable.ItemsSource = allTasks;
            base.OnAppearing();

        }

        public async void addNewTask(object sender, EventArgs e)
        {
            toDoTask newTask = await TaskManager.InputBox(this.Navigation,null);
            if (newTask != null)
            {
                allTasksTable.ItemsSource = null;
                allTasks.Add(newTask);
                allTasksTable.ItemsSource = allTasks;
                dbModel.insertNewToDo(newTask);
            }


        }

        public void deleteFromDB(object sender, EventArgs e)
        {
            var toDelete = ((sender as MenuItem).CommandParameter as toDoTask);
            allTasks.Remove(toDelete);
            dbModel.deleteTask(toDelete);
        }

        public async void updateDB(object sender, EventArgs e)
        {
            

            var toUpdate = allTasksTable.SelectedItem as toDoTask;
            var updatedTask = await TaskManager.InputBox(this.Navigation, toUpdate );
            if (updatedTask != null )
            {
                dbModel.updateTask(updatedTask);
            }





        }
    }

}
