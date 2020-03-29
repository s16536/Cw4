using lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab02.DAL
{
    public class MockDbService : IDbService
    {
        private static List<Student> _students;

        static MockDbService()
        {
            _students = new List<Student>
            {
                new Student { IdStudent = 1, FirstName = " Jan", LastName = "Kowalski"},
                new Student { IdStudent = 2, FirstName = " Anna", LastName = "Malewski"},
                new Student { IdStudent = 3, FirstName = " Andzej", LastName = "Andrzejewicz"}
            };
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudent(id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }

        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.IdStudent == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _students;
        }

        public void UpdateStudent(int id, Student student)
        {
            DeleteStudent(id);
            AddStudent(student);
        }
    }
}
