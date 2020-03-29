using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lab02.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab02.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public string GetStudent(string orderBy)
        {
            return $"Kowalski, Malewski, Andrzejewski sortowaanie = {orderBy}";
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            if (id == 1)
            {
                return Ok("Kowalski");
            } else if (id ==2 )
            {
                return Ok("Malewski");
            }
            return NotFound("Nie znaleziono studenta"); ;
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            //... add to database
            //... generate index number
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            //... update student
            return Ok("Aktualizacja dokończona");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            //... delete student
            return Ok("Usuwanie ukuńczone");
        }
    }
}