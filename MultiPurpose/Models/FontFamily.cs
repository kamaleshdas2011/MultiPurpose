using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MultiPurpose.Models
{
    public class FontFamily
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string ClassName { get; set; }
        public string Type { get; set; }


        //public virtual List<Places> DisplayPlaces { get; set; }
        //public virtual List<Places> StatePlaces { get; set; }

    }
}