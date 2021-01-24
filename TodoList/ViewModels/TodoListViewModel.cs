using System.Collections.ObjectModel;
using TodoList.Models;

namespace TodoList.ViewModels
{
    public class TodoListViewModel: BaseViewModel
    {
        ObservableCollection<TodoItem> _todoList;
        public ObservableCollection<TodoItem> TodoList
        {
            get { return _todoList; }
            set
            {
                _todoList = value;
                OnPropertyChanged();
            }
        }

        public TodoListViewModel()
        {
            TodoList = new ObservableCollection<TodoItem>();
            TodoList.Add(new TodoItem
            {
                Title = "Buy milk",
                Done = false,
            });
            TodoList.Add(new TodoItem
            {
                Title = "Learn Xamarin",
                Done = false,
            });
            TodoList.Add(new TodoItem
            {
                Title = "Learn C#",
                Done = false,
            });
        }

        public void DeleteItem(TodoItem item)
        {
            TodoList.Remove(item);
        }
    }
}
