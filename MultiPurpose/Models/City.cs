using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultiPurpose.Models
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string country { get; set; }
        public State state { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        [StringLength(5)]
        public string code { get; set; }
        [StringLength(100)]
        public string type { get; set; }
    }
}