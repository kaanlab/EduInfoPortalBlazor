using EduInfoPortalBlazor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Data
{
    public class EduInfoDbContext : DbContext
    {
        public EduInfoDbContext(DbContextOptions<EduInfoDbContext> options)
            : base(options)
        {
        }


        // Это наши таблицы в базе данных. Название столбцов берутся из модели.
        public DbSet<Institution> Institutions { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
