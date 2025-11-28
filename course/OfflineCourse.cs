namespace Lab2ConsoleApp;

public class OfflineCourse : CourseCommon
{
    public OfflineCourse(Guid id, string title, string room, int capacity) : base(id, title)
    {
        Room = room ?? throw new ArgumentNullException(nameof(room));
        Capacity = capacity;
    }

    public OfflineCourse()
    {
    }

    public string Room { get; set; }
    public int Capacity { get; set; }

    public override string GetDescription()
    {
        return $"[OFFLINE] {Title} in {Room} with capacity {Capacity}";
    }
}