using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DBFirst
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options)
            : base(options)
        {
        }

        public DbSet<SinhVien> SinhViens { get; set; }
        public DbSet<Lop> Lops { get; set; }
        public DbSet<Khoa> Khoas { get; set; }
    }
}
