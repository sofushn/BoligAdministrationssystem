using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ListLejlighedersRaporterViewsController : ApiController
    {
        private BASContext db = new BASContext();

        // GET: api/ListLejlighedersRaporterViews
        public IQueryable<ListLejlighedersRaporterView> GetListLejlighedersRaporterView()
        {
            return db.ListLejlighedersRaporterView;
        }

        // GET: api/ListLejlighedersRaporterViews/5
        //[ResponseType(typeof(ListLejlighedersRaporterView))]
        public IQueryable<ListLejlighedersRaporterView> GetListLejlighedersRaporterView(int id)
        {
            return db.ListLejlighedersRaporterView.Where(x => x.Lejlighed_No == id);
        //    ListLejlighedersRaporterView listLejlighedersRaporterView = db.ListLejlighedersRaporterView.Find(id);
        //    if (listLejlighedersRaporterView == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(listLejlighedersRaporterView);
        }

        // PUT: api/ListLejlighedersRaporterViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListLejlighedersRaporterView(int id, ListLejlighedersRaporterView listLejlighedersRaporterView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listLejlighedersRaporterView.Status_ID)
            {
                return BadRequest();
            }

            db.Entry(listLejlighedersRaporterView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListLejlighedersRaporterViewExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ListLejlighedersRaporterViews
        [ResponseType(typeof(ListLejlighedersRaporterView))]
        public IHttpActionResult PostListLejlighedersRaporterView(ListLejlighedersRaporterView listLejlighedersRaporterView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListLejlighedersRaporterView.Add(listLejlighedersRaporterView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ListLejlighedersRaporterViewExists(listLejlighedersRaporterView.Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = listLejlighedersRaporterView.Status_ID }, listLejlighedersRaporterView);
        }

        // DELETE: api/ListLejlighedersRaporterViews/5
        [ResponseType(typeof(ListLejlighedersRaporterView))]
        public IHttpActionResult DeleteListLejlighedersRaporterView(int id)
        {
            ListLejlighedersRaporterView listLejlighedersRaporterView = db.ListLejlighedersRaporterView.Find(id);
            if (listLejlighedersRaporterView == null)
            {
                return NotFound();
            }

            db.ListLejlighedersRaporterView.Remove(listLejlighedersRaporterView);
            db.SaveChanges();

            return Ok(listLejlighedersRaporterView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListLejlighedersRaporterViewExists(int id)
        {
            return db.ListLejlighedersRaporterView.Count(e => e.Status_ID == id) > 0;
        }
    }
}