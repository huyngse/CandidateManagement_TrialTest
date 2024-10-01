using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject;
using CandidateManagement_Service;

namespace CandidateManagement_NgoGiaHuy.Pages.CandidateProfilePage
{
    public class DetailsModel : PageModel
    {
        private readonly ICandidateProfileService _candidateProfileService;

        public DetailsModel(ICandidateProfileService candidateProfileService)
        {
            _candidateProfileService = candidateProfileService;
        }

      public CandidateProfile CandidateProfile { get; set; } = default!; 

        public IActionResult OnGet(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var candidateprofile = _candidateProfileService.GetCandidateProfile(id);
            if (candidateprofile == null)
            {
                return NotFound();
            }
            else 
            {
                CandidateProfile = candidateprofile;
            }
            return Page();
        }
    }
}
