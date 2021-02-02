using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //
        public ICollection<Specialty> Specialties { get; set; }
    }
}
