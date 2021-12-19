namespace WebApi.Dto;

public class TodoItemBriefDto
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }
    public int Order { get; set; }

    public bool IsComplete { get; set; }
}