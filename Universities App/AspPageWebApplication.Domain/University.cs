using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace AspPageWebApplication.Domain
{
    
    public class University
    {

        public University()
        {
            Students = new List<Student>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        public List<Student> Students { get; set; }
    }
}
