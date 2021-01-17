using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Учебное заведение
    public class Institution
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Type Type { get; set; }

        public IEnumerable<Faculty> Faculties { get; set; }
    }

    public enum Type
    {
        Academy,
        University,
        Institute
    }
}
