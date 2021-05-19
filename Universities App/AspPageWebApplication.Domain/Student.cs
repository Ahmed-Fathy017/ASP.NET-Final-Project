using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AspPageWebApplication.Domain
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public int Grade { get; set; }
        public int UniversityId { get; set; }
    }
}
