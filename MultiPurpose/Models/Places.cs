using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;

namespace MultiPurpose.Models
{
    public class Places
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("State")]
        public int? StateId { get; set; }
        public State State { get; set; }

        public string Name { get;set;}
        public virtual List<Photos> Photos { get; set; }
        public bool TopPlace { get; set; }

        public string title { get; set; }
        public string text { get; set; }
        public string titleColor { get; set; }
        public string textColor { get; set; }
        public string stateColor { get; set; }

        public bool col4 { get; set; }
        public bool col6 { get; set; }
        public int? Sequence { get; set; }

        public int? TextFontFamilyId { get; set; }
        public virtual FontFamily TextFontFamily { get; set; }
        public int? StateFontFamilyId { get; set; }
        public virtual FontFamily StateFontFamily { get; set; }
        public int? TitleFontFamilyId { get; set; }
        public virtual FontFamily TitleFontFamily { get; set; }

        public int? ParentPlaceId { get; set; }
        public virtual Places ParentPlace { get; set; }

    }
}