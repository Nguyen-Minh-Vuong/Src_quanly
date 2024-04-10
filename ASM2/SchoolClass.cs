using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM2
{
    // Represents a class within the school, including the course, teacher, and students.
    // Đại diện cho một lớp học trong trường, bao gồm khóa học, giáo viên và sinh viên.
    public class SchoolClass
    {
        public string ClassId { get; set; }
        public string ClassName { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        // Constructor to initialize SchoolClass with classId, className, course, and teacher.
        // Constructor để khởi tạo SchoolClass với classId, className, course, và teacher.
        public SchoolClass(string classId, string className, Course course, Teacher teacher)
        {
            ClassId = classId;
            ClassName = className;
            Course = course;
            Teacher = teacher;
        }

        // Another constructor to initialize SchoolClass with course and teacher.
        // Constructor khác để khởi tạo SchoolClass với course và teacher.
        public SchoolClass(Course course, Teacher teacher)
        {
            Course = course;
            Teacher = teacher;
        }

        // Method to delete a class based on its ID from a list of SchoolClasses.
        // Phương thức để xóa một lớp học dựa trên ID của nó từ danh sách SchoolClasses.
        public static void DeleteClass(List<SchoolClass> classes)
        {
            Console.Write("Enter Class ID to delete: ");
            string classId = Console.ReadLine();

            SchoolClass classToDelete = classes.FirstOrDefault(c => c.ClassId == classId);
            if (classToDelete != null)
            {
                classes.Remove(classToDelete);
                Console.WriteLine($"Class with ID {classId} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Class with ID {classId} not found.");
            }
        }

        // Method to search classes by name and return a list of matching classes.
        // Phương thức để tìm kiếm các lớp học theo tên và trả về một danh sách các lớp tương ứng.
        public static List<SchoolClass> SearchByName(List<SchoolClass> classes, string className)
        {
            return classes.Where(c => c.ClassName.ToLower().Contains(className.ToLower())).ToList();
        }

        // Method to create a new class.
        // Phương thức để tạo một lớp học mới.
        public static SchoolClass CreateNewClass(string classId, string className, Course course, Teacher teacher)
        {
            return new SchoolClass(classId, className, course, teacher);
        }

        // Method to add a student to the class.
        // Phương thức để thêm một sinh viên vào lớp học.
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        // Method to remove a student from the class.
        // Phương thức để xóa một sinh viên khỏi lớp học.
        public void RemoveStudent(Student student)
        {
            Students.Remove(student);
        }

        // Method to get a formatted string of class details, including the list of students.
        // Phương thức để lấy một chuỗi định dạng về thông tin của lớp học, bao gồm danh sách sinh viên.
        public string GetFormattedClassDetails()
        {
            var studentNames = Students.Select(s => s.Name).ToList();
            return $"Class ID: {ClassId}, Class Name: {ClassName}, Course: {Course.CourseName}, Teacher: {Teacher.Name}, Students: {string.Join(", ", studentNames)}";
        }

        // Method to enroll a student to the class.
        // Phương thức để ghi danh một sinh viên vào lớp học.
        public void EnrollStudent(Student student)
        {
            Students.Add(student);
        }
    }
}
