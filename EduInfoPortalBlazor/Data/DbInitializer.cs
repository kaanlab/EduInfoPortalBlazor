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

            if (!context.Exams.Any())
            {
                var exams = new Exam[]
                {
                    new Exam { Name ="Русский язык"},
                    new Exam { Name = "Литература" },
                    new Exam { Name = "Математика" },
                    new Exam { Name = "Физика" },
                };

                context.Exams.AddRange(exams);
                context.SaveChanges();
            }

            if (!context.Cities.Any())
            {
                var cities = new City[]
                {
                    new City { Name ="Петрозаводск"},
                    new City { Name = "Москва" },
                    new City { Name = "Санкт-Петербург" },
                    new City { Name = "Воронеж" },
                };

                context.Cities.AddRange(cities);
                context.SaveChanges();
            }

            if (!context.Professions.Any())
            {
                var professions = new Profession[]
                {
                    new Profession { Name ="Летчик"},
                    new Profession { Name = "Юрист" },
                    new Profession { Name = "Дипломат" },
                    new Profession { Name = "Разведчик" },
                };

                context.Professions.AddRange(professions);
                context.SaveChanges();
            }

            if (!context.Institutions.Any())
            {
                var institutions = new Institution[]
                {
                    new Institution { Name ="Петрозаводское президентское кадетсое училище",Index=185000, Address ="185000, Комсомольский проспект, дом 11"},
                    new Institution { Name = "Оренбургское президентское кадетское училище",Index=200100, Address = "460010, ул.Пушкинская, д.63" },
                    new Institution { Name = "Ставропольское президентское кадетское училище", Index=300200, Address = "355017, ул. Ленина, д.320" }
                };

                context.Institutions.AddRange(institutions);
                context.SaveChanges();
            }
        }
    }
}
