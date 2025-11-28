using Lab2ConsoleApp;
using Xunit;

namespace Lab2ConsoleApp.tests.course;

public class OnlineCourseTest
{
    [Fact]
    public void Constructor_WithParameters_SetsAllFields()
    {
        // Arrange
        var id = Guid.NewGuid();
        string title = "Physics";
        string url = "https://learn.example.com/physics";
        bool hasLiveSessions = true;
        bool hasRecording = false;

        // Act
        var course = new OnlineCourse(id, title, url, hasLiveSessions, hasRecording);

        // Assert
        Assert.StrictEqual(id, course.Id);
        Assert.Equal(title, course.Title);
        Assert.Equal(url, course.Url);
        Assert.True(hasLiveSessions);
        Assert.False(hasRecording);
    }

    [Fact]
    public void GetDescription_ReturnsCorrectFormattedString()
    {
        // Arrange
        var course = new OnlineCourse
        {
            Id = Guid.NewGuid(),
            Title = "C# for beginners",
            Url = "https://learn.example.com/csharp",
            HasLiveSessions = true,
            HasRecording = false
        };

        // Act
        var description = course.GetDescription();

        // Assert
        Assert.Equal($"[ONLINE] C# for beginners via https://learn.example.com/csharp, Live: True, Recording: False", description);
    }
}