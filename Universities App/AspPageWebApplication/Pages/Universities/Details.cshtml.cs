using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageStudent;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Application.Universities;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace AspPageWebApplication.Pages.Universities
{
    public class DetailsModel : PageModel
    {
        private readonly IManageUniversity manageuniversity;
        private readonly IManageStudent managestudent;

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UniversityId { get; set; }
        public UniversityDTO University { get; set; }
        public StudentDTOList StudentsList { get; set; }

        public DetailsModel(IManageUniversity manageuniversity, IManageStudent managestudent)
        {
            this.manageuniversity = manageuniversity;
            this.managestudent = managestudent;
        }

        public IActionResult OnGet(int UniversityId)
        {
            University = manageuniversity.GetUniversitybyId(UniversityId);

            if(University != null)
            {
                if (SearchName == null)
                {
                    this.UniversityId = UniversityId;
                    StudentsList = managestudent.GetStudentsByUniversityId(UniversityId);
                }
                else
                {
                    StudentsList = managestudent.GetStudentBySearchName(SearchName);
                }
                return Page();
            }
            else
            {
                return RedirectToPage("NotFound");
            }
            
        }


    }
}
