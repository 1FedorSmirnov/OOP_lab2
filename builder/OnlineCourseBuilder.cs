namespace Lab2ConsoleApp;

public class OnlineCourseBuilder : CommonCourseBuilder<OnlineCourse, OnlineCourseBuilder>
{
    public OnlineCourseBuilder WithUrl(string url)
    {
        _course.Url = url ?? throw new ArgumentNullException(nameof(url));
        return this;
    }

    public OnlineCourseBuilder SetLiveSessions()
    {
        _course.HasLiveSessions = true;
        return this;
    }

    public OnlineCourseBuilder SetRecording()
    {
        _course.HasRecording = true;
        return this;
    }
    
}