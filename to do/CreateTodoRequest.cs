namespace to_do
{
    public sealed class CreateTodoRequest
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
    }
}
