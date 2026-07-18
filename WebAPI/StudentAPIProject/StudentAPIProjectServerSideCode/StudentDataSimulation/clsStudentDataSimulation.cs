using _01StudentAPIProjectv1_GetALL.Model;
namespace _01StudentAPIProjectv1_GetALL.StudentDataSimulation
{
    public class clsStudentDataSimulation
    {
        public static readonly List<Student> StudentList = new List<Student>()
        {
            new Student(){Id=1, Name="John Doe", Age=20, Grade=90},
            new Student(){Id=2, Name="Jane Smith", Age=22, Grade=85},
            new Student(){Id=3, Name="Michael Johnson", Age=19, Grade=92},
            new Student(){Id=4, Name="Emily Davis", Age=21, Grade=88},
            new Student(){Id=5, Name="William Brown", Age=23, Grade=95}
        };
    }
}
