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
    public class AndelshaverController : ApiController
    {
        private BASContext db = new BASContext();

        // GET: api/Andelshaver
        public IQueryable<Andelshaver> GetAndelshaver()
        {
            return db.Andelshaver;
        }

        // GET: api/Andelshaver/5
        [ResponseType(typeof(Andelshaver))]
        public IHttpActionResult GetAndelshaver(int id)
        {
            Andelshaver andelshaver = db.Andelshaver.Find(id);
            if (andelshaver == null)
            {
                return NotFound();
            }

            return Ok(andelshaver);
        }

        // PUT: api/Andelshaver/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAndelshaver(int id, Andelshaver andelshaver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != andelshaver.Andelshaver_ID)
            {
                return BadRequest();
            }

            db.Entry(andelshaver).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AndelshaverExists(id))
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

        // POST: api/Andelshaver
        [ResponseType(typeof(Andelshaver))]
        public IHttpActionResult PostAndelshaver(Andelshaver andelshaver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Andelshaver.Add(andelshaver);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AndelshaverExists(andelshaver.Andelshaver_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = andelshaver.Andelshaver_ID }, andelshaver);
        }

        // DELETE: api/Andelshaver/5
        [ResponseType(typeof(Andelshaver))]
        public IHttpActionResult DeleteAndelshaver(int id)
        {
            Andelshaver andelshaver = db.Andelshaver.Find(id);
            if (andelshaver == null)
            {
                return NotFound();
            }

            db.Andelshaver.Remove(andelshaver);
            db.SaveChanges();

            return Ok(andelshaver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AndelshaverExists(int id)
        {
            return db.Andelshaver.Count(e => e.Andelshaver_ID == id) > 0;
        }
    }
}