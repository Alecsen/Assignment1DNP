namespace Shared;

public class Post
{
    public int Id { get; set; }
    public User owner { get; }
    public string Title { get; }
    public string body { get; set; }

    public Post(User owner, string title, string body)
    {
        this.owner = owner;
        Title = title;
        this.body = body;
    }
}