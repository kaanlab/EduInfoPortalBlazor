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
            if (context.Institutions.Any())
            {
                return;
            }

            var institutions = new Institution[]
            {
                new Institution { Name ="Петрозаводское президентское кадетсое училище",Address ="185000, республика Карелия, город Петрозаводск, Комсомольский проспект, дом 11"},
                new Institution { Name = "Оренбургское президентское кадетское училище", Address = "460010, Оренбургская область, г.Оренбург, ул.Пушкинская, д.63" },
                new Institution { Name = "Ставропольское президентское кадетское училище", Address = "355017, Ставропольский край, г.Ставрополь, ул. Ленина, д.320" }
            };

            context.Institutions.AddRange(institutions);
            context.SaveChanges();
        }
    }
}
