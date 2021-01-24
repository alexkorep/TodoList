using System;
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
                Done = true,
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

        public void CheckItem(TodoItem item)
        {
            int index = TodoList.IndexOf(item);
            TodoList.Remove(item);
            TodoList.Insert(index, new TodoItem
            {
                Title = item.Title,
                Done = !item.Done,
            });
        }

        public void DeleteItem(TodoItem item)
        {
            TodoList.Remove(item);
        }

        public void AddItem(string text)
        {
            TodoList.Add(new TodoItem
            {
                Title = text,
                Done = false,
            });
        }
    }
}
