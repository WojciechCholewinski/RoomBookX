using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoomBookX.Data;
using RoomBookX.Models;

namespace RoomBookX.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly RoomBookX.Data.RoomBookXContext _context;
        public void OnPageHandlerExecuting()
        {
            var cultureInfo = new CultureInfo("en-US"); // Ustaw kulturę na "en-US"
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
        public CreateModel(RoomBookX.Data.RoomBookXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Reservation == null || Reservation == null)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
