using Shared;

namespace FileData;

public class DataContainer
{
    public ICollection<User> Users { get; set; }
    public ICollection<Post> posts { get; set; }
}