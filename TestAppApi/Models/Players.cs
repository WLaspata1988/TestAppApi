using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestAppApi.Models
{
    public class Players
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        
        public virtual Team Team { get; set; }
    }
}
