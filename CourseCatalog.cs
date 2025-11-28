namespace Lab2ConsoleApp;

//Пример Singleton
public sealed class CourseCatalog
{
    private readonly Dictionary<Guid, CourseCommon> _courses = new();

    private CourseCatalog()
    {
    }

    public void Clear()
    {
        _courses.Clear();
    }

    public static CourseCatalog Instance { get; } = new();

    public void AddCourse(CourseCommon course)
    {
        ArgumentNullException.ThrowIfNull(course);
        _courses[course.Id] = course;
    }

    public bool RemoveCourse(Guid id)
    {
        return _courses.Remove(id);
    }
    
    public CourseCommon? GetCourseById(Guid id)
    {
        return _courses.GetValueOrDefault(id);
    }
    
    public IReadOnlyCollection<CourseCommon> GetAllCourses()
    {
        return _courses.Values.ToList().AsReadOnly();
    }

    // Получить все курсы, которые ведёт преподаватель
    public IReadOnlyCollection<CourseCommon?> GetCoursesByTeacher(Guid teacherId)
    {
        return _courses.Values
            .Where(c => c.Teacher != null && c.Teacher.Id == teacherId)
            .ToList()
            .AsReadOnly();
    }
}