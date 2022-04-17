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

namespace SciMet.Pages.Scientists
{
    public class DeleteModel : PageModel
    {
        private readonly ScientistContext _context;

        public DeleteModel(ScientistContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Scientist Scientist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scientist = await _context.Scientist.FirstOrDefaultAsync(m => m.ID == id);

            if (Scientist == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scientist = await _context.Scientist.FindAsync(id);

            if (Scientist != null)
            {
                _context.Scientist.Remove(Scientist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
