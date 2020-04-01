using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using lab02.DAL;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab02.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private const string CONNECTION_STRING = "Data Source=db-mssql;Initial Catalog=s16536;Integrated Security=True";
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudent(string orderBy)
        {

            var list = new List<Student>();
            using (var connection = new SqlConnection(CONNECTION_STRING))
            using (var command = new SqlCommand())
            {
                command.Connection = connection;
                command.CommandText = "select FirstName, LastName, BirthDate, Semester, Name from Student s left join Enrollment e on s.IdEnrollment = e.IdEnrollment left join Studies studies on e.IdStudy = studies.IdStudy;";
                connection.Open();
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    var student = new Student()
                    {
                        FirstName = dataReader["FirstName"].ToString(),
                        LastName = dataReader["LastName"].ToString(),
                        DateOfBirth = DateTime.Parse(dataReader["BirthDate"].ToString()),
                        Faculty = dataReader["Name"].ToString(),
                        Semester = Int32.Parse(dataReader["Semester"].ToString())
                    };
                    list.Add(student);
                }

            }
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _dbService.GetStudent(id);
            if (student == null)
            {
                return NotFound("Nie znaleziono studenta"); ;
            }
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            _dbService.AddStudent(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            _dbService.UpdateStudent(id, student);
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _dbService.DeleteStudent(id);
            return Ok("Usuwanie ukończone");
        }
    }
}