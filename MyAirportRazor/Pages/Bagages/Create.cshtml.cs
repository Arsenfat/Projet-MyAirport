using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VJ.MyAirport.EF;

namespace VJ.MyAirport.Razor
{
    public class CreateModel : PageModel
    {
        private readonly VJ.MyAirport.EF.MyAirportContext _context;

        public CreateModel(VJ.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var vols =_context.Vols.Select(v => new
                                                   {
                                                       v.VolId,
                                                       Description = $"{v.Cie} {v.Lig} : {v.Dhc}"
                                                   }).ToList();

            //ViewData["VolId"] = new SelectList(_context.Vols, "VolId", "Description"); //NullReferenceException: Object reference not set to an instance of an object. alors que la liste est bien remplie
            ViewData["VolId"] = new SelectList(_context.Vols, "VolId", "Cie");
            return Page();
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Bagages.Add(Bagage);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
