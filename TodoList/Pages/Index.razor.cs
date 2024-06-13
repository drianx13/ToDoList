namespace TodoList.Pages;

public partial class Index
{
    private IList<TodoItem> Todos { get; set; } = new List<TodoItem>();
    private TodoItem? editItem = null;
    private string editText = string.Empty;
    private int currentPage = 1;
    private int itemsPerPage = 10;
    private bool IsFirstPage() => currentPage == 1;
    private bool IsLastPage() => currentPage == TotalPages;


    protected override void OnInitialized()
    {
        LoadTodos();
    }

    private void LoadTodos()
    {
        Todos = _todoService.GetAll().ToList();
    }

    private IEnumerable<TodoItem> DisplayedTodos =>
      Todos.Skip((currentPage - 1) * itemsPerPage).Take(itemsPerPage);

    private int TotalPages =>
        (int)Math.Ceiling((double)Todos.Count / itemsPerPage);

    public string ItemClass(TodoItem item)
    {
        return item.Completed ? "item-completed" : string.Empty;
    }

    public void ItemsChanged()
    {
        LoadTodos();
        StateHasChanged();
    }

    public void DeleteItem(TodoItem item)
    {
        _todoService.Delete(item);
        ItemsChanged();
    }

    public void EditItem(TodoItem item)
    {
        editItem = item;
        editText = item.Text;
    }

    public void SaveEditItem()
    {
        if (editItem != null)
        {
            editItem.Text = editText;
            _todoService.Edit(editItem);
            ItemsChanged();
            editItem = null;
            editText = string.Empty;
        }
    }

    public void CancelEdit()
    {
        editItem = null;
        editText = string.Empty;
    }

    public void CompleteItem(TodoItem item)
    {
        _todoService.Complete(item);
        ItemsChanged();
    }

    public void UncompleteItem(TodoItem item)
    {
        _todoService.Uncomplete(item);
        ItemsChanged();
    }

    private void GoToFirstPage()
    {
        currentPage = 1;
    }

    private void GoToPreviousPage()
    {
        if (!IsFirstPage())
        {
            currentPage--;
        }
    }

    private void GoToNextPage()
    {
        if (!IsLastPage())
        {
            currentPage++;
        }
    }

    private void GoToLastPage()
    {
        currentPage = TotalPages;
    }

}
