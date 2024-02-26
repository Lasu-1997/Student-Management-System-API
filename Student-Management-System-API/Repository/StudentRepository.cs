using Microsoft.EntityFrameworkCore;
using Student_Management_System_API.Models;
using Student_Management_System_API.Services;

namespace Student_Management_System_API.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentManagementDbContext studentManagementDbContext;
        public StudentRepository(StudentManagementDbContext _studentManagementDbContext)
        {
            studentManagementDbContext =  _studentManagementDbContext;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await studentManagementDbContext.Students.ToListAsync();
        }
        public async Task<Student> StudentGetById(int id)
        {
            var student = await studentManagementDbContext.Students.FindAsync(id);
            return student;
        }
        public async Task<Student> Add(Student student)
        {
            studentManagementDbContext.Students.Add(student);
            await studentManagementDbContext.SaveChangesAsync();
            return student;
        }
        public async Task<Student> Update(Student student)
        {
            studentManagementDbContext.Entry(student).State = EntityState.Modified;
            await studentManagementDbContext.SaveChangesAsync();
            return student;
        }
        public bool Delete(int id) 
        {
            var result = false;
            var student = studentManagementDbContext.Students.Find(id);
            if(student != null)
            {
                studentManagementDbContext.Students.Remove(student);
                studentManagementDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
            return result;
        }
    }
}
