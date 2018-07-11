using MultiPurpose.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace MultiPurpose.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();
        // GET api/values
        [Route("getstates")]
        public IHttpActionResult GetSates()
        {
            var state = db.States;
            return Ok(state);
        }

        [Route("getcitybystate/{stateName}")]
        public IHttpActionResult GetCityByState(string stateName)
        {
            var cities = db.Cities.Where(m => m.state.name.Equals(stateName));//.Include(c=>c.state);
            return Ok(cities);
        }
        [Route("getplaces")]
        public IHttpActionResult GetPlaces()
        {
            var places = //db.Places.Include(m => m.State).ToList();
                (from p in db.Places
                 select new
                 {
                     p.Id,
                     p.Name,
                     p.State,
                     p.TopPlace,
                     p.col4,
                     p.col6,
                     p.title,
                     p.titleColor,
                     p.textColor,
                     p.stateColor,
                     p.StateFontFamily,
                     p.TextFontFamily,
                     p.TitleFontFamily,
                     p.Sequence,
                     ParentPlaceId = (int?)p.ParentPlaceId,
                     ParentPlace = new
                     {
                         ParentPlace = (int?)p.ParentPlace.Id,
                         p.ParentPlace.Name,
                     }
                 }).ToList();
            return Ok(places);
        }
        [Route("getplacesbyid/{id}")]
        public IHttpActionResult GetPlacesById(string id)
        {
            int placeId = Convert.ToInt32(id);
            var places = //db.Places.Include(m => m.State).ToList();
                (from p in db.Places
                 where p.Id == placeId
                 select new
                 {
                     p.Id,
                     p.Name,
                     p.State,
                     p.TopPlace,
                     p.col4,
                     p.col6,
                     p.title,
                     p.titleColor,
                     p.textColor,
                     p.TitleFontFamily,
                     p.TextFontFamily,
                     p.StateFontFamily,
                     ParentPlaceId = (int?)p.ParentPlaceId,
                     ParentPlace = new
                     {
                         ParentPlace = (int?)p.ParentPlace.Id,
                         p.ParentPlace.Name,
                     },
                     Photos =
                         (from ph in p.Photos
                          select new
                          {
                              ph.Id,
                              ph.Name,
                              ph.Photo,
                              ph.PlaceId,
                              ph.Primary
                          }),
                 }).FirstOrDefault();
            return Ok(places);
        }
        [Route("gettopplaces")]
        public IHttpActionResult GetTopPlaces()
        {
            //Thread.Sleep(2000);
            var places = //db.Places.Include(m => m.State).ToList();
                (from p in db.Places
                 where p.Photos.Any(ph => ph.Primary == true) && p.TopPlace == true
                 select new
                 {
                     p.Id,
                     p.Name,
                     p.State,
                     p.TopPlace,
                     p.col4,
                     p.col6,
                     p.title,
                     p.titleColor,
                     p.textColor,
                     p.TitleFontFamily,
                     p.TextFontFamily,
                     p.StateFontFamily,
                     p.Sequence,
                     ParentPlaceId = (int?)p.ParentPlaceId,
                     ParentPlace = new
                     {
                         ParentPlace = (int?)p.ParentPlace.Id,
                         p.ParentPlace.Name,
                     },
                     //PlaceFonts = (from f in db.FontFamily where f.Id == p.PlaceFontFamily.Id)
                     Photos =
                         (from ph in p.Photos
                          select new
                          {
                              ph.Id,
                              ph.Name,
                              ph.Photo,
                              ph.PlaceId,
                              ph.Primary
                          })

                 }).OrderBy(m=>m.Sequence).ToList();

            return Ok(places);
        }
        [Route("getphotos")]
        public IHttpActionResult GetPhotos()
        {
            var photos = //db.Photos.Include(p => p.Places).ToList();
                (from p in db.Photos
                 select new
                 {
                     p.Id,
                     p.Name,
                     p.Photo,
                     p.PlaceId,
                     Places = new
                     {
                         Id = (int?)p.Places.Id,
                         p.Places.Name,
                         p.Places.State,
                         TopPlace = (bool?)p.Places.TopPlace
                     },
                     p.Primary
                 }).ToList();
            return Ok(photos);
        }
        [Route("getfonts")]
        public IHttpActionResult GetFonts()
        {
            var photos = db.FontFamily.ToList();
            return Ok(photos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerExists(int id)
        {
            return db.Customer.Count(e => e.id == id) > 0;
        }
    }
}
