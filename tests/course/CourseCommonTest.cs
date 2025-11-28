using Lab2ConsoleApp;
using Xunit;

namespace Lab2ConsoleApp.tests.course;

public class CourseCommonTest
{
       [Fact]
        public void AssignTeacher_SetsTeacher()
        {
            // Arrange
            var course = new OfflineCourse();
            var teacher = new Teacher(Guid.NewGuid(), "John Smith");

            // Act
            course.AssignTeacher(teacher);

            // Assert
            Assert.StrictEqual(teacher, course.Teacher);
        }
        
        [Fact]
        public void EnrollStudent_AddsStudent()
        {
            // Arrange
            var course = new OfflineCourse();
            var alice = new Student(Guid.NewGuid(), "Alice");
        
            // Act
            course.EnrollStudent(alice);
            var courseStudents = course.GetAllStudents();
        
            // Assert
            Assert.Contains(alice, courseStudents);
        }

        [Fact]
        public void EnrollStudent_DoesNotAddDuplicate()
        {
            // Arrange
            var course = new OfflineCourse();
            var bob = new Student(Guid.NewGuid(), "Bob");
        
            // Act
            course.EnrollStudent(bob);
            course.EnrollStudent(bob); // второе добавление
        
            var courseStudents = course.GetAllStudents();
        
            // Assert
            Assert.Contains(bob, courseStudents);
            Assert.StrictEqual(1, courseStudents.Count);
        }

        [Fact]
        public void ExpelStudent_RemovesStudent()
        {
            // Arrange
            var course = new OfflineCourse();
            var bob = new Student(Guid.NewGuid(), "Bob");
        
            course.EnrollStudent(bob);
        
            // Act
            course.ExpelStudent(bob.Id);
            var courseStudents = course.GetAllStudents();
        
            // Assert
            Assert.DoesNotContain(bob, courseStudents);
            Assert.Empty(courseStudents);
        }
    
}