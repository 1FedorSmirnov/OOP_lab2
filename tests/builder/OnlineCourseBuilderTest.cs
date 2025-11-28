// /Users/elena/RiderProjects/Lab2ConsoleApp/builder/OnlineCourseBuilderTest.cs

using Xunit;

namespace Lab2ConsoleApp.tests.builder
{
    public class OnlineCourseBuilderTest
    {
        [Fact]
        public void WithUrl_ShouldSetUrl()
        {
            // Arrange
            var url = "https://example.com";
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.WithUrl(url);

            // Assert
            Assert.Equal(url, builder.Build().Url);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void WithUrl_ShouldThrowArgumentNullException_WhenUrlIsNull()
        {
            // Arrange
            var builder = new OnlineCourseBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.WithUrl(null));
        }

        [Fact]
        public void SetLiveSessions_ShouldSetHasLiveSessionsToTrue()
        {
            // Arrange
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.SetLiveSessions();

            // Assert
            Assert.True(builder.Build().HasLiveSessions);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void SetRecording_ShouldSetHasRecordingToTrue()
        {
            // Arrange
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.SetRecording();

            // Assert
            Assert.True(builder.Build().HasRecording);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void WithId_ShouldSetId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.WithId(id);

            // Assert
            Assert.StrictEqual(id, builder.Build().Id);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void WithTitle_ShouldSetTitle()
        {
            // Arrange
            var title = "Sample Title";
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.WithTitle(title);

            // Assert
            Assert.Equal(title, builder.Build().Title);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void WithTitle_ShouldThrowArgumentNullException_WhenTitleIsNull()
        {
            // Arrange
            var builder = new OnlineCourseBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.WithTitle(null));
        }

        [Fact]
        public void WithTeacher_ShouldSetTeacher()
        {
            // Arrange
            var teacher = new Teacher(Guid.NewGuid(), "John Doe");
            var builder = new OnlineCourseBuilder();

            // Act
            var result = builder.WithTeacher(teacher);

            // Assert
            Assert.StrictEqual(teacher, builder.Build().Teacher);
            Assert.IsType<OnlineCourseBuilder>(result);
        }

        [Fact]
        public void WithTeacher_ShouldThrowArgumentNullException_WhenTeacherIsNull()
        {
            // Arrange
            var builder = new OnlineCourseBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => builder.WithTeacher(null));
        }

        [Fact]
        public void Build_ShouldReturnConstructedOnlineCourse()
        {
            // Arrange
            var id = Guid.NewGuid();
            var title = "Sample Course";
            var url = "https://example.com";
            var teacher = new Teacher(Guid.NewGuid(), "Jane Doe");
            var builder = new OnlineCourseBuilder();

            // Act
            var course = builder
                .WithId(id)
                .WithTitle(title)
                .WithTeacher(teacher)
                .WithUrl(url)
                .SetLiveSessions()
                .SetRecording()
                .Build();

            // Assert
            Assert.StrictEqual(id, course.Id);
            Assert.Equal(title, course.Title);
            Assert.Equal(url, course.Url);
            Assert.StrictEqual(teacher, course.Teacher);
            Assert.True(course.HasLiveSessions);
            Assert.True(course.HasRecording);
        }
    }
}