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
        private string TODO_LIST_PROP_NAME = "todos";

        private TodoListViewModel _todoListViewModel;
        public MainPage()
        {
            InitializeComponent();
            _todoListViewModel = new TodoListViewModel();
            BindingContext = _todoListViewModel;

            // Load todo list from the app properties
            if (Application.Current.Properties.ContainsKey(TODO_LIST_PROP_NAME))
            {
                var list = Application.Current.Properties[TODO_LIST_PROP_NAME].ToString();
                _todoListViewModel.Deserialize(list);
            }

            _todoListViewModel.PropertyChanged += _todoListViewModel_PropertyChanged;
        }

        private void _todoListViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var list = _todoListViewModel.Serialize();
            Application.Current.Properties[TODO_LIST_PROP_NAME] = list;
        }

        private void Save()
        {
            var list = _todoListViewModel.Serialize();
            Application.Current.Properties[TODO_LIST_PROP_NAME] = list;
        }

        public void OnDone(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.CheckItem((Models.TodoItem)mi.CommandParameter);
            Save();
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            _todoListViewModel.DeleteItem((Models.TodoItem)mi.CommandParameter);
            Save();
        }

        private async Task NewItem()
        {
            string result = await DisplayPromptAsync("New item", "Please enter the title");
            if (result != null)
            {
                _todoListViewModel.AddItem(result);
                Save();
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

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            Save();
        }
    }
}
