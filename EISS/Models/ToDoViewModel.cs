using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace EIS.Models
{
    public class ToDoViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
    public interface ITodoRepository
    {
        void Add(ToDoViewModel item);
        IEnumerable<ToDoViewModel> GetAll();
        ToDoViewModel Find(string Key);
        ToDoViewModel Remove(string Key);
        void Update(ToDoViewModel item);
    }
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, ToDoViewModel> _todos =
        new ConcurrentDictionary<string, ToDoViewModel>();
        public TodoRepository()
        {
            Add(new ToDoViewModel { Name = "Item1" });
        }
        public IEnumerable<ToDoViewModel> GetAll()
        {
            return _todos.Values;
        }
        public void Add(ToDoViewModel item)
        {
            item.Id = Guid.NewGuid().ToString();
            _todos[item.Id] = item;
        }
        public ToDoViewModel Find(string key)
        {
            ToDoViewModel item;
            _todos.TryGetValue(key, out item);
            return item;
        }
        public ToDoViewModel Remove(string key)
        {
            ToDoViewModel item;
            _todos.TryGetValue(key, out item);
            _todos.TryRemove(key, out item);
            return item;
        }
        public void Update(ToDoViewModel item)
        {
            _todos[item.Id] = item;
        }
    }
}
