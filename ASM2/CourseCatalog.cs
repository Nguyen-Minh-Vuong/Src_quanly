using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    public class CourseCatalog
    {
        public List<Course> Courses { get; set; } = new List<Course>();

        // Method to add a new course to the catalog.
        // Phương thức để thêm một khóa học mới vào danh mục khóa học.
        public void AddCourse(Course course)
        {
            Courses.Add(course);
            Console.WriteLine($"Course added: {course.CourseName}");
        }

        // Method to remove a course from the catalog.
        // Phương thức để xóa một khóa học khỏi danh mục.
        public Course RemoveCourse(string courseId)
        {
            var course = Courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                Courses.Remove(course);
                Console.WriteLine($"Course removed: {course.CourseName}");
            }
            return course;
        }

        // Method to search for a course by name.
        // Phương thức để tìm kiếm một khóa học theo tên.
        public Course SearchCourseByName(string name)
        {
            return Courses.FirstOrDefault(c => c.CourseName.ToLower() == name.ToLower());
        }
    }
}
