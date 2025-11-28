namespace Lab2ConsoleApp;

public class OfflineCourseBuilder : CommonCourseBuilder<OfflineCourse, OfflineCourseBuilder>
{
    public OfflineCourseBuilder InRoom(string room)
    {
        _course.Room = room ?? throw new ArgumentNullException(nameof(room));
        return this;
    }

    public OfflineCourseBuilder WithCapacity(int capacity)
    {
        _course.Capacity = capacity;
        return this;
    }
}