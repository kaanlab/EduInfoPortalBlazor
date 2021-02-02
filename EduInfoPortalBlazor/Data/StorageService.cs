using EduInfoPortalBlazor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Data
{
    public class StorageService : DbContext
    {
        public StorageService(DbContextOptions<StorageService> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Institution>().Property(e => e.Type).HasConversion<string>();
        }

        #region Cities

        public DbSet<City> Cities { get; set; }

        public IQueryable<City> GetCities() => this.Cities.AsNoTracking().AsQueryable();

        public async Task<City> AddCity(City city)
        {
            EntityEntry<City> cityEntityEntry = await this.Cities.AddAsync(city);
            await this.SaveChangesAsync();
            return cityEntityEntry.Entity;
        }

        public async Task<City> UpdateCity(City city)
        {
            EntityEntry<City> cityEntityEntry = this.Cities.Update(city);
            await this.SaveChangesAsync();
            return cityEntityEntry.Entity;
        }

        public async Task<City> DeleteCity(City city)
        {
            EntityEntry<City> cityEntityEntry = this.Cities.Remove(city);
            await this.SaveChangesAsync();
            return cityEntityEntry.Entity;
        }

        #endregion

        #region Institutions
        public DbSet<Institution> Institutions { get; set; }

        public IQueryable<Institution> GetInstitutions() => this.Institutions.Include(o => o.City).AsNoTracking().AsQueryable();

        public async Task<Institution> AddInstitution(Institution institution)
        {
            var city = await this.Cities.FirstOrDefaultAsync(o => o.Id == institution.City.Id);
            var newInstitution = new Institution()
            {
                Name = institution.Name,
                Address = institution.Address,
                Type = institution.Type
            };
            var addedInstitution = await this.Institutions.AddAsync(newInstitution);
            await this.SaveChangesAsync();

            addedInstitution.Entity.City = city;
            var institutionEntry = this.Institutions.Update(addedInstitution.Entity);
            await this.SaveChangesAsync();

            return institutionEntry.Entity;
        }

        public async Task<Institution> UpdateInstitution(Institution institution)
        {
            var city = await this.Cities.FirstOrDefaultAsync(o => o.Id == institution.City.Id);
            var updatedInstitution = await this.Institutions.FirstOrDefaultAsync(o => o.Id == institution.Id);

            updatedInstitution.Address = institution.Address;
            updatedInstitution.City = city;
            updatedInstitution.Name = institution.Name;
            updatedInstitution.Type = institution.Type;
            var institutionEntry = this.Institutions.Update(updatedInstitution);
            await this.SaveChangesAsync();

            return institutionEntry.Entity;
        }

        public async Task<Institution> DeleteInstitution(Institution institution)
        {
            var deletedInstitution = await this.Institutions.FirstOrDefaultAsync(o => o.Id == institution.Id);
            
            var institutionEntry = this.Institutions.Remove(deletedInstitution);
            await this.SaveChangesAsync();
 
            return institutionEntry.Entity;
        }


        #endregion

    }
}

