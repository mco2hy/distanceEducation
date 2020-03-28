using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public virtual ICollection<ClubColor> ClubColors { get; set; }
    }
    public class Color
    {
        public int Id { get; set; } //pk
        public string Name { get; set; } //renk adı
    }
    public class ClubColor
    {
        public int Id { get; set; }
        public int ClubId { get; set; }
        public virtual Club Club { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }
    }
}
