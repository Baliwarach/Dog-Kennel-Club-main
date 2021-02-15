using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DogKennel_Project.Models;

namespace DogKennel_Project.Data
{
    public class DogKennel_ProjectContext : DbContext
    {
        public DogKennel_ProjectContext (DbContextOptions<DogKennel_ProjectContext> options)
            : base(options)
        {
        }

        public DbSet<DogKennel_Project.Models.ActivityLevel> ActivityLevel { get; set; }
        public DbSet<DogKennel_Project.Models.DogGroup> DogGroup { get; set; }
        public DbSet<DogKennel_Project.Models.Size> Size { get; set; }
        public DbSet<DogKennel_Project.Models.Breed> Breed { get; set; }
    }
}
