using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.Universities
{
    public interface IManageUniversity
    {
        UniversityDTOList GetUniversities();

        UniversityDTO GetUniversitybyId(int UniversityId);

        UniversityDTOList GetUniversitiesbySearchName(string UniversityName);

        void AddUniversity(UniversityDTO University);

        void DeleteUniversity(int UniversityId);

        void EditUniversity(int universityId, UniversityDTO University);
    }
}
