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
            var newInstitution = new Institution()
            {
                Name = institution.Name,
                Address = institution.Address,
                Type = institution.Type                
            };
            var addedInstitution = await this.Institutions.AddAsync(newInstitution);
            await this.SaveChangesAsync();

            var city = await this.Cities.FirstOrDefaultAsync(o => o.Id == institution.City.Id);
            addedInstitution.Entity.City = city;
            var faculties = await this.Faculties.Where();
            addedInstitution.Entity.Faculties = faculties;
            var institutionEntry = this.Institutions.Update(addedInstitution.Entity);
            await this.SaveChangesAsync();

            return institutionEntry.Entity;
        }

        public async Task<Institution> UpdateInstitution(Institution institution)
        {            
            var updatedInstitution = await this.Institutions.FirstOrDefaultAsync(o => o.Id == institution.Id);

            updatedInstitution.Address = institution.Address;

            var city = await this.Cities.FirstOrDefaultAsync(o => o.Id == institution.City.Id);
            updatedInstitution.City = city;
            updatedInstitution.Name = institution.Name;
            updatedInstitution.Type = institution.Type;
            var faculties = await this.Faculties.Where();
            updatedInstitution.Faculties = faculties;
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


        #region Specialities
        public DbSet<Specialty> Specialties { get; set; }

        public IQueryable<Specialty> GetSpecialties() => this.Specialties.Include(o => o.Exams).Include(o => o.Professions).AsNoTracking().AsQueryable();

        public async Task<Specialty> AddSpecialty(Specialty specialty)
        {
            var newSpeciality = new Specialty()
            {
                Code = specialty.Code,
                Profile = specialty.Profile,
                BudgetPlaces = specialty.BudgetPlaces,
                BudgetMinScore = specialty.BudgetMinScore,
                PaidPlaces = specialty.PaidPlaces,
                PaidMinScore = specialty.PaidMinScore
            };
            var addedSpeciality = await this.Specialties.AddAsync(newSpeciality);
            await this.SaveChangesAsync();

            addedSpeciality.Entity.Exams = specialty.Exams;
            addedSpeciality.Entity.Professions = specialty.Professions;

            var specialityEntry = this.Specialties.Update(addedSpeciality.Entity);
            await this.SaveChangesAsync();
            return specialityEntry.Entity;
        }

        public async Task<Specialty> UpdateSpecialty(Specialty specialty)
        {
            var updatedSpeciality = await this.Specialties.FirstOrDefaultAsync(o => o.Id == specialty.Id);
            updatedSpeciality.Code = specialty.Code;
            updatedSpeciality.Profile = specialty.Profile;
            updatedSpeciality.BudgetPlaces = specialty.BudgetPlaces;
            updatedSpeciality.BudgetMinScore = specialty.BudgetMinScore;
            updatedSpeciality.PaidPlaces = specialty.PaidPlaces;
            updatedSpeciality.PaidMinScore = specialty.PaidMinScore;
            updatedSpeciality.Exams = specialty.Exams;
            updatedSpeciality.Professions = specialty.Professions;
            var specialityEntry = this.Specialties.Update(updatedSpeciality);
            await this.SaveChangesAsync();
            return specialityEntry.Entity;
        }

        public async Task<Specialty> DeleteSpecialty(Specialty specialty)
        {
            var deletedSpeciality = await this.Specialties.FirstOrDefaultAsync(o => o.Id == specialty.Id);
            var specialityEntry = this.Specialties.Remove(deletedSpeciality);
            await this.SaveChangesAsync();
            return specialityEntry.Entity;
        }
        #endregion


        #region Faculties
        public DbSet<Faculty> Faculties { get; set; }

        public IQueryable<Faculty> GetFaculties() => this.Faculties.AsNoTracking().AsQueryable();

        public async Task<Faculty> AddFaculty(Faculty faculty)
        {
            var facultyEntry = await this.Faculties.AddAsync(faculty);
            await this.SaveChangesAsync();
            return facultyEntry.Entity;
        }

        public async Task<Faculty> UpdateFaculty(Faculty faculty)
        {
            var updatedFaculty = await this.Faculties.FirstOrDefaultAsync(o => o.Id == faculty.Id);
            var facultyEntry = this.Faculties.Update(updatedFaculty);
            await this.SaveChangesAsync();
            return facultyEntry.Entity;
        }

        public async Task<Faculty> DeleteFaculty(Faculty faculty)
        {
            var deletedFaculty = await this.Faculties.FirstOrDefaultAsync(o => o.Id == faculty.Id);
            var facultyEntry = this.Faculties.Remove(deletedFaculty);
            await this.SaveChangesAsync();
            return facultyEntry.Entity;
        }
        #endregion
    }
}

