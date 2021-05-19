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
    
    public class ListModel : PageModel
    {
        private readonly IManageUniversity manageUniversity;
        public ListModel(IManageUniversity manageUniversity)
        {
            this.manageUniversity = manageUniversity;
        }

        public List<University> Universities { get; set; }
        public UniversityDTOList UniversityDTOList { get; set; }
        public bool Flag { get; set; } = true;

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }


        public void OnGet()
        {
            if (this.SearchName == null)
            {
                UniversityDTOList = manageUniversity.GetUniversities();
            }
            else 
            {
                UniversityDTOList = manageUniversity.GetUniversitiesbySearchName(this.SearchName);
            }
            
        }
    }
}
