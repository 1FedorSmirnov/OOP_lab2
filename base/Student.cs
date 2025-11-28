namespace Lab2ConsoleApp;

public class Student(Guid id, string fullName)
{
    public Guid Id { get; } = id;
    public string FullName { get; } = fullName ?? throw new ArgumentNullException(nameof(fullName));
}