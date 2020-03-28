using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.DTOs
{
    public class ManageClubDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Value { get; set; }
        public List<int> ClubColors { get; set; }
    }
}
