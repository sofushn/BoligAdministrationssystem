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
    public class Status_RaportController : ApiController
    {
        private BASContext db = new BASContext();

        [Route("api/StatusRapporter/{lejlighedNo}")]
        [HttpGet]
        public IQueryable<ListLejlighedersRaporterView> HentLejlighedsStatusRapporter(int lejlighedNo)
        {
            return db.ListLejlighedersRaporterView.Where(x => x.Lejlighed_No == lejlighedNo);
        }

        // POST: api/Status_Raport
        [ResponseType(typeof(Status_Raport))]
        public IHttpActionResult PostStatus_Raport(Status_Raport status_Raport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Status_Raport.Add(status_Raport);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Status_RaportExists(status_Raport.Status_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = status_Raport.Status_ID }, status_Raport);
        }

        // GET: api/Status_Raport
        public IQueryable<Status_Raport> GetStatus_Raport()
        {
            return db.Status_Raport;
        }

        // GET: api/Status_Raport/5
        [ResponseType(typeof(Status_Raport))]
        public IHttpActionResult GetStatus_Raport(int id)
        {
            Status_Raport status_Raport = db.Status_Raport.Find(id);
            if (status_Raport == null)
            {
                return NotFound();
            }

            return Ok(status_Raport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Status_RaportExists(int id)
        {
            return db.Status_Raport.Count(e => e.Status_ID == id) > 0;
        }
    }
}