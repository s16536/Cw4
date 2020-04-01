﻿using lab02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab02.DAL
{
    public interface IDbService
    {
        public IEnumerable<Student> GetStudents();
        public Student GetStudent(string id);
        public void AddStudent(Student student);
        public void DeleteStudent(int id);
        public void UpdateStudent(int id, Student student);
    }
}
