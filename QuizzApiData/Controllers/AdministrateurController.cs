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
    public class AdministrateurController : ApiController
    {
        private readonly AdministrateurAccessLayer administrateurAccessLayer = new AdministrateurAccessLayer();

        //GET api/administrateur
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = administrateurAccessLayer.GetAll().Select(a => new Administrateur
            {
                Id = a.Id,
                Identifiant = a.Identifiant,
                MotDePasse = a.MotDePasse,
                Nom = a.Nom,
                Prenom = a.Prenom
            });

            return this.Ok(result);
        }

        //Get api/administrateur/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = administrateurAccessLayer.Get(id);

            if (fromDb == null)
                return this.NotFound();

            var result = new Administrateur
            {
                Id = fromDb.Id,
                Nom = fromDb.Nom,
                Identifiant = fromDb.Identifiant,
                MotDePasse = fromDb.MotDePasse,
                Prenom = fromDb.Prenom

            };

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Administrateur administrateur)
        {
            var administrateurToAdd = new FilRouge.DAL.Models.Administrateur
            {
                Identifiant = administrateur.Identifiant,
                MotDePasse = administrateur.MotDePasse,
                Nom = administrateur.Nom,
                Prenom = administrateur.Prenom
            };

            await administrateurAccessLayer.AddAsync(administrateurToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Administrateur administrateur)
        {
            var administrateurToUpdate = new FilRouge.DAL.Models.Administrateur
            {
                Id = administrateur.Id,
                Identifiant = administrateur.Identifiant,
                MotDePasse = administrateur.MotDePasse,
                Nom = administrateur.Nom,
                Prenom = administrateur.Prenom
            };

            await administrateurAccessLayer.UpdateAsync(administrateurToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var administrateurToDelete = administrateurAccessLayer.Get(id);

            if (administrateurToDelete == null)
                return this.NotFound();

            await administrateurAccessLayer.DeleteAsync(administrateurToDelete.Id);
            return this.Ok("Delete");
        }
    }
}
