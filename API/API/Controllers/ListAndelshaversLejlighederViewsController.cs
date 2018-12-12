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
        
        //Gets all lejligheder associated with specified andelshaver id
        public IQueryable<ListAndelshaversLejlighederView> GetListAndelshaversLejlighederView(int id)
        {
            return db.ListAndelshaversLejlighederView.Where(x => x.Andelshaver_ID == id);
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