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
        [Route("api/StatusRapporter/{lejlighedNo}")]
        [HttpGet]
        public IQueryable<ListLejlighedersRaporterView> HentLejlighedsStatusRapporter(int lejlighedNo) {
            //foreach (ListLejlighedersRaporterView item in db.ListLejlighedersRaporterView)
            //{
            //    ListLejlighedersRaporterView t = item;
            //}
            return db.ListLejlighedersRaporterView.Where(x => x.Lejlighed_No == lejlighedNo);

            //    ListLejlighedersRaporterView listLejlighedersRaporterView = db.ListLejlighedersRaporterView.Find(id);
            //    if (listLejlighedersRaporterView == null)
            //    {
            //        return NotFound();
            //    }

            //    return Ok(listLejlighedersRaporterView);
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