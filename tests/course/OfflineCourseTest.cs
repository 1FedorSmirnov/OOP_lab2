using Lab2ConsoleApp;
using Xunit;

namespace Lab2ConsoleApp.tests.course;

public class OfflineCourseTest
{
    [Fact]
    public void Constructor_WithParameters_SetsAllFields()
    {
        // Arrange
        var id = Guid.NewGuid();
        string title = "Physics";
        string room = "302";
        int capacity = 50;

        // Act
        var course = new OfflineCourse(id, title, room, capacity);

        // Assert
        Assert.StrictEqual(id, course.Id);
        Assert.Equal(title, course.Title);
        Assert.Equal(room, course.Room);
        Assert.StrictEqual(capacity, course.Capacity);
    }

    [Fact]
    public void GetDescription_ReturnsCorrectFormattedString()
    {
        // Arrange
        var course = new OfflineCourse
        {
            Id = Guid.NewGuid(),
            Title = "Discrete Math",
            Room = "101",
            Capacity = 100
        };

        // Act
        var description = course.GetDescription();

        // Assert
        Assert.Equal("[OFFLINE] Discrete Math in 101 with capacity 100", description);
    }

}