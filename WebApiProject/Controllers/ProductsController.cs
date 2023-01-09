using Newtonsoft.Json;
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
using System.Web.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class ProductsController : ApiController
    {
        private EcommerceEntities db = new EcommerceEntities();

        public List<PRODUCT> GetPRODUCT()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.PRODUCT.ToList();
        }

        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult GetPRODUCT(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }
            return Ok(pRODUCT);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCT(int id, PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCT.Product_id)
            {
                return BadRequest();
            }

            db.Entry(pRODUCT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult PostPRODUCT(PRODUCT pRODUCT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCT.Add(pRODUCT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pRODUCT.Product_id }, pRODUCT);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(PRODUCT))]
        public IHttpActionResult DeletePRODUCT(int id)
        {
            PRODUCT pRODUCT = db.PRODUCT.Find(id);
            if (pRODUCT == null)
            {
                return NotFound();
            }

            db.PRODUCT.Remove(pRODUCT);
            db.SaveChanges();

            return Ok(pRODUCT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTExists(int id)
        {
            return db.PRODUCT.Count(e => e.Product_id == id) > 0;
        }
    }
}