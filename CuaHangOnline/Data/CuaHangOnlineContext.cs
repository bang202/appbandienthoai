using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CuaHangOnline.Models;

namespace CuaHangOnline.Data
{
    public class CuaHangOnlineContext : DbContext
    {
        public CuaHangOnlineContext (DbContextOptions<CuaHangOnlineContext> options)
            : base(options)
        {
        }

        public DbSet<CuaHangOnline.Models.User> User { get; set; } = default!;

        public DbSet<CuaHangOnline.Models.Brand>? Brand { get; set; }

        public DbSet<CuaHangOnline.Models.Category>? Category { get; set; }

        public DbSet<CuaHangOnline.Models.Product>? Product { get; set; }
    }
}
