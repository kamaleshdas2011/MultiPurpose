using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using MultiPurpose.Models;

namespace MultiPurpose.Context
{
    public class PlaceConfiguration: EntityTypeConfiguration<Places>
    {
        public PlaceConfiguration()
        {
            //this.HasMany(p => p.ChildPlaces)
            //    .WithMany()
            //    .Map(p => {
            //        p.MapLeftKey("Id");
            //        p.MapRightKey("Places_Id");
            //        p.ToTable("ChildPlaces");
            //    });
        }
    }
}