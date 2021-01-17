using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduInfoPortalBlazor.Models
{
    
    // Рассматриваем только высшее образование
    public class Faculty
    {
        public int Id { get; set; }
        public Institution Institution { get; set; }
        public Specialty Specialty { get; set; }
        public Direction Direction { get; set; }
        public Budget Budget { get; set; }
        public Paid Paid { get; set; }
    }


    // Направление обучения
    public enum Direction
    {
        // Гражданский
        Civil,
        // Военный
        Military
    }
}
