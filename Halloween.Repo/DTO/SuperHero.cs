using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halloween.Repo.DTO
{
    // DataTransferObject
    public class SuperHero
    {
        [Key]
        public int Id { get; set; } // 
        public string Name { get; set; }
        public string RealName { get; set; }
        public string Place { get; set; }
        public DateTime DebutYear { get; set; } //""

    }
}
