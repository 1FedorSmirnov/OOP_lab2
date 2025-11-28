using Lab2ConsoleApp;
using Xunit;

namespace Lab2ConsoleApp.tests;

public class CourseCatalogTest
{
    public CourseCatalogTest()
    {
        CourseCatalog.Instance.Clear();
    }

    [Fact]
    public void AddCourse_ShouldAddCourseToCatalog()
    {
        //Arrange
        var catalog = CourseCatalog.Instance;
        var builder = new OnlineCourseBuilder();
        var id = Guid.NewGuid();
        var title = "Online Course 1";
        var url = "https://learn.example.com/online1";
        var teacherId = Guid.NewGuid();
        var teacher = new Teacher(teacherId, "Jane Doe");
        
        var onlineCourse = builder
            .WithId(id)
            .WithTitle(title)
            .WithUrl(url)
            .WithTeacher(teacher)
            .Build();

        //Act
        catalog.AddCourse(onlineCourse);
        var found = (OnlineCourse)catalog.GetCourseById(id);

        //Assert
        Assert.NotNull(found);
        Assert.StrictEqual(id, found.Id);
        Assert.Equal(url, found.Url);
        Assert.Equal(title, found.Title);
    }
    
    [Fact]
    public void AddCourse_Null_Throws()
    {
        // Arrange
        var catalog = CourseCatalog.Instance;
        
        // Act + Assert
        Assert.Throws<ArgumentNullException>(() => catalog.AddCourse(null));
    }

    [Fact]
    public void GetAllCourses_ShouldReturnAllAddedCourses()
    {
        // Arrange
        var offlineBuilder = new OfflineCourseBuilder();
        var course1 = offlineBuilder
            .WithId(Guid.NewGuid())
            .WithTitle("Course 1")
            .InRoom("800")
            .WithCapacity(100)
            .Build();
        
        var onlineBuilder = new OnlineCourseBuilder();
        var course2 = onlineBuilder
            .WithId(Guid.NewGuid())
            .WithTitle("Course 2")
            .WithUrl("https://learn.example.com/course2")
            .WithTeacher(new Teacher(Guid.NewGuid(), "John Doe"))
            .Build();
        var catalog = CourseCatalog.Instance;
        
        // Act
        catalog.AddCourse(course1);
        catalog.AddCourse(course2);
        var courses = catalog.GetAllCourses();
        
        // Assert
        Assert.StrictEqual(2, courses.Count);
        Assert.Contains(courses, c => c.Id == course1.Id);
        Assert.Contains(courses, c => c.Id == course2.Id);
    }
    
    [Fact]
    public void GetCoursesByTeacher_ReturnsOnlyCoursesOfThatTeacher()
    {
        // Arrange
        var teacherA = new Teacher(Guid.NewGuid(), "Teacher A");
        var teacherB = new Teacher(Guid.NewGuid(), "Teacher B");

        var course1 = new OfflineCourse
        {
            Id = Guid.NewGuid(),
            Title = "Math A",
            Room = "201",
            Capacity = 40,
            Teacher = teacherA
        };

        var course2 = new OfflineCourse
        {
            Id = Guid.NewGuid(),
            Title = "Math B",
            Room = "202",
            Capacity = 30,
            Teacher = teacherB
        };

        var course3 = new OnlineCourse
        {
            Id = Guid.NewGuid(),
            Title = "C# Advanced",
            Url = "https://example.com/csharp-adv",
            HasLiveSessions = true,
            HasRecording = false,
            Teacher = teacherA
        };

        var catalog = CourseCatalog.Instance;
        catalog.AddCourse(course1);
        catalog.AddCourse(course2);
        catalog.AddCourse(course3);

        // Act
        var aCourses = catalog.GetCoursesByTeacher(teacherA.Id);
        var bCourses = catalog.GetCoursesByTeacher(teacherB.Id);

        // Assert
        Assert.StrictEqual(2, aCourses.Count);
        Assert.Single(bCourses);

        Assert.All(aCourses, c => Assert.StrictEqual(teacherA.Id, c.Teacher.Id));
        Assert.All(bCourses, c => Assert.StrictEqual(teacherB.Id, c.Teacher.Id));
    }
    
    [Fact]
    public void RemoveCourse_Existing_ReturnsTrue_DeleteFromCatalog()
    {
        // Arrange
        var teacher = new Teacher(Guid.NewGuid(), "Teacher");
        var course = new OfflineCourse
        {
            Id = Guid.NewGuid(),
            Title = "Test Course",
            Room = "303",
            Capacity = 20,
            Teacher = teacher
        };

        var catalog = CourseCatalog.Instance;
        catalog.AddCourse(course);

        // Act
        var result = catalog.RemoveCourse(course.Id);
        var found = catalog.GetCourseById(course.Id);
        var byTeacher = catalog.GetCoursesByTeacher(teacher.Id);

        // Assert
        Assert.True(result);
        Assert.Null(found);
        Assert.DoesNotContain(byTeacher, c => c.Id == course.Id);
    }

    [Fact]
    public void RemoveCourse_NotExisting_ReturnsFalse()
    {
        // Arrange
        var catalog = CourseCatalog.Instance;
        var id = Guid.NewGuid();

        // Act
        var result = catalog.RemoveCourse(id);

        // Assert
        Assert.False(result);
    }
}