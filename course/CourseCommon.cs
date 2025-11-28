using System.Collections.ObjectModel;

namespace Lab2ConsoleApp;

public abstract class CourseCommon : ICourse
{
    private readonly List<Student> _students = [];

    protected CourseCommon(Guid id, string title)
    {
        Id = id;
        Title = title ?? throw new ArgumentNullException(nameof(title));
    }

    protected CourseCommon()
    {
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public Teacher? Teacher { get; set; }

    public void EnrollStudent(Student student)
    {
        ArgumentNullException.ThrowIfNull(student);
        if (_students.Contains(student)) return;
        _students.Add(student);
    }

    public void ExpelStudent(Guid studentId)
    {
        _students.RemoveAll(s => s.Id == studentId);
    }
    
    public ReadOnlyCollection<Student> GetAllStudents()
    {
        return _students.AsReadOnly();
    }

    public void AssignTeacher(Teacher teacher)
    {
        Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
    }

    public void getAllStudentsInformation()
    {
        if (_students.Count == 0) return;
        Console.WriteLine($"All students enrolled in {Title}:");
        foreach (var student in _students)
        {
            Console.WriteLine(student.FullName);
        }
    }

    public void getInformationAboutStudent(Guid studentId)
    {
        var student = _students.FirstOrDefault(s => s.Id == studentId);
        Console.WriteLine(student != null
            ? $"Student {student.FullName} is enrolled in {Title}"
            : $"Student with id {studentId} is not enrolled in {Title}");
    }

    public abstract string GetDescription();
}