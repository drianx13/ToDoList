using Microsoft.AspNetCore.Components;

namespace TodoList.Shared
{
    public partial class TodoItemForm
    {
        private TodoItem NewItem { get; set; } = new TodoItem("");

        private void ItemAdded()
        {
            var newItem = new TodoItem(NewItem.Text);
            NewItem.Text = "";
            _todoService.Add(newItem);
            OnItemAdded.InvokeAsync();
        }

        [Parameter]
        public EventCallback OnItemAdded { get; set; }
    }
}
