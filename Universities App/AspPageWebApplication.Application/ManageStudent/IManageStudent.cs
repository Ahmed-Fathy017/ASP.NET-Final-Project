using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageStudent
{
    public interface IManageStudent
    {
        StudentDTOList GetStudentsByUniversityId(int universityId);

        StudentDTOList GetStudentBySearchName(string SearchName);

        void AddStudent(StudentDTO student, int universityId);

        void DeleteStudent(int studentId);

        void EditStudent(StudentDTO student);

        StudentDTO GetStudentById(int StudentId);
    }
}
