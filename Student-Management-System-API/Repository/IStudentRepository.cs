using Student_Management_System_API.Models;

namespace Student_Management_System_API.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student> StudentGetById(int id);
        Task<Student> Add(Student student);
        Task<Student> Update(Student student);
        bool Delete(int id);
    }
}
