namespace ToDoListProject.Models
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsDone { get; set; } = false;
        public TodoItem() { }
        public TodoItem(string v1, bool v2)
        {
            this.Title = v1;
            this.IsDone = v2;
        }

    }
}
