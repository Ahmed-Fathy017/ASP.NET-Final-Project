using AspPageWebApplication.Data;
using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspPageWebApplication.Application.ManageStudent
{
    public class ManageStudent : IManageStudent
    {
        private readonly UniversityDbContext context;

        public ManageStudent(UniversityDbContext context)
        {
            this.context = context;
        }

        public void AddStudent(StudentDTO student, int universityId)
        {
            context.Universities.Where(uni => uni.Id == universityId)
                .FirstOrDefault()
                .Students.Add(new Student()
                {
                    Name = student.Name,
                    Grade = student.Grade,
                    UniversityId = student.UniversityId
                });
                context.SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var student = context.Students.Where(st => st.Id == studentId).FirstOrDefault();
            context.Students.Remove(student);
            context.SaveChanges();
        }

        public void EditStudent(StudentDTO student)
        {
            var Student = context.Students.Where(st => st.Id == student.Id).FirstOrDefault();
            Student.Name = student.Name;
            Student.Grade = student.Grade;
            context.SaveChanges();
        }

        public StudentDTO GetStudentById(int StudentId)
        {
            var st = context.Students.Where(st => st.Id == StudentId).FirstOrDefault();
            if (st != null)
            {
                StudentDTO Student = new StudentDTO()
                {
                    Name = st.Name,
                    Grade = st.Grade,
                    Id = st.Id,
                    UniversityId = st.UniversityId
                };
                return Student;
            }
            else return null;
        }

        public StudentDTOList GetStudentBySearchName(string SearchName)
        {
            var stds = context.Students.Where(st => st.Name.Contains(SearchName)).ToList();
            StudentDTOList Students = new StudentDTOList()
            {
                Students = stds.Select(st => new StudentDTO()
                {
                    Id = st.Id,
                    Name = st.Name,
                    Grade = st.Grade,
                    UniversityId = st.UniversityId

                }).ToList()
            };
            return Students;
        }

        public StudentDTOList GetStudentsByUniversityId(int universityId)
        {
            var stds= context.Universities.Where(uni => uni.Id == universityId)
                .Include(uni => uni.Students).FirstOrDefault().Students.ToList();

            StudentDTOList Students = new StudentDTOList()
            {
                Students = stds.Select(st => new StudentDTO()
                {
                    Id = st.Id,
                    Name = st.Name,
                    Grade = st.Grade,
                    UniversityId = st.UniversityId

                }).ToList()
            };
            return Students;
        }
    }
}
