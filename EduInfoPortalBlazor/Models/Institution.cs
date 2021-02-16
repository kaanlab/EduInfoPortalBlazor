using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Учебное заведение
    public class Institution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        [RegularExpression("([0-9]+)")]
        [MinLength(6), MaxLength(6)]
        public int Index { get; set; }
        public string Address { get; set; }
        public InstitutionType Type { get; set; }

        //
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        public City City { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения!")]
        public ICollection<Faculty> Faculties { get; set; }
    }

    public enum InstitutionType
    {
        [Display(Name = "Федеральный университет")]
        FUniversity,
        [Display(Name = "Университет")]
        University,
        [Display(Name = "Академия")]
        Academy,
        [Display(Name = "Институт")]
        Institute
    }
}
