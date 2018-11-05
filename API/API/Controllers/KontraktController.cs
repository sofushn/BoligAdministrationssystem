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
    public class KontraktController : ApiController
    {
        private BASContext db = new BASContext();

        // GET: api/Kontrakt
        public IQueryable<Kontrakter> GetKontrakter()
        {
            return db.Kontrakter;
        }

        // GET: api/Kontrakt/5
        [ResponseType(typeof(Kontrakter))]
        public IHttpActionResult GetKontrakter(int id)
        {
            Kontrakter kontrakter = db.Kontrakter.Find(id);
            if (kontrakter == null)
            {
                return NotFound();
            }

            return Ok(kontrakter);
        }

        // PUT: api/Kontrakt/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKontrakter(int id, Kontrakter kontrakter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kontrakter.Kontrakt_ID)
            {
                return BadRequest();
            }

            db.Entry(kontrakter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KontrakterExists(id))
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

        // POST: api/Kontrakt
        [ResponseType(typeof(Kontrakter))]
        public IHttpActionResult PostKontrakter(Kontrakter kontrakter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Kontrakter.Add(kontrakter);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KontrakterExists(kontrakter.Kontrakt_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kontrakter.Kontrakt_ID }, kontrakter);
        }

        // DELETE: api/Kontrakt/5
        [ResponseType(typeof(Kontrakter))]
        public IHttpActionResult DeleteKontrakter(int id)
        {
            Kontrakter kontrakter = db.Kontrakter.Find(id);
            if (kontrakter == null)
            {
                return NotFound();
            }

            db.Kontrakter.Remove(kontrakter);
            db.SaveChanges();

            return Ok(kontrakter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KontrakterExists(int id)
        {
            return db.Kontrakter.Count(e => e.Kontrakt_ID == id) > 0;
        }
    }
}