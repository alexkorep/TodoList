using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.ViewModels;
using Xamarin.Forms;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        private TodoListViewModel _todoListViewModel;
        public MainPage()
        {
            InitializeComponent();
            _todoListViewModel = new TodoListViewModel();
            BindingContext = _todoListViewModel;

            // TODO Load todo list from the app properties
            //if (Application.Current.Properties.ContainsKey("Name"))
            //{
            //    userNickName.Text = Application.Current.Properties["Name"].ToString();
            //}

        }

        public void OnDone(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.CheckItem((Models.TodoItem)mi.CommandParameter);
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.DeleteItem((Models.TodoItem)mi.CommandParameter);
        }

        private async Task NewItem()
        {
            string result = await DisplayPromptAsync("New item", "Please enter the title");
            if (result != null)
            {
                _todoListViewModel.AddItem(result);
            }
        }

        public void OnFabMenuClick(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(
                    async () =>
                    {
                        await NewItem();
                    });

            });
        }

        public void ItemChecked(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.DeleteItem((Models.TodoItem)mi.CommandParameter);
        }
    }
}
