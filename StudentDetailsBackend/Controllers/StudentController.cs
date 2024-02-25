using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDetailsBackend.Models;

namespace StudentDetailsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext studentDbContext;

        public StudentController(StudentDbContext studentDbContext)
        {
            this.studentDbContext = studentDbContext;
        }

        [HttpGet]
        [Route("GetStudent")]
        public async Task<IEnumerable<Student>> GetStudents()
        {
            var result = await studentDbContext.Student.ToListAsync();
            return result;

        }

        [HttpPost]
        [Route("AddStudent")]
        public async Task<Student> AddStudent(Student student)
        {
            studentDbContext.Student.Add(student);
            await studentDbContext.SaveChangesAsync();
            return student;
        }

        [HttpPatch]
        [Route("UpdateStudent/{id}")]
        public async Task<Student> UpdateStudent(Student student)
        {
            studentDbContext.Entry(student).State = EntityState.Modified;
            await studentDbContext.SaveChangesAsync();
            return student;
        }

        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public bool DeleteStudent(int id)
        {
            bool a = false;
            var stuent = studentDbContext.Student.Find(id);
            if (stuent != null)
            {
                a = true;
                studentDbContext.Entry(stuent).State = EntityState.Deleted;
                studentDbContext.SaveChanges();

            }
            else
            {
                a = false;
            }
            return a;
        }

        [HttpDelete]
        [Route("BulkDeletion")]
        public bool BulkDeletion(List<int> ids)
        {
            bool isSucces = true;
            List<Student> listOfStudents = studentDbContext.Student.Where(x => ids.Any(y => y == x.Id)).ToList();
            listOfStudents.ForEach( x =>
            {
                studentDbContext.Entry(x).State = EntityState.Deleted;
                 studentDbContext.SaveChanges();
            });
            return isSucces;

        }
    }
}
