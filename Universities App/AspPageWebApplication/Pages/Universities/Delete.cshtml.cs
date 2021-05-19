using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspPageWebApplication.Application.ManageUniversity;
using AspPageWebApplication.Application.Universities;
using AspPageWebApplication.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspPageWebApplication.Pages.Universities
{
    public class DeleteModel : PageModel
    {

        private readonly IManageUniversity manageuniversity;
        public UniversityDTO University { get; set; }

        public DeleteModel(IManageUniversity manageuniversity)
        {
            this.manageuniversity = manageuniversity;
        }

        public IActionResult OnGet(int UniversityId)
        {
            University = manageuniversity.GetUniversitybyId(UniversityId);

            if (University != null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("NotFound");
            }
        }

        public IActionResult OnPost(int UniversityId)
        {
            manageuniversity.DeleteUniversity(UniversityId);
            return RedirectToPage("List");
        }
        

    }
}
