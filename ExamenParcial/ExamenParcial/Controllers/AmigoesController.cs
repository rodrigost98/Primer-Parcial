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
using ExamenParcial.Models;

namespace ExamenParcial.Controllers
{
    public class AmigoesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Amigoes
        public IQueryable<Amigo> GetAmigoes()
        {
            return db.Amigoes;
        }

        // GET: api/Amigoes/5
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult GetAmigo(int id)
        {
            Amigo amigo = db.Amigoes.Find(id);
            if (amigo == null)
            {
                return NotFound();
            }

            return Ok(amigo);
        }

        // PUT: api/Amigoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAmigo(int id, Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != amigo.FriendId)
            {
                return BadRequest();
            }

            db.Entry(amigo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigoes
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult PostAmigo(Amigo amigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Amigoes.Add(amigo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = amigo.FriendId }, amigo);
        }

        // DELETE: api/Amigoes/5
        [ResponseType(typeof(Amigo))]
        public IHttpActionResult DeleteAmigo(int id)
        {
            Amigo amigo = db.Amigoes.Find(id);
            if (amigo == null)
            {
                return NotFound();
            }

            db.Amigoes.Remove(amigo);
            db.SaveChanges();

            return Ok(amigo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AmigoExists(int id)
        {
            return db.Amigoes.Count(e => e.FriendId == id) > 0;
        }
    }
}