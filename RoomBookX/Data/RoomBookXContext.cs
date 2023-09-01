using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RoomBookX.Models;

namespace RoomBookX.Data
{
    public class RoomBookXContext : DbContext
    {
        public RoomBookXContext (DbContextOptions<RoomBookXContext> options)
            : base(options)
        {
        }

        public DbSet<RoomBookX.Models.Reservation> Reservation { get; set; } = default!;
    }
}
