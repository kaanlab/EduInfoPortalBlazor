using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Специальности
    public class Specialty
    {
        public int Id { get; set; }
        // Код, пример 10.05.06 
        public string Code { get; set; }
        // Профиль, пример Криптография
        public string Profile { get; set; }
        // Количество бюджетных мест
        public int BudgetPlaces { get; set; }
        // Минимальный проходной балл на бюджет
        public int BudgetMinScore { get; set; }
        // Платные места
        public int PaidPlaces { get; set; }
        // Минимальный проходной балл
        public int PaidMinScore { get; set; }
        public int Cost { get; set; }
        public bool HasPaidPlaces { get; set; }

        //
        public Faculty Faculty { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Profession> Professions { get; set; }
    }
}
