namespace TodoClient;

public sealed class Todo
{
    public int UserId { get; init; }

    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public bool Completed { get; init; }
}
