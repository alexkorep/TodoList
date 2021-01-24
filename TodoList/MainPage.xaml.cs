using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ViewModels.TodoListViewModel();
            //TodoListView.ItemsSource = BindingContext.TodoList;

            // TODO Load todo list from the app properties
            //if (Application.Current.Properties.ContainsKey("Name"))
            //{
            //    userNickName.Text = Application.Current.Properties["Name"].ToString();
            //}

        }
    }
}
