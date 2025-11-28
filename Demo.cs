namespace Lab2ConsoleApp;

public class Demo
{
    public static void RunDemo()
    {
        // создаём преподавателей
        var teacherAlice = new Teacher(Guid.NewGuid(), "Alice Smith");
        var teacherBob = new Teacher(Guid.NewGuid(), "Bob Johnson");
        var OnlineCourseBuilder = new OnlineCourseBuilder();

        // создаём курсы через билдеры
        var csharpCourse = OnlineCourseBuilder
            .WithTitle("C# for beginners")
            .WithUrl("https://learn.example.com/csharp")
            .SetLiveSessions()
            .WithTeacher(teacherAlice)
            .Build();

        var mathCourse = new OfflineCourseBuilder()
            .WithTitle("Linear Algebra")
            .InRoom("305")
            .WithCapacity(60)
            .WithTeacher(teacherBob)
            .Build();

        // добавим курсы в систему
        var catalog = CourseCatalog.Instance;
        catalog.AddCourse(csharpCourse);
        catalog.AddCourse(mathCourse);

        // добавим студентов
        var s1 = new Student(Guid.NewGuid(), "Jane Doe");
        var s2 = new Student(Guid.NewGuid(), "John Doe");

        csharpCourse.EnrollStudent(s1);
        csharpCourse.EnrollStudent(s2);

        mathCourse.EnrollStudent(s1);

        // получим курсы, которые ведёт Bob
        var bobCourses = catalog.GetCoursesByTeacher(teacherBob.Id);
        foreach (var course in bobCourses)
            Console.WriteLine($"{teacherBob.FullName} teaches: {course.GetDescription()}");

        // получим студентов курса C#
        csharpCourse.getAllStudentsInformation();
    }
}