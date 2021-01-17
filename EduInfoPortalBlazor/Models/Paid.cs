using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Платные места
    public class Paid
    {
        public int Id { get; set; }
        // Количество бюджетных мест
        public int Places { get; set; }
        // Минимальный проходной балл
        public int MinScore { get; set; }
        public int Cost { get; set; }
    }
}
