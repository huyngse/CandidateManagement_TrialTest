using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CandidateManagement_BusinessObject;

namespace CandidateManagement_NgoGiaHuy.Pages.CandidateProfilePage
{
    public class IndexModel : PageModel
    {
        private readonly CandidateManagement_BusinessObject.CandidateManagementContext _context;

        public IndexModel(CandidateManagementContext context)
        {
            _context = context;
        }

        public IList<CandidateProfile> CandidateProfile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CandidateProfiles != null)
            {
                CandidateProfile = await _context.CandidateProfiles
                .Include(c => c.Posting).ToListAsync();
            }
        }
    }
}
