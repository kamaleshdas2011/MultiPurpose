using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultiPurpose.Models
{
    public class Photos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public string Name { get; set; }
        public bool Primary { get; set; }
        [ForeignKey("Places")]
        public int? PlaceId { get; set; }
        public virtual Places Places { get; set; }
    }
}