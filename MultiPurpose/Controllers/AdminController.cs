using MultiPurpose.Context;
using MultiPurpose.Models;
using System;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace MultiPurpose.Controllers
{
    [RoutePrefix("api/admin")]
    public class AdminController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        [HttpPost]
        [Route("uploadphoto")]
        public async Task<IHttpActionResult> UploadPhoto()
        {
            var res = await Request.Content.ReadAsMultipartAsync();
            string fileName;
            var model = JObject.Parse(res.Contents[0].ReadAsStringAsync().Result);
            dynamic place = model["Places"];
            foreach (var files in res.Contents)
            {
                Photos p = new Photos();
                fileName = files.Headers.ContentDisposition.FileName;
                if (place!=null && place.Id!=null)
                {
                    p.PlaceId = place.Id;
                }
                p.Primary = Convert.ToBoolean(model["Primary"]);
                if (!string.IsNullOrEmpty(fileName))
                {
                    var fileContent = await files.ReadAsByteArrayAsync();
                    p.Photo = fileContent;
                    p.Name = fileName;
                    db.Photos.Add(p);
                }
                
            }
            
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Photos ON");
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Photos OFF");
            return Ok();
        }
        [HttpPost]
        [Route("addplace")]
        public IHttpActionResult AddPlace(Places place)
        {
            Places newplace = new Places();
            newplace.Name = place.Name;
            newplace.StateId = place.State.id;
            newplace.TopPlace = place.TopPlace;
            newplace.col4 = place.col4;
            newplace.col6 = place.col6;
            newplace.title = place.Name;
            newplace.textColor = place.textColor;
            newplace.titleColor = place.titleColor;
            newplace.Sequence = place.Sequence;
            newplace.stateColor = place.stateColor;
            
            if (place.ParentPlace!=null)
            {
                newplace.ParentPlaceId = place.ParentPlace.Id;
            }
            if (place.StateFontFamily != null)
            {
                newplace.StateFontFamilyId = place.StateFontFamily.Id;
            }
            if (place.TextFontFamily != null)
            {
                newplace.TextFontFamilyId = place.TextFontFamily.Id;
            }
            if (place.TitleFontFamily != null)
            {
                newplace.TitleFontFamilyId = place.TitleFontFamily.Id;
            }
            db.Places.Add(newplace);
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Places ON");
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.Places OFF");
            return Ok();
        }
        [HttpPost]
        [Route("updateplace")]
        public IHttpActionResult UpdatePlace(Places place)
        {
            var dbPlace = db.Places.First(p => p.Id == place.Id);

            dbPlace.Name = place.Name;
            dbPlace.StateId = place.State.id;
            dbPlace.TopPlace = place.TopPlace;
            dbPlace.col4 = place.col4;
            dbPlace.col6 = place.col6;
            dbPlace.title = place.Name;
            dbPlace.textColor = place.textColor;
            dbPlace.titleColor = place.titleColor;
            dbPlace.stateColor = place.stateColor;
            if (place.ParentPlace != null)
            {
                dbPlace.ParentPlaceId = place.ParentPlace.Id;
            }
            if (place.StateFontFamily != null)
            {
                dbPlace.StateFontFamilyId = place.StateFontFamily.Id;
            }
            if (place.TextFontFamily != null)
            {
                dbPlace.TextFontFamilyId = place.TextFontFamily.Id;
            }
            if (place.TitleFontFamily != null)
            {
                dbPlace.TitleFontFamilyId = place.TitleFontFamily.Id;
            }
            
            
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("deleteplace/{id}")]
        public IHttpActionResult DeletePlace(string id)
        {
            int placeId = Convert.ToInt32(id);
            var dbPlace = db.Places.Include(m=>m.Photos).First(m=>m.Id==placeId);

            //db.Places.Remove(dbPlace);
            db.Entry(dbPlace).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("deletephoto/{id}")]
        public IHttpActionResult DeletePhoto(string id)
        {
            int photoId = Convert.ToInt32(id);
            var dbPhoto = db.Photos.Include(m => m.Places).First(m => m.Id == photoId);

            //db.Places.Remove(dbPlace);
            db.Entry(dbPhoto).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("updatephoto")]
        public async Task<IHttpActionResult> UpdatePhoto()
        {
            var res = await Request.Content.ReadAsMultipartAsync();
            var model = JObject.Parse(res.Contents[0].ReadAsStringAsync().Result);
            int photoId = Convert.ToInt32(model["Id"]);
            var dbPhoto = db.Photos.First(p => p.Id == photoId);
            var fileName = model["Name"].ToString();
            dbPhoto.Primary = Convert.ToBoolean(model["Primary"]);
            dynamic place = model["Places"];
            dbPhoto.PlaceId = place.Id;

            foreach (var files in res.Contents)
            {
                var embedFileName = files.Headers.ContentDisposition.FileName;
                if (!string.IsNullOrEmpty(fileName))
                {
                    var fileContent = await files.ReadAsByteArrayAsync();
                    dbPhoto.Photo = fileContent;
                    dbPhoto.Name = embedFileName;
                }

            }

            db.SaveChanges();
            return Ok();
        }
    }
}
