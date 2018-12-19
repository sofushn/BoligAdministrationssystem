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