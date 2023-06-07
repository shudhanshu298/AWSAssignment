using Microsoft.EntityFrameworkCore;
using StoreDataInDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreDataInDB.Repository
{
    public class StudentRepository
    {
        private readonly StudentContext _context = null;
        public StudentRepository(StudentContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewStudent(StudentModel model)
        {
            var newStudent = new StudentModel()
            {
                Name = model.Name,
                Branch = model.Branch,
                City = model.City
            };
            await _context.StudentData.AddAsync(newStudent);
            await _context.SaveChangesAsync();
            return newStudent.ID;
        }

        public async Task<List<StudentModel>> GetAllStudent()
        {
            var StudentList = new List<StudentModel>();
            var AllStudents = await _context.StudentData.ToListAsync();

            if (AllStudents?.Any() == true)
            {
                foreach (var student in AllStudents)
                {
                    StudentList.Add(new StudentModel()
                    {
                        Name = student.Name,
                        Branch = student.Branch,
                        City = student.City
                    });
                }
               
            }
            return StudentList;
        }

        public async Task<StudentModel> GetStudentById(int id)
        {
            var Student = await _context.StudentData.FindAsync(id);

            if(Student != null)
            {
                var StudentDetail = new StudentModel()
                {
                    Name = Student.Name,
                    Branch = Student.Branch,
                    City = Student.City
                };
                return StudentDetail;
            }
            return null;
        }
    }
}