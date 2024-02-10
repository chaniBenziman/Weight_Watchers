using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subscriber.Data.entites
{
    [Table("SubscribeCard")]
    public class SubscribeCard
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public int  Subscriber_Id { get; set; }
       
        [ForeignKey(nameof(Subscriber_Id))]
        public Subscribers Subscriber { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime OpenDate { get; set; }
        public double BMI { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }

        [Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:dd/mm/yyyy ")]
        public DateTime UpdateDate { get; set; }
    }
}
