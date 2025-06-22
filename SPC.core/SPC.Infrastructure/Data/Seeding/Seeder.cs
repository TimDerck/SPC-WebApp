using Microsoft.EntityFrameworkCore;
using SPC.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPC.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var Site1Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e");
            var Site2Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7");

            modelBuilder.Entity<Site>().HasData(
                new Site { Id = Site1Id, Name = "Main Lab" },
                new Site { Id = Site2Id, Name = "QC Lab" }
            );
            modelBuilder.Entity<MeasurementType>().HasData(
                new MeasurementType { Id = Guid.Parse("0f8fad5b-d9cb-469f-a165-70867728950e"), TypeName = "pH", Description = "Acidity", Unit = "pH", HasCalculatedResult = false },
                new MeasurementType { Id = Guid.Parse("7c9e6679-7425-40de-944b-e07fc1f90ae7"), TypeName = "Viscosity", Description = "Flow resistance", Unit = "mPa·s", HasCalculatedResult = true }
            );
        }

    }
}
