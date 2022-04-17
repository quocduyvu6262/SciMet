#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SciMet.Models;
using SciMet.Data;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace SciMet.Pages.Scientists
{
    public class IndexModel : PageModel
    {
        private readonly ScientistContext _context;

        public IndexModel(ScientistContext context)
        {
            _context = context;
        }

        public IList<Scientist> Scientist { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public string SearchResearch { get; set; }

        public async Task OnGetAsync()
        {

            var scientists = from m in _context.Scientist
                 select m;
            if (!string.IsNullOrEmpty(SearchName))
            {
                scientists = scientists.Where(s => s.Name.Contains(SearchName));
            }
            if (!string.IsNullOrEmpty(SearchResearch))
            {
                scientists = scientists.Where(s => s.Research.Contains(SearchResearch));
            }
            Scientist = await scientists.ToListAsync();
        }
    }
}
