using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoomBookX.Data;
using RoomBookX.Models;

namespace RoomBookX.Pages.Reservations
{
    public class IndexModel : PageModel
    {
        private readonly RoomBookX.Data.RoomBookXContext _context;

        public IndexModel(RoomBookX.Data.RoomBookXContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Rooms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? RoomNumber { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> roomQuery = from m in _context.Reservation orderby m.RoomNumber select m.RoomNumber;

            var reservations = from r in _context.Reservation
                               select r;
            if (!string.IsNullOrEmpty(SearchString))
            {
                reservations = reservations.Where(s => s.CustomerSurname.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(RoomNumber))
            {
                reservations = reservations.Where(x => x.RoomNumber == RoomNumber);
            }




            //      DO USUNIĘCIA



            //reservations = reservations.OrderByDescending(r => r.EndTime);


            //reservations = reservations
            //    .OrderByDescending(r => r.StartTime)    // Najpierw rekordy z nullem w EndTime zorderowane po StartTime malejąco
            //    .ThenByDescending(r => r.EndTime);      // Następnie rekordy z EndTime != null zorderowane po EndTime malejąco

            //reservations = reservations
            //    .OrderBy(r => r.EndTime)
            //    .ThenByDescending(r => r.StartTime);      


            //// Najpierw wyświetl rekordy z nullem w EndTime, zorderowane po StartTime malejąco
            //reservations = reservations
            //    .Where(r => r.EndTime == null)
            //    .OrderByDescending(r => r.StartTime)
            //    .Union(
            //        // Następnie wyświetl rekordy z wartością w EndTime, zorderowane po EndTime malejąco
            //        reservations
            //            .Where(r => r.EndTime != null)
            //            .OrderByDescending(r => r.EndTime)
            //    );


            reservations = reservations
            .OrderByDescending(row => row.EndTime == null) // Rekordy z nullem w EndTime są wybierane pierwsze
            .ThenByDescending(row => row.EndTime) // Sortowanie reszty rekordów malejąco względem EndTime
            .ThenByDescending(row => row.StartTime); // Dodatkowe sortowanie malejąco względem StartTime



            Rooms = new SelectList(await roomQuery.Distinct().ToListAsync());

            Reservation = await reservations.ToListAsync();

        }
    }
}
