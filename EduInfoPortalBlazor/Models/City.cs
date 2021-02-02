using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Это поле обязательно для заполнения, миннимальная длина 2 символа")]
        [MinLength(2)]
        public string Name { get; set; }

        //
        public ICollection<Institution> Institutions { get; set; }
    }
}
