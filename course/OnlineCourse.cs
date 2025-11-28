namespace Lab2ConsoleApp;

public class OnlineCourse : CourseCommon
{
    public OnlineCourse()
    {
    }

    public OnlineCourse(Guid id, string title, string url, bool hasLiveSessions, bool hasRecording)
        : base(id, title)
    {
        Url = url ?? throw new ArgumentNullException(nameof(url));
        HasLiveSessions = hasLiveSessions;
        HasRecording = hasRecording;
    }

    public string Url { get; set; }
    public bool HasLiveSessions { get; set; }
    public bool HasRecording { get; set; }

    public override string GetDescription()
    {
        return $"[ONLINE] {Title} via {Url}, Live: {HasLiveSessions}, Recording: {HasRecording}";
    }
}