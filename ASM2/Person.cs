using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    // Định nghĩa lớp Person đại diện cho thông tin cá nhân của một người.
    public class Person
    {
        public string Name { get; set; } // Thuộc tính tên của người
        public DateTime Dob { get; set; } // Thuộc tính ngày tháng năm sinh của người
        public string Address { get; set; } // Thuộc tính địa chỉ của người

        // Phương thức để lấy thông tin của người dưới dạng chuỗi được định dạng.
        public string GetDetails()
        {
            return $"Name: {Name}, Date of Birth: {Dob.ToShortDateString()}, Address: {Address}";
        }
    }
}
