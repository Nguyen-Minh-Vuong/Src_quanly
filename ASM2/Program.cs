using System;
using System.Collections.Generic;
using System.Linq;

namespace ASM2
{
    // Main program class containing the logic for the user interface and interactions.
    internal class Program
    { // Declaration of necessary data structures
        private static CourseCatalog courseCatalog = new CourseCatalog();
        private static List<Student> students = new List<Student>();
        private static List<Teacher> teachers = new List<Teacher>();
        
        static void Main(string[] args)
        {
            //Create a menu that displays options
            InitializeSampleData();
           
            bool exit = false;
            while (!exit)
            { // Displaying the main menu
                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("                                          Student Management System");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("     Menu:");
                Console.WriteLine("     1. Person");
                Console.WriteLine("     2. Course");
                Console.WriteLine("     3. Class");
                Console.WriteLine("     4. View all information");
                Console.WriteLine("     0. Exit");
                Console.Write("     Select an option: ");
                // Handling user input and navigation
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.Clear();
                        PersonMenu();// Navigation to Person menu
                        break;
                    case "2":
                        Console.Clear();
                       CourseMenu(); // Navigation to Course menu
                        break;
                    case "3":
                        Console.Clear();
                     // Navigation to Course menu
                        ClassMenu();
                        break;
                    case "4":
                     ViewAllClasses(); // Navigation to Course menu
                        ViewAllCourses();
                        ViewAllStudents();
                        ViewAllTeachers();
                        break;

                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option, try again.");
                        Console.ResetColor();
                        break;
                }
                if (!exit)
                {
                    Console.WriteLine("\nPress Enter to return to the menu...");
                    Console.ReadLine();
                }
            }
        }
        private static void ClassMenu()
        {   // Handling the Class menu

            Console.WriteLine("     Course Menu:");
            Console.WriteLine("     1. Create Class");
            Console.WriteLine("     2. Delete Class");
            Console.WriteLine("     3. Search Class");
            Console.Write("     Select an option: ");

            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    // Tạo Class
                    ViewAllClasses();
                    CreateNewClass();
                    ViewAllClasses();
                    break;
                case "2":
                    Console.Clear();
                    // Xoas Class
                    ViewAllClasses();
                    DeleteClass();
                    ViewAllClasses();

                    break;
                case "3":
                    Console.Clear();
                    ViewAllClasses();
                    SearchClassByName(); // Searching for a Class by name
                    ViewAllClasses();
                    break;



                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option, try again.");
                    Console.ResetColor();
                    break;
            }

        }
        
        
        // Handling the Course menu
        private static void CourseMenu()
        {
         // Displaying Class menu options
            Console.WriteLine("     Course Menu:");
            Console.WriteLine("     1. Create Course");
            Console.WriteLine("     2. Delete Course");
            Console.WriteLine("     3. Register for courses for students ");
            Console.WriteLine("     4. Cancel student's course registration  ");
            Console.WriteLine("     5. Register for Course for teachers");
            Console.WriteLine("     6. Cancel teacher's course registration");
            Console.Write("     Select an option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                   // Create Course
                   ViewAllCourses();    
                    AddNewCourse();
                    ViewAllCourses();
                    break;
                case "2":
                    Console.Clear();
                  //  Delete Course
                  ViewAllCourses();
                    RemoveCourse();
                    ViewAllCourses();
                    break;
                case "3":
                    Console.Clear();
                    //  Dang ky Course cho student
                    ViewAllStudents();
                    ViewAllClasses();
                    EnrollInCourse();
                    ViewAllCourses();
                    break;
                case "4":
                    Console.Clear();
                    // Huy dang ky Course cua Student
                    ViewAllStudents();
                    ViewAllClasses();
                    DropCourse();
                    ViewAllCourses();
                    break;
                case "5":
                    Console.Clear();
                    // Dang ky Course cho teacher
                    ViewAllTeachers();
                    ViewAllCourses();

                    AssignTeacherToCourse();
                        ViewAllCourses();
                    break;
                case "6":
                    Console.Clear();
                    // Huy dang ky Course cua teacher
                    ViewAllTeachers();
                    ViewAllCourses();
                    RemoveTeacherFromCourse();
                       
                    break;
                case "7":
                    Console.Clear();
                    // Tạo teacher
                   
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option, try again.");
                    Console.ResetColor();
                    break;
            }

        }
        // Handling the menu related to creating persons (students and teachers)
        private static void PersonMenu()
        {
            // Displaying the options for creating a student or a teacher
            Console.WriteLine("     Person Menu:");
            Console.WriteLine("     1. Create student");
            Console.WriteLine("     2. Create teacher");
            Console.WriteLine("     3. Delete teacher");
            Console.WriteLine("     4. Delete teacher");
            Console.Write("     Select an option: ");

            // Getting user input for the selected option
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Clear();
                    // Navigating to create a student
                    ViewAllStudents();
                    CreateStudent();
                    ViewAllStudents();
                    break;
                case "2":
                    Console.Clear();
                    // Navigating to create a teacher
                    ViewAllTeachers();
                    CreateTeacher();
                    ViewAllTeachers();
                    break;
                case "3":
                    Console.Clear();
                    // Navigating to create a teacher
                    ViewAllStudents();
                    DeleteStudent();
                    ViewAllStudents();
                    break;
                case "4":
                    Console.Clear();
                    // Navigating to create a teacher
                    ViewAllTeachers();
                    DeleteTeacher();
                    ViewAllTeachers();
                    break;
                default:
                    // Handling invalid options
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option, try again.");
                    Console.ResetColor();
                    break;
            }
        }
        private static void DeleteStudent()
        {
            Console.WriteLine("Deleting a student...");
            Console.Write("Enter student ID to delete: ");
            string studentIdToDelete = Console.ReadLine();

            // Tìm sinh viên theo ID
            Student studentToDelete = students.FirstOrDefault(student => student.StudentId == studentIdToDelete);

            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
                Console.WriteLine($"Student {studentToDelete.Name} with ID {studentToDelete.StudentId} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Student with ID {studentIdToDelete} not found.");
            }
        }

        // Phương thức để xóa giáo viên
        private static void DeleteTeacher()
        {
            Console.WriteLine("Deleting a teacher...");
            Console.Write("Enter teacher ID to delete: ");
            string teacherIdToDelete = Console.ReadLine();

            // Tìm giáo viên theo ID
            Teacher teacherToDelete = teachers.FirstOrDefault(teacher => teacher.TeacherId == teacherIdToDelete);

            if (teacherToDelete != null)
            {
                teachers.Remove(teacherToDelete);
                Console.WriteLine($"Teacher {teacherToDelete.Name} with ID {teacherToDelete.TeacherId} has been deleted.");
            }
            else
            {
                Console.WriteLine($"Teacher with ID {teacherIdToDelete} not found.");
            }
        }
        // Handling the creation of a new teacher
        private static void CreateTeacher()
        {
            // Prompting the user to input details for a new teacher
            Console.WriteLine("Creating a new teacher...");
            Console.Write("Enter teacher ID: ");
            string teacherId = Console.ReadLine();

            Console.Write("Enter teacher name: ");
            string name = Console.ReadLine();

            // Creating a new teacher instance using the provided details
            Teacher newTeacher = Teacher.CreateNewTeacher(teacherId, name);

            // Adding the new teacher to the list of teachers
            teachers.Add(newTeacher);

            // Displaying a success message after adding the teacher
            Console.WriteLine($"Teacher {newTeacher.Name} with ID {newTeacher.TeacherId} added successfully!");
        }


        // Handling the creation of a new student
        private static void CreateStudent()
        {
            // Prompting the user to input details for a new student
            Console.WriteLine("Creating a new student...");

            // Nhập thông tin sinh viên từ người dùng
            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();

            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            // Tạo một sinh viên mới
            Student newStudent = Student.CreateNewStudent(studentId, name);

            // Thêm sinh viên mới vào danh sách sinh viên
            students.Add(newStudent);

            // Hiển thị thông báo khi sinh viên được tạo thành công
            Console.WriteLine($"Student {name} created successfully.");
        }

        // Enrolling a student in a course
        private static void EnrollInCourse()
        {
            // (Hiển thị thông tin sinh viên và khóa học giống như trước)

            // Nhập ID sinh viên và ID khóa học từ người dùng.
            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();
            Console.Write("Enter course ID: ");
            string courseId = Console.ReadLine();

            // Tìm sinh viên và khóa học đã chọn.
            var selectedStudent = students.FirstOrDefault(s => s.StudentId == studentId);
            var course = courseCatalog.Courses.FirstOrDefault(c => c.CourseId == courseId);

            // Nếu tìm thấy sinh viên và khóa học.
            if (selectedStudent != null && course != null)
            {
                // Tìm lớp học liên quan đến khóa học.
                var relatedClass = schoolClasses.FirstOrDefault(sc => sc.Course.CourseId == courseId);

                // Nếu lớp học tồn tại.
                if (relatedClass != null)
                {
                    // Ghi danh sinh viên vào khóa học và lớp học.
                    selectedStudent.EnrollCourse(course);
                    relatedClass.EnrollStudent(selectedStudent);

                    // Hiển thị thông báo xác nhận việc ghi danh của sinh viên.
                    Console.WriteLine($"{selectedStudent.Name} has been enrolled in {course.CourseName} (Course ID: {course.CourseId}) and associated with {relatedClass.ClassName} (Class ID: {relatedClass.ClassId})");
                }
                else
                {
                    Console.WriteLine("Class not found for the course.");
                }
            }
            else
            {
                Console.WriteLine("Student or Course not found.");
            }
        }

        // Method to view all classes.
        private static void ViewAllClasses()
        {
            // Hiển thị danh sách các lớp học
            Console.WriteLine("\nList of All Classes:");
            // Định dạng tiêu đề cho bảng thông tin lớp học
            Console.WriteLine("  -----------------------------------------------------------------------------------------------");
            Console.WriteLine("  | Class ID |   Class Name  |     Teacher ID    |     Teacher       |   Course ID |  Course Name  |    Students     |");
            Console.WriteLine("  -----------------------------------------------------------------------------------------------");

            // Duyệt qua từng lớp học trong danh sách và hiển thị thông tin chi tiết của từng lớp học
            foreach (var schoolClass in schoolClasses)
            {
                // Hiển thị thông tin của từng lớp học trong bảng
                Console.WriteLine($"  | {schoolClass.ClassId,-9} | {schoolClass.ClassName,-14} | {schoolClass.Teacher.TeacherId,-18} | {schoolClass.Teacher.Name,-17} | {schoolClass.Course.CourseId,-11} | {schoolClass.Course.CourseName,-14} | {GetStudentNames(schoolClass.Students)} |");
            }

            // Kết thúc bảng thông tin lớp học
            Console.WriteLine("-----------------------------------------------------------------------------------------------");
        }



        // Method to get names of students
        private static string GetStudentNames(List<Student> students)
        {
            // Nếu danh sách sinh viên trống, trả về thông báo "No students"
            if (students.Count == 0)
                return "No students";

            // Nếu danh sách sinh viên không trống, trả về một chuỗi gồm tên của các sinh viên, được ngăn cách bởi dấu phẩy và khoảng trắng
            return string.Join(", ", students.Select(s => s.Name));
        }

        // Method to drop a student from a course
        private static void DropCourse()
        {
            // Lấy thông tin ID sinh viên và ID khóa học từ người dùng.
            Console.Write("Enter student ID: ");
            string studentId = Console.ReadLine();
            Console.Write("Enter course ID: ");
            string courseId = Console.ReadLine();

            // Tìm sinh viên và khóa học đã chọn.
            Student student = students.FirstOrDefault(s => s.StudentId == studentId);
            Course course = courseCatalog.Courses.FirstOrDefault(c => c.CourseId == courseId);

            // Loại bỏ sinh viên khỏi khóa học nếu cả hai đều được tìm thấy.
            if (student != null && course != null)
            {
                student.DropCourse(course);
            }
            else
            {
                Console.WriteLine("Student or Course not found.");
            }
        }


        // Method to remove a course from the catalog
        private static void RemoveCourse()
        {  
            // Nhận ID khóa học từ người dùng.
            Console.Write("Enter course ID to remove: ");
            string courseId = Console.ReadLine();

            // Loại bỏ khóa học nếu được tìm thấy.
            Course course = courseCatalog.RemoveCourse(courseId);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
            }
        }


        // Method to assign a teacher to a course.
        private static void AssignTeacherToCourse()
        {
            // Getting teacher ID and course ID input from user.
            Console.Write("Enter teacher ID: ");
            string teacherId = Console.ReadLine();
            Console.Write("Enter course ID: ");
            string courseId = Console.ReadLine();

            // Finding the selected teacher and course.
            Teacher teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId);
            Course course = courseCatalog.Courses.FirstOrDefault(c => c.CourseId == courseId);

            // Assigning the teacher to the course if both are found.
            if (teacher != null && course != null)
            {
                teacher.AssignCourse(course);
            }
            else
            {
                Console.WriteLine("Teacher or Course not found.");
            }
        }

        // Method to remove a teacher from a course
        private static void RemoveTeacherFromCourse()
        {
            // Nhận ID giáo viên và ID khóa học từ người dùng.
            Console.Write("Enter teacher ID: ");
            string teacherId = Console.ReadLine();
            Console.Write("Enter course ID: ");
            string courseId = Console.ReadLine();

            // Tìm giáo viên đã chọn.
            Teacher teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId);

            if (teacher != null)
            {
                // Tìm khóa học đã chọn trong danh sách khóa học mà giáo viên dạy.
                Course course = teacher.CoursesTaught.FirstOrDefault(c => c.CourseId == courseId);

                if (course != null)
                {
                    // Loại bỏ giáo viên khỏi khóa học.
                    teacher.RemoveCourse(course);
                    Console.WriteLine($"Teacher {teacher.Name} has been removed from Course {course.CourseName}.");
                }
                else
                {
                    Console.WriteLine("Course not found.");
                }
            }
            else
            {
                Console.WriteLine("Teacher not found.");
            }
        }


        // Method to initialize sample data for demonstration.
        private static void InitializeSampleData()
        {
            // Adding sample data to the system.
            var mathCourse = new Course { CourseId = "C1", CourseName = "Toan 1" };
            courseCatalog.AddCourse(mathCourse);

            var Ly = new Course { CourseId = "C2", CourseName = "Ly 1" };
            courseCatalog.AddCourse(Ly);

            var Toancaocap = new Course { CourseId = "C3", CourseName = "Toan Cao Cap" };
            courseCatalog.AddCourse(Toancaocap);

            var Laptrinh = new Course { CourseId = "C4", CourseName = "Lap trinh cap 1" };
            courseCatalog.AddCourse(Laptrinh);

            var Laptrinhpro = new Course { CourseId = "C5", CourseName = "Lap trinh PRO" };
            courseCatalog.AddCourse(Laptrinhpro);

            //  students are added as examples
            var Nam = new Student { Name = "Nam Nguyen", StudentId = "S1" };
            students.Add(Nam);
            var Vuong = new Student { Name = "Vuong Nguyen", StudentId = "S2" };
            students.Add(Vuong);
            var Hoa = new Student { Name = "Hoa Le", StudentId = "S3" };
            students.Add(Hoa);
            var Tung = new Student { Name = "Tung Lam", StudentId = "S4" };
            students.Add(Tung);
            var Tien = new Student { Name = "Tien Nguyen", StudentId = "S5" };
            students.Add(Tien);

            //  Teachers are added as examples
            var Thao = new Teacher { Name = "Thanh Thao", TeacherId = "T1" };
            teachers.Add(Thao);
            var Khanh = new Teacher { Name = "Khanh Smith", TeacherId = "T2" };
            teachers.Add(Khanh);
            var Liem = new Teacher { Name = "Liem Le", TeacherId = "T3" };
            teachers.Add(Liem);
            var Giang = new Teacher { Name = "Giang Nguyen", TeacherId = "T4" };
            teachers.Add(Giang);
            var Bao = new Teacher { Name = "Bao Tran", TeacherId = "T5" };
            teachers.Add(Bao);


            //  Classes are added as examples
            var ToanClass = new SchoolClass("CL1", "Phong 101", mathCourse, Thao);
            schoolClasses.Add(ToanClass);

            var LyClass = new SchoolClass("CL2", "Phong 201", Ly, Khanh);
            schoolClasses.Add(LyClass);

            var ToancaocapClass = new SchoolClass("CL3", "Phong 301 ", Toancaocap, Liem);
            schoolClasses.Add(ToancaocapClass);

            var LaptrinhClass = new SchoolClass("CL4", "Phong 401", Laptrinh, Giang);
            schoolClasses.Add(LaptrinhClass);

            var LaptrinhproClass = new SchoolClass("CL5", "Phong 501", Laptrinhpro, Giang);
            schoolClasses.Add(LaptrinhproClass);

            var CongngheClass = new SchoolClass("CL6", "Phong 601", mathCourse, Giang); // This line should refer to a different course
            schoolClasses.Add(CongngheClass);
        }

        // Method to add a new course to the course catalog.
        private static void AddNewCourse()
        {
            // Display the current list of courses in the catalog.
           // Console.WriteLine("\nCurrent List of Courses:");
           // foreach (var course in courseCatalog.Courses)
           // {
           //     Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}");
           // }

            // Prompt the user to input information for the new course.
            Console.Write("Enter new course ID: ");
            var courseId = Console.ReadLine();
            Console.Write("Enter new course name: ");
            var courseName = Console.ReadLine();

            // Create a new Course object based on the user input.
            var newCourse = new Course { CourseId = courseId, CourseName = courseName };

            // Add the new course to the course catalog.
            courseCatalog.AddCourse(newCourse);

            // Confirm the addition of the new course to the user.
            Console.WriteLine($"New course added: {courseName} (ID: {courseId})");
        }

        // Method to display information about all courses in the course catalog.
        private static void ViewAllCourses()
        {
            // Display the header for the table of courses.
            Console.WriteLine("     \nList of All Courses:");
            Console.WriteLine("     --------------------------------------------------------------------------------------------");
            Console.WriteLine("     | Course ID     |       Course Name       |  Teacher               |      Students           |");
            Console.WriteLine("     --------------------------------------------------------------------------------------------");

            // Loop through each course in the catalog and display its information.
            foreach (var course in courseCatalog.Courses)
            {
                Console.Write($"        | {course.CourseId,-13} | {course.CourseName,-23} | ");

                // Retrieve teachers assigned to the course.
                var teachers = course.GetTeachers();
                if (teachers.Any())
                {
                    foreach (var teacher in teachers)
                    {
                        Console.Write($"{teacher.Name}, ");
                    }
                }
                else
                {
                    Console.Write("No assigned teacher");
                }

                Console.Write(" | ");

                // Retrieve students enrolled in the course.
                var students = course.StudentsEnrolled;
                if (students.Any())
                {
                    foreach (var student in students)
                    {
                        Console.Write($"{student.Name}, ");
                    }
                }
                else
                {
                    Console.Write("No enrolled students");
                }

                Console.WriteLine();
            }

            // Display the footer for the table of courses.
            Console.WriteLine("--------------------------------------------------------------------------------------------");
        }


        private static List<SchoolClass> schoolClasses = new List<SchoolClass>();

        // Displays a table listing all teachers with their respective IDs and names.
        private static void ViewAllTeachers()
        {
            // Prints the header of the table.
            Console.WriteLine("\nList of All Teachers:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| Teacher ID |     Name                            |");
            Console.WriteLine("------------------------------------------------------");

            // Iterates through the 'teachers' list and prints each teacher's details.
            foreach (var teacher in teachers)
            {
                Console.WriteLine($"| {teacher.TeacherId,-11} | {teacher.Name,-30}     |");
            }

            // Prints the footer of the table.
            Console.WriteLine("------------------------------------------------------");
        }

        // Creates a new class based on user input for class ID, name, course ID, and teacher ID.
        private static void CreateNewClass()
        {
            Console.Write("Enter class ID: ");
            string classId = Console.ReadLine();
            Console.Write("Enter class name: ");
            string className = Console.ReadLine();
            Console.Write("Enter course ID: ");
            string courseId = Console.ReadLine();
            Console.Write("Enter teacher ID: ");
            string teacherId = Console.ReadLine();

            // Find the course and teacher based on the provided IDs.
            Course course = courseCatalog.Courses.FirstOrDefault(c => c.CourseId == courseId);
            Teacher teacher = teachers.FirstOrDefault(t => t.TeacherId == teacherId);

            if (course != null && teacher != null)
            {
                // Create a new SchoolClass object and add it to the list of classes.
                var newClass = new SchoolClass(classId, className, course, teacher);
                schoolClasses.Add(newClass);
                Console.WriteLine($"New class created: {className}");
            }
            else
            {
                Console.WriteLine("Course or Teacher not found.");
            }
        }

        // Deletes a class based on the provided class ID.
        private static void DeleteClass()
        {
            Console.Write("Enter Class ID to delete: ");
            string classIdToDelete = Console.ReadLine();

            // Find the class to delete based on the provided class ID.
            SchoolClass classToDelete = schoolClasses.FirstOrDefault(c => c.ClassId == classIdToDelete);

            if (classToDelete != null)
            {
                // Remove the found class from the list of classes.
                schoolClasses.Remove(classToDelete);
                Console.WriteLine($"Class with ID {classIdToDelete} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Class with ID {classIdToDelete} not found.");
            }
        }
        //Find classes by name
        private static void SearchClassByName()
        {
            Console.Write("Enter class name to search: ");
            string className = Console.ReadLine();

            // Find classes whose names contain the provided class name (case insensitive).
            var foundClasses = schoolClasses.Where(c => c.ClassName.ToLower().Contains(className.ToLower())).ToList();

            if (foundClasses.Any())
            {
                Console.WriteLine("\nFound Classes:");
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("| Class ID |     Class Name          |     Course     |");
                Console.WriteLine("------------------------------------------------------");

                foreach (var foundClass in foundClasses)
                {
                    Console.WriteLine($"| {foundClass.ClassId,-9} | {foundClass.ClassName,-23} | {foundClass.Course.CourseName,-14} |");
                }

                Console.WriteLine("------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("No classes found with that name.");
            }
        }

        //View information about students
        private static void ViewAllStudents()
        {
            Console.WriteLine("\nList of All Students:");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("| Student ID |     Name                            |");
            Console.WriteLine("------------------------------------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"| {student.StudentId,-10} | {student.Name,-30}      |");
            }

            Console.WriteLine("------------------------------------------------------");
        }



    }
}
