using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Application.Universities;
using AspPageWebApplication.Data;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace AspPageWebApplication.Pages.Universities
{
    public class EditModel : PageModel
    {
        private readonly IManageUniversity manageuniversity;
        private readonly UniversityDbContext Context;

        [BindProperty]
        public UniversityDTO University { get; set; }

        public EditModel(IManageUniversity manageuniversity, UniversityDbContext Context)
        {
            this.manageuniversity = manageuniversity;
            this.Context = Context;
        }

        public IActionResult OnGet(int ? UniversityId)
        {

            if(!UniversityId.HasValue)
            {
                University = new UniversityDTO();
                return Page();
            }
            else
            {
                University = manageuniversity.GetUniversitybyId(UniversityId.Value);
                if (University != null)
                {
                    return Page();
                }
                else
                {
                    return RedirectToPage("NotFound");
                }
                
            }
 
        }

        public IActionResult OnPost(UniversityDTO University, int UniversityId)
        {
            if(ModelState.IsValid)
            {
                if (this.University.Id > 0)
                {
                    manageuniversity.EditUniversity(UniversityId, University);
                }
                else
                {
                    manageuniversity.AddUniversity(University);
                }
                return RedirectToPage("List");
            }
            else
            {
                return Page();
            }
        }
    }
}
