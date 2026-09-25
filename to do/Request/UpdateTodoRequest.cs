namespace to_do.Request
{
    public sealed class UpdateTodoRequest
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
    }
}
