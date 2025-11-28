namespace Lab2ConsoleApp;

public abstract class CommonCourseBuilder<TCourse, TBuilder> : ICourseBuilder<TCourse, TBuilder>
    where TCourse : CourseCommon, new()
    where TBuilder : CommonCourseBuilder<TCourse, TBuilder>
{
    protected TCourse _course = new();

    public TBuilder WithId(Guid id)
    {
        _course.Id = id;
        return (TBuilder)this;
    }

    public TBuilder WithTitle(string title)
    {
        _course.Title = title ?? throw new ArgumentNullException(nameof(title));
        return (TBuilder)this;
    }

    public TBuilder WithTeacher(Teacher teacher)
    {
        _course.Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
        return (TBuilder)this;
    }

    public virtual TCourse Build()
    {
        return _course;
    }
}