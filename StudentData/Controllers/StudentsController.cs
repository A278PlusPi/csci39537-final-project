using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Models;

namespace StudentData.Controllers
{
    [Route("api/studentdata")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentDataDBContext _context;

        public StudentsController(StudentDataDBContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<Response>> GetStudentData()
        {
            var response = new Response();
          if (_context.StudentData == null)
          {
                response.StatusCode = 404;
                response.StatusDescription = "No students found";
                return response;
          }
            response.StatusCode = 200;
            response.StatusDescription = "One or more students found";
            response.GetStudents = await _context.StudentData.ToListAsync();
            return response;
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetStudent(int id)
        {
            var response = new Response();

            if (_context.StudentData == null)
          {
               response.StatusCode = 404;
               response.StatusDescription = "No students found";
               return response;
            }
            var student = await _context.StudentData.FindAsync(id);

            if (student == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Student not found";
                return response;
            }

            response.StatusCode = 200;
            string student_found_msg = "Student " + id + " found";
            response.StatusDescription = student_found_msg;
            response.GetStudents.Add(student);
            return response;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Response> PutStudent(int id, Student student)
        {
            var response = new Response();
            if (id != student.EMPLID)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad request";
                return response;
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Student not found";
                    return response;
                }
                else
                {
                    throw;
                }
            }

            response.StatusCode = 204;
            response.StatusDescription = "Nothing to display";
            return response;
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Response>> PostStudent(Student student)
        {
            var response = new Response();
            if (_context.StudentData == null)
          {
                response.StatusCode = 204;
                response.StatusDescription = "Student data database context is null";
                return response;
          }
            _context.StudentData.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.EMPLID }, student);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if (_context.StudentData == null)
            {
                return NotFound();
            }
            var student = await _context.StudentData.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.StudentData.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.StudentData?.Any(e => e.EMPLID == id)).GetValueOrDefault();
        }
    }
}
