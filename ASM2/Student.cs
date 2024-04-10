using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    // Student class, inheriting from Person with additional student-specific properties.
    // Lớp Student, kế thừa từ Person với các thuộc tính cụ thể của sinh viên.

    public class Student : Person
    {
        public string StudentId { get; set; }
        public List<Course> EnrolledCourses { get; set; } = new List<Course>();

        // Method to enroll a student in a course.
        // Phương thức để đăng ký một sinh viên vào một khóa học.
        public void EnrollCourse(Course course)
        {
            EnrolledCourses.Add(course);
            course.AddStudent(this);
            Console.WriteLine($"Enrolled in course: {course.CourseName}");
        }

        // Method to drop a course for a student.
        // Phương thức để hủy một khóa học của một sinh viên.
        public void DropCourse(Course course)
        {
            EnrolledCourses.Remove(course);
            course.RemoveStudent(this);
            Console.WriteLine($"Dropped course: {course.CourseName}");
        }

        // Method to create a new student.
        // Phương thức để tạo một sinh viên mới.
        public static Student CreateNewStudent(string studentId, string name)
        {
            return new Student
            {
                StudentId = studentId,
                Name = name,

            };
        }

        // Method to remove a student.
        // Phương thức để xóa một sinh viên.
        public static void RemoveStudent(Student student, List<Student> students)
        {
            students.Remove(student);
            Console.WriteLine($"Removed student: {student.Name}");
        }
    }
}
