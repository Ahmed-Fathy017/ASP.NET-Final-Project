using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudent;
using AspPageWebApplication.Application.Universities;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly IManageStudent managestudent;
        private readonly IManageUniversity manageuniversity;

        [BindProperty]
        public StudentDTO Student { get; set; }
        public int UniversityId { get; set; }

        public EditModel(IManageStudent managestudent, IManageUniversity manageuniversity)
        {
            this.managestudent = managestudent;
            this.manageuniversity = manageuniversity;
        }
        public IActionResult OnGet(int ? UniversityId, int StudentId)
        {
            
            if(UniversityId.HasValue)
            {
                var uni = manageuniversity.GetUniversitybyId(UniversityId.Value);

                if(uni != null)
                {
                    this.UniversityId = UniversityId.Value;
                    Student = new StudentDTO();
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Universities/NotFound");
                }
                
            }
            else 
            {
                Student = managestudent.GetStudentById(StudentId);

                if (Student != null)
                {
                    this.UniversityId = Student.UniversityId;
                    return Page();
                }
                else
                {
                    return RedirectToPage("../Universities/NotFound");
                }
            }
            
        }

        public IActionResult OnPost(int UniversityId)
        {
            if (ModelState.IsValid)
            {
                if (this.Student.Id > 0)
                {
                    managestudent.EditStudent(Student);
                }
                else
                {
                    managestudent.AddStudent(Student, UniversityId);
                }

                return RedirectToPage("../Universities/List");
            }
            else 
            { 
                return Page();
            }
            
                
        }
    }
}
