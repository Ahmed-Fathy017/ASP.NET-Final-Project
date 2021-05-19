using AspPageWebApplication.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AspPageWebApplication.Data;
using AspPageWebApplication.Application.ManageUniversity;
using Microsoft.EntityFrameworkCore;

namespace AspPageWebApplication.Application.Universities
{
    public class ManageUniversity : IManageUniversity
    {
        private readonly UniversityDbContext Context;

        public ManageUniversity(UniversityDbContext Context)
        {
            this.Context = Context;
        }

        public void AddUniversity(UniversityDTO university)
        {
            Context.Universities.Add(new University()
            {
                Name = university.Name,
                Address = university.Address
            });
            Context.SaveChanges();
        }

        public void DeleteUniversity(int universityId)
        {
            var uni = Context.Universities.Where(uni => uni.Id == universityId).FirstOrDefault();
            Context.Universities.Remove(uni);
            Context.SaveChanges();
        }

        public void EditUniversity(int universityId, UniversityDTO university)
        {
            var uni = Context.Universities.FirstOrDefault(uni => uni.Id == universityId);
            uni.Name = university.Name;
            uni.Address = university.Address;
            Context.SaveChanges();
        }

        public UniversityDTOList GetUniversities()
        {
            UniversityDTOList Universities = new UniversityDTOList()
            {
                Universities = Context.Universities
                .ToList().Select(uni => new UniversityDTO()
                {
                    Id = uni.Id,
                    Name = uni.Name,
                    Address = uni.Address,
                    StudentCount = Context.Students.Where(st => st.UniversityId == uni.Id)
                    .ToList().Count
                }
                ).ToList(),

                UniversitiesCount = Context.Universities.Count()
            };

            return Universities;

        }

        public UniversityDTO GetUniversitybyId(int universityId)
        {
            var uni = Context.Universities.Where(uni => uni.Id == universityId).FirstOrDefault();

            if (uni != null)
            {
                UniversityDTO university = new UniversityDTO()
                {
                    Name = uni.Name,
                    Address = uni.Address,
                    Id = uni.Id,
                    StudentCount = Context.Students.Where(st => st.UniversityId == uni.Id).Count()
                };
                return university;
            }
            else return null;
                            
        }

        public UniversityDTOList GetUniversitiesbySearchName(string SearchName)
        {
            var unis = Context.Universities.Where(uni => uni.Name.Contains(SearchName)).ToList();

            UniversityDTOList Universities = new UniversityDTOList()
            {
                Universities = unis
                .Select(uni => new UniversityDTO()
                {
                    Id = uni.Id,
                    Name = uni.Name,
                    Address = uni.Address,
                    StudentCount = Context.Students.Where(st => st.UniversityId == uni.Id)
                    .ToList().Count
                }
                ).ToList(),
                UniversitiesCount = unis.Count
            };

            return Universities;
        }
    }
}
