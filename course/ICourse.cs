namespace Lab2ConsoleApp;

public interface ICourse
{
    void EnrollStudent(Student student);
    void ExpelStudent(Guid studentId);
    void AssignTeacher(Teacher teacher);
    void getAllStudentsInformation();
    void getInformationAboutStudent(Guid studentId);
    string GetDescription();
}