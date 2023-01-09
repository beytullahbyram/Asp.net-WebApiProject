using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    public class CategoryController : ApiController
    {
        EcommerceEntities db= new EcommerceEntities(); 
        public List<CATEGORIES> Get()
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<CATEGORIES> categories =db.CATEGORIES.ToList();
            return categories;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                CATEGORIES categories = db.CATEGORIES.Find(id);   
                CategortEntities categoryEntities = new CategortEntities()
                {
                    Category_id = categories.Category_id,
                    Category_name=categories.Category_name,
                };
                return  Ok(categoryEntities);
            }
            catch (System.NullReferenceException)
            {
                return BadRequest("category is not defined");
            }
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody]CATEGORIES categoriess)
        {
            db.CATEGORIES.Add(categoriess);
            db.SaveChanges();
            return Ok();
        }


        public IHttpActionResult Put([FromBody]CATEGORIES categoriess)
        {
            //entry gelen bilginleri değişmiş olarak alır 
            db.Entry(categoriess).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            CATEGORIES categories=db.CATEGORIES.Find(id);
            db.CATEGORIES.Remove(categories);
            db.SaveChanges();
            return Ok();
        }

    }
}
