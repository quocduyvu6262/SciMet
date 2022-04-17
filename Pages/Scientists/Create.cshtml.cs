#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SciMet.Models;
using SciMet.Data;

namespace SciMet.Pages.Scientists
{
    public class CreateModel : PageModel
    {
        private readonly ScientistContext _context;

        public CreateModel(ScientistContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Scientist Scientist { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scientist.Add(Scientist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
