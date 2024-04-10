using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    // Teacher class, inheriting from Person with teacher-specific properties.
    // Lớp Teacher, kế thừa từ Person với các thuộc tính cụ thể của giáo viên.
    public class Teacher : Person
    {
        public string TeacherId { get; set; }
        public List<Course> CoursesTaught { get; set; } = new List<Course>();

        // Method to create a new teacher.
        // Phương thức để tạo một giáo viên mới.
        public static Teacher CreateNewTeacher(string teacherId, string name)
        {
            return new Teacher
            {
                TeacherId = teacherId,
                Name = name
            };
        }

        // Method to remove a teacher.
        // Phương thức để xóa một giáo viên.
        // Thông tin xóa giáo viên có thể được bổ sung sau.

        // Method to assign a teacher to a course.
        // Phương thức để gán một giáo viên cho một khóa học.
        public void AssignCourse(Course course)
        {
            CoursesTaught.Add(course);
            course.Instructor = this;
            Console.WriteLine($"Assigned to course: {course.CourseName}");
        }

        // Method to remove a teacher from a course.
        // Phương thức để xóa một giáo viên khỏi một khóa học.
        public void RemoveCourse(Course course)
        {
            CoursesTaught.Remove(course);
            Console.WriteLine($"Removed from course: {course.CourseName}");
        }
    }
}
