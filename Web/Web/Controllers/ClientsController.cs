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
using Web.Models;
using System.Web.Routing;

namespace Web.Controllers
{
    public class ClientsController : ApiController
    {
        private WebContext db = new WebContext();

        // GET: api/Clients

        [Route("Name")]
        public IQueryable<Client> GetClients()
        {
            int startRecord = 5;
            return db.Clients.Include(s => s.clientobj).Take(startRecord);
        }

        // GET: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult GetClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [Route("Name/{Fname}/{Lname}")]
        [ResponseType(typeof(Client))]

        public IHttpActionResult GetClientByBothName(string Fname, string Lname)
        {
            var client = db.Clients.Include(s => s.clientobj).Where(n => n.FirstName == Fname && n.LastName == Lname).ToList();
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [Route("Name/{name}")]
        [ResponseType(typeof(Client))]

        public IHttpActionResult GetClientSingleName(string name)
        {
            IList<Client> client = null;
            client = db.Clients.Include(s => s.clientobj).Where(n => (n.FirstName == name || n.LastName == name)).ToList();
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);

        }

        // PUT: api/Clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient(int id, Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        [ResponseType(typeof(Client))]
        public IHttpActionResult PostClient(Client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client.id }, client);
        }

        // DELETE: api/Clients/5
        [ResponseType(typeof(Client))]
        public IHttpActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.Clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientExists(int id)
        {
            return db.Clients.Count(e => e.id == id) > 0;
        }
    }
}