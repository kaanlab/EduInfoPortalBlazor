using EduInfoPortalBlazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StorageService context)
        {
            context.Database.EnsureCreated();

            var exams = new List<Exam>();
            var cities = new List<City>();
            var professions = new List<Profession>();
            var faculties = new List<Faculty>();


            if (!context.Exams.Any())
            {
                exams.AddRange(new Exam[]
                {
                    new Exam { Name = "Русский язык"},
                    new Exam { Name = "Литература" },
                    new Exam { Name = "Математика" },
                    new Exam { Name = "Физика" },
                });
                context.Exams.AddRange(exams);
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                cities.AddRange(new City[]
                {
                    new City { Name = "Петрозаводск"},
                    new City { Name = "Москва" },
                    new City { Name = "Санкт-Петербург" },
                    new City { Name = "Воронеж" },
                });
                context.Cities.AddRange(cities);
                context.SaveChanges();
            }

            if (!context.Professions.Any())
            {
                professions.AddRange(new Profession[]
                {
                    new Profession { Name ="Летчик"},
                    new Profession { Name = "Юрист" },
                    new Profession { Name = "Дипломат" },
                    new Profession { Name = "Разведчик" },
                });
                context.Professions.AddRange(professions);
                context.SaveChanges();
            }

            if (!context.Faculties.Any())
            {
                faculties.AddRange(new Faculty[]
                {
                    new Faculty { Name="Факультет гуманитарных наук", Direction = FacultyDirection.Military },
                    new Faculty { Name="Факультет Фундаментальные науки(ФН) МГТУ", Direction = FacultyDirection.Military },
                    new Faculty { Name="Факультет Специальное машиностроение(СМ) МГТУ", Direction = FacultyDirection.Civil }
                });
                context.Faculties.AddRange(faculties);
                context.SaveChanges();
            }

            if (!context.Specialties.Any())
            {
                var specialties = new Specialty[]
                {
                    new Specialty { Code ="15.03.04", Profile="Автоматизация технологических процессов и производств", BudgetPlaces= 200, BudgetMinScore = 314, PaidPlaces=100, PaidMinScore=100, Cost = 150000, HasPaidPlaces = true, Exams = exams.GetRange(1,2), Professions = professions.GetRange(1,2), Faculty = faculties[0]},
                    new Specialty { Code ="24.03.04", Profile="Авиостроение", BudgetPlaces= 100, BudgetMinScore = 230, PaidPlaces=200, PaidMinScore=50, Cost = 100000, HasPaidPlaces = true, Exams = exams.GetRange(0,3), Professions = professions.GetRange(0,1), Faculty = faculties[1] },
                    new Specialty { Code ="23.03.02", Profile="Наземные транспортно-технологические комплексы", BudgetPlaces= 250, BudgetMinScore = 350, PaidPlaces=0, PaidMinScore=0, Cost = 0, HasPaidPlaces = false, Exams = exams.GetRange(1,1), Professions = professions.GetRange(0,3), Faculty = faculties[2] }
                };
                context.Specialties.AddRange(specialties);
                context.SaveChanges();
            }

            if (!context.Institutions.Any())
            {
                var institutions = new Institution[]
                {
                    new Institution { Name ="Петрозаводское президентское кадетсое училище",Index=185000, City = cities[0], Address ="Комсомольский проспект, дом 11", Type = InstitutionType.FUniversity, Faculties = faculties.GetRange(1,2) },
                    new Institution { Name = "Оренбургское президентское кадетское училище",Index=200100, City = cities[1], Address = "ул.Пушкинская, д.63", Type = InstitutionType.Institute, Faculties = faculties.GetRange(0,1) },
                    new Institution { Name = "Ставропольское президентское кадетское училище", Index=300200, City = cities[2], Address = "ул. Ленина, д.320", Type = InstitutionType.Academy, Faculties = faculties.GetRange(1,1) }
                };
                context.Institutions.AddRange(institutions);
                context.SaveChanges();
            }
        }
    }
}
