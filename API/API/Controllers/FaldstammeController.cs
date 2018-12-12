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
        
        // GET: api/Faldstamme/5
        [Route("api/Faldstamme/{lejlighedNo}")]
        public IQueryable<Faldstammer> GetFaldstammer(int lejlighedNo)
        {
            return db.Faldstammer.Where(x => x.Lejlighed_No == lejlighedNo);
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