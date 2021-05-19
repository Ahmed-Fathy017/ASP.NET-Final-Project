using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudent;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Students
{
    public class DeleteModel : PageModel
    {
        private readonly IManageStudent managestudent;

        public StudentDTO Student { get; set; }
        public int UniversityId { get; set; }

        public DeleteModel(IManageStudent managestudent)
        {
            this.managestudent = managestudent;
        }
        public IActionResult OnGet(int StudentId)
        {
            Student = managestudent.GetStudentById(StudentId);
            
            if (Student != null)
            {
                UniversityId = Student.UniversityId;
                return Page();
            }
            else
            {
                return RedirectToPage("../Universities/NotFound");
            }
        }

        public IActionResult OnPost(int StudentId)
        {
            managestudent.DeleteStudent(StudentId);
            return RedirectToPage("../Universities/List");
        }
    }
}
