using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Специальности
    public class Specialty
    {
        public int Id { get; set; }
        // Код, пример 10.05.06 
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MinLength(4, ErrorMessage = "Миннимальная длина 4 символа")]
        public string Code { get; set; }
        // Профиль, пример Криптография
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MinLength(4, ErrorMessage = "Миннимальная длина 4 символа")]
        public string Profile { get; set; }
        // Количество бюджетных мест
        [RegularExpression("([0-9]+)", ErrorMessage = "В этом поле разрешены только цифры!")]
        public int BudgetPlaces { get; set; }
        // Минимальный проходной балл на бюджет
        [RegularExpression("([0-9]+)", ErrorMessage = "В этом поле разрешены только цифры!")]
        public int BudgetMinScore { get; set; }
        // Платные места
        [RegularExpression("([0-9]+)", ErrorMessage = "В этом поле разрешены только цифры!")]
        public int PaidPlaces { get; set; }
        // Минимальный проходной балл
        [RegularExpression("([0-9]+)", ErrorMessage = "В этом поле разрешены только цифры!")]
        public int PaidMinScore { get; set; }
        [RegularExpression("([0-9]+)", ErrorMessage = "В этом поле разрешены только цифры!")]
        //Стоимость 
        public int Cost { get; set; }
        public bool HasPaidPlaces { get; set; }

        //
        public Faculty Faculty { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Profession> Professions { get; set; }
    }
}
