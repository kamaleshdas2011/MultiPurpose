using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MultiPurpose.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        [StringLength(100)]
        public string firstName { get; set; }
        [StringLength(50)]
        public string lastName { get; set; }
        [StringLength(500)]
        public string imageUrl { get; set; }
        public string role { get; set; }
        [StringLength(1)]
        public string gender { get; set; }
        public City city { get; set; }
        [StringLength(10)]
        public string phoneNumber { get; set; }

    }
}