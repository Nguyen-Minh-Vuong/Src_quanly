using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Teacher Instructor { get; set; }
        public List<Student> StudentsEnrolled { get; set; } = new List<Student>();
        

        // Method to add a student to the course.
        public void AddStudent(Student student)
        {
            StudentsEnrolled.Add(student);
        }

        // Method to remove a student from the course.
        public void RemoveStudent(Student student)
        {
            StudentsEnrolled.Remove(student);
        }
        public List<Teacher> GetTeachers()
        {
            return Instructor != null ? new List<Teacher> { Instructor } : new List<Teacher>();
    
        }

        public string Classroom { get; set; } // Thuộc tính để lưu thông tin về phòng học

        // Phương thức để gán phòng học cho khóa học
        public void AssignClassroom(string classroomName)
        {
            Classroom = classroomName;
        }
    }

}
