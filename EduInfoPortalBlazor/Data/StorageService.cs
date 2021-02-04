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
            modelBuilder.Entity<Faculty>().Property(e => e.Direction).HasConversion<string>();
        }


        #region Cities

        public DbSet<City> Cities { get; set; }

        public IQueryable<City> GetCities() => this.Cities.AsNoTracking().AsQueryable();

        public async Task<City> AddCity(City city)
        {
            var cityEntry = await this.Cities.AddAsync(city);
            await this.SaveChangesAsync();
            return cityEntry.Entity;
        }

        public async Task<City> UpdateCity(City city)
        {
            var updatedCity = await this.Cities.FirstOrDefaultAsync(o => o.Id == city.Id);
            var cityEntry = this.Cities.Update(updatedCity);
            await this.SaveChangesAsync();
            return cityEntry.Entity;
        }

        public async Task<City> DeleteCity(City city)
        {
            var deletedCity = await this.Cities.FirstOrDefaultAsync(o => o.Id == city.Id);
            var cityEntry = this.Cities.Remove(deletedCity);
            await this.SaveChangesAsync();
            return cityEntry.Entity;
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


        #region Exams
        public DbSet<Exam> Exams { get; set; }

        public IQueryable<Exam> GetExams() => this.Exams.AsNoTracking().AsQueryable();

        public async Task<Exam> AddExam(Exam exam)
        {
            var examEntry = await this.Exams.AddAsync(exam);
            await this.SaveChangesAsync();
            return examEntry.Entity;
        }

        public async Task<Exam> UpdateExam(Exam exam)
        {
            var updatedExam = await this.Exams.FirstOrDefaultAsync(o => o.Id == exam.Id);
            var examEntry = this.Exams.Update(updatedExam);
            await this.SaveChangesAsync();
            return examEntry.Entity;
        }

        public async Task<Exam> DeleteExam(Exam exam)
        {
            var deletedExam = await this.Exams.FirstOrDefaultAsync(o => o.Id == exam.Id);
            var examEntry = this.Exams.Remove(deletedExam);
            await this.SaveChangesAsync();
            return examEntry.Entity;
        }

        #endregion


        #region Professions
        public DbSet<Profession> Professions { get; set; }

        public IQueryable<Profession> GetProfessions() => this.Professions.AsNoTracking().AsQueryable();

        public async Task<Profession> AddProfession(Profession profession)
        {
            var professionEntry = await this.Professions.AddAsync(profession);
            await this.SaveChangesAsync();
            return professionEntry.Entity;
        }

        public async Task<Profession> UpdateProfession(Profession profession)
        {
            var updatedProfession = await this.Professions.FirstOrDefaultAsync(o => o.Id == profession.Id);
            var professionEntry = this.Professions.Update(updatedProfession);
            await this.SaveChangesAsync();
            return professionEntry.Entity;
        }

        public async Task<Profession> DeleteProfession(Profession profession)
        {
            var deletedProfession = await this.Professions.FirstOrDefaultAsync(o => o.Id == profession.Id);
            var professionEntry = this.Professions.Remove(deletedProfession);
            await this.SaveChangesAsync();
            return professionEntry.Entity;
        }

        #endregion
    }
}

