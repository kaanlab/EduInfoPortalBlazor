using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Профессия
    public class Specialty
    {
        public int Id { get; set; }
        // Код, пример 10.05.06 
        public string Code { get; set; }
        // Профиль, пример Криптография
        public string Profile { get; set; }
        public IEnumerable<Profession> Professions { get; set; }
    }
}
