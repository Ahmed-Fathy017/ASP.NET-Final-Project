using System;
using System.Collections.Generic;
using System.Text;

namespace AspPageWebApplication.Application.ManageUniversity
{
    public class UniversityDTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public int StudentCount { get; set; }
    }

    public class UniversityDTOList
    {
        public List<UniversityDTO> Universities { get; set; }
        public int UniversitiesCount { get; set; }

    }
}
