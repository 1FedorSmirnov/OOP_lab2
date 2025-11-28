namespace Lab2ConsoleApp;

public interface ICourseBuilder<TCourse, TBuilder>
    where TCourse : ICourse
    where TBuilder : ICourseBuilder<TCourse, TBuilder>
{
    TBuilder WithId(Guid id);
    TBuilder WithTitle(string title);
    TBuilder WithTeacher(Teacher teacher);
    TCourse Build();
}