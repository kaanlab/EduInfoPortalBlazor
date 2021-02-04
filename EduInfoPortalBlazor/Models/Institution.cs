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
        public string Address { get; set; }
        public Type Type { get; set; }

        //
        public City City { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
    }

    public enum Type
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
