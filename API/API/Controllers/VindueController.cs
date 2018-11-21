using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    [RoutePrefix("api/vindue")]
    public class VindueController : ApiController
    {
        private BASContext db = new BASContext();


        [Route("{lejlighedNo:int}")]
        [HttpGet]
        public IQueryable<Vindue> HentVinduer(int lejlighedNo) {
            return db.Vindue.Where(x => x.Lejlighed_No == lejlighedNo);
        }

        [Route("~/api/vindue/{lejlighed}")]
        [HttpGet]
        public IQueryable<Vindue> HentVindue(Lejligheder lejlighed) {
            return db.Vindue.Where(x => x.Lejlighed_No == lejlighed.Lejlighed_No);
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