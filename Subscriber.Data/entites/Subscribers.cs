using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.entites
{
    [Table("Subscriber")]
    public class Subscribers
    {
        [Key]
        [Required]
     
        public int Id { get; set; }
        [MaxLength(100)]
        public string Firstname { get; set; }

        [MaxLength(100)]
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
