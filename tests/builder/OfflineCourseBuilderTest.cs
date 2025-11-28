using Lab2ConsoleApp;
using Xunit;

namespace Lab2ConsoleApp.tests.builder;

public class OfflineCourseBuilderTest
{
    [Fact]
    public void InRoom_ShouldSetRoom()
    {
        //Arrange
        var room = "123";
        var builder = new OfflineCourseBuilder(); 
        
        //Act
        var result = builder.InRoom(room);
        
        //Assert
        Assert.Equal(room, builder.Build().Room);
        Assert.IsType<OfflineCourseBuilder>(result);
    }
    
    [Fact]
    public void InRoom_ShouldThrowArgumentNullException_WhenRoomIsNull()
    {
        // Arrange
        var builder = new OfflineCourseBuilder();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.InRoom(null));
    }
    
    [Fact]
    public void WithCapacity_ShouldSetCapacity()
    {
        //Arrange
        var capacity = 50;
        var builder = new OfflineCourseBuilder();
        
        //Act
        var result = builder.WithCapacity(capacity);
        
        //Assert
        Assert.StrictEqual(capacity, builder.Build().Capacity);
        Assert.IsType<OfflineCourseBuilder>(result);
    }
    
    [Fact]
    public void WithId_ShouldSetId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var builder = new OfflineCourseBuilder();

        // Act
        var result = builder.WithId(id);

        // Assert
        Assert.StrictEqual(id, builder.Build().Id);
        Assert.IsType<OfflineCourseBuilder>(result);
    }

    [Fact]
    public void WithTitle_ShouldSetTitle()
    {
        // Arrange
        var title = "Sample Title";
        var builder = new OfflineCourseBuilder();

        // Act
        var result = builder.WithTitle(title);

        // Assert
        Assert.Equal(title, builder.Build().Title);
        Assert.IsType<OfflineCourseBuilder>(result);
    }

    [Fact]
    public void WithTitle_ShouldThrowArgumentNullException_WhenTitleIsNull()
    {
        // Arrange
        var builder = new OfflineCourseBuilder();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.WithTitle(null));
    }

    [Fact]
    public void WithTeacher_ShouldSetTeacher()
    {
        // Arrange
        var teacher = new Teacher(Guid.NewGuid(), "John Doe");
        var builder = new OfflineCourseBuilder();

        // Act
        var result = builder.WithTeacher(teacher);

        // Assert
        Assert.StrictEqual(teacher, builder.Build().Teacher);
        Assert.IsType<OfflineCourseBuilder>(result);
    }

    [Fact]
    public void WithTeacher_ShouldThrowArgumentNullException_WhenTeacherIsNull()
    {
        // Arrange
        var builder = new OfflineCourseBuilder();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => builder.WithTeacher(null));
    }

    [Fact]
    public void Build_ShouldReturnConstructedOfflineCourse()
    {
        //Arrange
        var id = Guid.NewGuid();
        var title = "Test";
        var teacher = new Teacher(Guid.NewGuid(), "Jane Doe");
        var room = "111";
        var capacity = 100;
        var builder = new OfflineCourseBuilder();

        // Act
        var course = builder
            .WithId(id)
            .WithTitle(title)
            .WithTeacher(teacher)
            .InRoom(room)
            .WithCapacity(capacity)
            .Build();

        // Assert
        Assert.StrictEqual(id, course.Id);
        Assert.Equal(title, course.Title);
        Assert.StrictEqual(teacher, course.Teacher);
        Assert.Equal(room, course.Room);
        Assert.StrictEqual(capacity, course.Capacity);
    }
}