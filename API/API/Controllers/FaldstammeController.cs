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
    public class FaldstammeController : ApiController
    {
        private BASContext db = new BASContext();

        // GET: api/Faldstamme
        //public IQueryable<Faldstammer> GetFaldstammer()
        //{
        //    return db.Faldstammer;
        //}

        // GET: api/Faldstamme/5
        //[ResponseType(typeof(Faldstammer))]
        [Route("api/Faldstamme/{lejlighedNo}")]
        public IQueryable<Faldstammer> GetFaldstammer(int lejlighedNo)
        {
            return db.Faldstammer.Where(x => x.Lejlighed_No == lejlighedNo);
            //if (faldstammer == null)
            //{
            //    return NotFound();
            //}

            //return Ok(faldstammer);
        }
        #region comments
        // PUT: api/Faldstamme/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutFaldstammer(int id, Faldstammer faldstammer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != faldstammer.Faldstamme_ID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(faldstammer).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!FaldstammerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // POST: api/Faldstamme
        //[ResponseType(typeof(Faldstammer))]
        //public IHttpActionResult PostFaldstammer(Faldstammer faldstammer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Faldstammer.Add(faldstammer);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (FaldstammerExists(faldstammer.Faldstamme_ID))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = faldstammer.Faldstamme_ID }, faldstammer);
        //}

        // DELETE: api/Faldstamme/5
        //[ResponseType(typeof(Faldstammer))]
        //public IHttpActionResult DeleteFaldstammer(int id)
        //{
        //    Faldstammer faldstammer = db.Faldstammer.Find(id);
        //    if (faldstammer == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Faldstammer.Remove(faldstammer);
        //    db.SaveChanges();

        //    return Ok(faldstammer);
        //}

        //private bool FaldstammerExists(int id)
        //{
        //    return db.Faldstammer.Count(e => e.Faldstamme_ID == id) > 0;
        //}
        #endregion

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}