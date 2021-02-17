using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Week6Project
{
    public class TaskManager
    {


        public ObservableCollection<toDoTask> getTasks()
        {
            var tasks = new ObservableCollection<toDoTask>();
            return tasks;
        }
        public static Task<toDoTask> InputBox(INavigation navigation, toDoTask toDo)
        {
            
            if (toDo == null)
            {
                toDo = new toDoTask();
            }

            // wait in this proc, until user did his input 
            var tcs = new TaskCompletionSource<toDoTask>();

            var lblTitle = new Label { Text = "Title", HorizontalOptions = LayoutOptions.Center, FontAttributes = FontAttributes.Bold };
            var lblMessage = new Label { Text = "Enter new Task:" };
            var txtInput = new Entry { Text = toDo.task};
            var isUrgent = new Switch() { IsToggled = toDo.isUrgent};
            var isUrgentLabel = new Label { Text = "is Urgent?" };

            var btnOk = new Button
            {
                Text = "Ok",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8),
            };
            btnOk.Clicked += async (s, e) =>
            {
                // close page
                var result = txtInput.Text;
                toDo.task = result;
                toDo.isUrgent = isUrgent.IsToggled;
                await navigation.PopModalAsync();
                // pass result
                tcs.SetResult(toDo);
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                WidthRequest = 100,
                BackgroundColor = Color.FromRgb(0.8, 0.8, 0.8)
            };
            btnCancel.Clicked += async (s, e) =>
            {
                // close page
                await navigation.PopModalAsync();
                // pass empty result
                tcs.SetResult(null);
            };

            var slButtons = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { btnOk, btnCancel },
            };
            var isUrgentLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { isUrgentLabel, isUrgent },

            };

            var layout = new StackLayout
            {
                Padding = new Thickness(0, 40, 0, 0),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = { lblTitle, lblMessage, txtInput, isUrgentLayout, slButtons },
            };

            // create and show page
            var page = new ContentPage();
            page.Content = layout;
            navigation.PushModalAsync(page);
            // open keyboard
            txtInput.Focus();

            // code is waiting her, until result is passed with tcs.SetResult() in btn-Clicked
            // then proc returns the result
            return tcs.Task;
        }
    }
}
