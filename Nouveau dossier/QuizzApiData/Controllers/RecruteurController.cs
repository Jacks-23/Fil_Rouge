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
    public class RecruteurController : ApiController
    {
        private readonly RecruteurAccessLayer recruteurAccessLayer = new RecruteurAccessLayer();

        // GET api/recruteur
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = recruteurAccessLayer.GetAll().Select(r => new Recruteur
            {
                Id = r.Id,
                Identifiant = r.Identifiant,
                MotDePasse = r.MotDePasse,
                Nom = r.Nom,
                Prenom = r.Prenom
            });

            return this.Ok(result);
        }

        //Get api/recruteur/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = recruteurAccessLayer.Get( id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Recruteur
            {
                Id = fromDb.Id,
                Identifiant = fromDb.Identifiant,
                MotDePasse = fromDb.MotDePasse,
                Nom = fromDb.Nom,
                Prenom = fromDb.Prenom
            };

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Recruteur recruteur)
        {
            var recruteurToAdd = new FilRouge.DAL.Models.Recruteur
            {
                Identifiant = recruteur.Identifiant,
                MotDePasse = recruteur.MotDePasse,
                Nom = recruteur.Nom,
                Prenom = recruteur.Prenom
            };

            await recruteurAccessLayer.AddAsync(recruteurToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Recruteur recruteur)
        {
            var recruteurToUpdate = new FilRouge.DAL.Models.Recruteur
            {
                Id = recruteur.Id,
                Identifiant = recruteur.Identifiant,
                MotDePasse = recruteur.MotDePasse,
                Nom = recruteur.Nom,
                Prenom = recruteur.Prenom
            };

            await recruteurAccessLayer.UpdateAsync(recruteurToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var recruteurToDelete = recruteurAccessLayer.Get(id);

            if (recruteurToDelete == null)
                return this.NotFound();

            await recruteurAccessLayer.DeleteAsync(recruteurToDelete.Id);

            return this.Ok("Delete");
        }
    }
}
