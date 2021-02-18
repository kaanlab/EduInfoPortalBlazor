using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    
    // Факультеты. Рассматриваем только высшее образование
    public class Faculty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MinLength(4, ErrorMessage = "Миннимальная длина 4 символа")]
        public string Name { get; set; }
        public FacultyDirection Direction { get; set; }

        //
        public Institution Institution { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
    }


    // Направление обучения
    public enum FacultyDirection
    {
        [Display(Name = "Гражданский")]
        Civil,
        [Display(Name = "Военный")]
        Military
    }
}
