#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SciMet.Models;
using SciMet.Data;

namespace SciMet.Pages.Scientists
{
    public class EditModel : PageModel
    {
        private readonly ScientistContext _context;

        public EditModel(ScientistContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Scientist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScientistExists(Scientist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScientistExists(int id)
        {
            return _context.Scientist.Any(e => e.ID == id);
        }
    }
}
