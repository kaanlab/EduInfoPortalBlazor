using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    // Бюджетные места
    public class Budget
    {
        public int Id { get; set; }
        // Количество бюджетных мест
        public int Places { get; set; }
        // Минимальный проходной балл
        public int MinScore { get; set; }
    }
}
