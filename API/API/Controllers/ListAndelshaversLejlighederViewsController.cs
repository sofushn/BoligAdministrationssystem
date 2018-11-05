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
    public class ListAndelshaversLejlighederViewsController : ApiController
    {
        private BASContext db = new BASContext();

        // GET: api/ListAndelshaversLejlighederViews
        public IQueryable<ListAndelshaversLejlighederView> GetListAndelshaversLejlighederView()
        {
            return db.ListAndelshaversLejlighederView;
        }

        // GET: api/ListAndelshaversLejlighederViews/5
        //[ResponseType(typeof(ListAndelshaversLejlighederView))]
        public IQueryable<ListAndelshaversLejlighederView> GetListAndelshaversLejlighederView(int id)
        {
            return db.ListAndelshaversLejlighederView.Where(x => x.Andelshaver_ID == id);
            //ListAndelshaversLejlighederView listAndelshaversLejlighederView = db.ListAndelshaversLejlighederView.Find(id);
            //if (listAndelshaversLejlighederView == null)
            //{
            //    return NotFound();
            //}

            //return Ok(listAndelshaversLejlighederView);
        }

        // PUT: api/ListAndelshaversLejlighederViews/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutListAndelshaversLejlighederView(int id, ListAndelshaversLejlighederView listAndelshaversLejlighederView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listAndelshaversLejlighederView.Andelshaver_ID)
            {
                return BadRequest();
            }

            db.Entry(listAndelshaversLejlighederView).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListAndelshaversLejlighederViewExists(id))
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

        // POST: api/ListAndelshaversLejlighederViews
        [ResponseType(typeof(ListAndelshaversLejlighederView))]
        public IHttpActionResult PostListAndelshaversLejlighederView(ListAndelshaversLejlighederView listAndelshaversLejlighederView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ListAndelshaversLejlighederView.Add(listAndelshaversLejlighederView);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ListAndelshaversLejlighederViewExists(listAndelshaversLejlighederView.Andelshaver_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = listAndelshaversLejlighederView.Andelshaver_ID }, listAndelshaversLejlighederView);
        }

        // DELETE: api/ListAndelshaversLejlighederViews/5
        [ResponseType(typeof(ListAndelshaversLejlighederView))]
        public IHttpActionResult DeleteListAndelshaversLejlighederView(int id)
        {
            ListAndelshaversLejlighederView listAndelshaversLejlighederView = db.ListAndelshaversLejlighederView.Find(id);
            if (listAndelshaversLejlighederView == null)
            {
                return NotFound();
            }

            db.ListAndelshaversLejlighederView.Remove(listAndelshaversLejlighederView);
            db.SaveChanges();

            return Ok(listAndelshaversLejlighederView);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ListAndelshaversLejlighederViewExists(int id)
        {
            return db.ListAndelshaversLejlighederView.Count(e => e.Andelshaver_ID == id) > 0;
        }
    }
}