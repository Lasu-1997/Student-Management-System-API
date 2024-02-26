using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Student_Management_System_API.Models;
using Student_Management_System_API.Repository;

namespace Student_Management_System_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;

        public StudentController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await studentRepository.GetAll());
        }
        [HttpGet("id")]
        public async Task<IActionResult> StudentGetById(int id)
        {
            return Ok(await studentRepository.StudentGetById(id));
        }
        [HttpPost]
        [Route("AddStudent")]
        public async Task<IActionResult> Add(Student student)
        {
            var studentObj = await studentRepository.Add(student);
            return Ok(studentObj);
        }
        [HttpPut]
        [Route("UpdateStudent")]
        public async Task<IActionResult> Update(Student student)
        {
            var studentObj = await studentRepository.Update(student);
            return Ok(studentObj);
        }
        [HttpDelete]
        [Route("Delete")]
        public JsonResult Delete(int id)
        {
            studentRepository.Delete(id);
            return new JsonResult("Student deleted successfully!");
        }
    }
}
