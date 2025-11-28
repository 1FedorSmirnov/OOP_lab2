namespace Lab2ConsoleApp;

public class Teacher(Guid id, string fullName)
{
    public Guid Id { get; } = id;
    public string FullName { get; } = fullName ?? throw new ArgumentNullException(nameof(fullName));
}