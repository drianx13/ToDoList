namespace TodoList.Services
{
    public class TodoService : ITodoService
    {
        private readonly IList<TodoItem> _todoItems;

        public TodoService()
        {
            _todoItems = new List<TodoItem> {
            new TodoItem("Wash Clothes"),
            new TodoItem("Clean Desk")
        };
        }

        public void Add(TodoItem item)
        {
            _todoItems.Add(item);
        }
        public void Delete(TodoItem item)
        {
            _todoItems.Remove(item);
        }
        public IEnumerable<TodoItem> GetAll()
        {
            return _todoItems.ToList();
        }
        public void Complete(TodoItem item)
        {
            item.Completed = true;
        }

        public void Uncomplete(TodoItem item)
        {
            item.Completed = false;
        }

        public void Edit(TodoItem item)
        {
            var todoItem = _todoItems.FirstOrDefault(t => t.Text == item.Text);
            if (todoItem != null)
            {
                todoItem.Text = item.Text;
            }
        }

    }
}
