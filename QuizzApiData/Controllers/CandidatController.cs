using FilRouge.DAL.AccessLayers;
using QuizzApiData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuizzApiData.Controllers
{
    public class CandidatController : ApiController
    {
        private readonly CandidatAccessLayer candidatAccessLayer = new CandidatAccessLayer();

        // GET api/candidat
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = candidatAccessLayer.GetAll().Select(c => new Candidat
            {
                Id = c.Id,
                Niveau = c.Niveau,
                Nom = c.Nom,
                Prenom = c.Prenom
            });

            return this.Ok(result);
        }

        //GET api/candidat/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = candidatAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Candidat
            {
                Id = fromDb.Id,
                Niveau = fromDb.Niveau,
                Nom = fromDb.Nom,
                Prenom = fromDb.Prenom
            };

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Candidat candidat)
        {
            var candidatToAdd = new FilRouge.DAL.Models.Candidat
            {
                Niveau = candidat.Niveau,
                Nom = candidat.Nom,
                Prenom = candidat.Prenom
            };

            await candidatAccessLayer.AddAsync(candidatToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Candidat candidat)
        {
            var candidatToUpdate = new FilRouge.DAL.Models.Candidat
            {
                Id = candidat.Id,
                Niveau = candidat.Niveau,
                Nom = candidat.Nom,
                Prenom = candidat.Prenom
            };

            await candidatAccessLayer.UpdateAsync(candidatToUpdate);

            return this.Ok("updated");

        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var candidatToDelete = candidatAccessLayer.Get(id);

            if (candidatToDelete == null)
                return this.NotFound();

            await candidatAccessLayer.DeleteAsync(candidatToDelete.Id);
            return this.Ok("Delete");
        }
    }
}
