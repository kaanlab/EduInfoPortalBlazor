using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    public class Profession
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Это поле обязательно для заполнения")]
        [MinLength(4, ErrorMessage = "Миннимальная длина 4 символа")]
        public string Name { get; set; }

        //
        public ICollection<Specialty> Specialties { get; set; }
    }
}
