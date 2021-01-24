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

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.DeleteItem((Models.TodoItem)mi.CommandParameter);
        }
    }
}
