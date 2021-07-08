using FilRouge.DAL.AccessLayers;

using QuizzApiData.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace QuizzApiData.Controllers
{
    public class QuizzController : ApiController
    {
        
        private readonly QuestionAccessLayer questionAccessLayer = new QuestionAccessLayer();
        private readonly QuizzAccessLayer quizzAccessLayer = new QuizzAccessLayer();

        // GET: api/quizz
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = quizzAccessLayer.GetAll().Select(q => new QuizzApi
            {
                Id = q.Id,
                NbDeQuestions = q.NbDeQuestions,
                DateDeCreation = q.DateDeCreation,
                Note = q.Note,
                Niveau = q.Niveau,

            });
            return this.Ok(result);
        }

        // GET: api/quizz/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = quizzAccessLayer.Get(id);
            if(fromDb == null)
                return this.NotFound();

            var result = new QuizzApi
            {
                Id = fromDb.Id,
                NbDeQuestions = fromDb.NbDeQuestions,
                DateDeCreation = fromDb.DateDeCreation,
                Note = fromDb.Note,
                Niveau = fromDb.Niveau,
                Questions = fromDb.QuizzQuestions.Select(qq => new Question
                {
                    Id = qq.Question.Id,
                    Reponse = qq.Question.Reponse,
                    Difficulte = qq.Question.Difficulte
                }).ToList()
            };

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] QuizzApi quizz)
        {
            if(!questionAccessLayer.Exists(quizz.Questions.Select(q => q.Id).ToList()))
            {
                return this.NotFound();

            }

            var quizzToAdd = new FilRouge.DAL.Models.QuizzClass
            {
                NbDeQuestions = quizz.NbDeQuestions,
                DateDeCreation = quizz.DateDeCreation,
                Niveau = quizz.Niveau,
                Note = quizz.Note
            };

            quizzToAdd.QuizzQuestions = quizz.Questions.Select(q => new FilRouge.DAL.Models.QuizzQuestion { QuestionId = q.Id, Quizz = quizzToAdd }).ToList();

            await quizzAccessLayer.AddAsync(quizzToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] QuizzApi quizzApi)
        {
            if (!questionAccessLayer.Exists(quizzApi.Questions.Select(q => q.Id).ToList()))
            {
                return this.NotFound();
            }

            var quizzToUpdate = new FilRouge.DAL.Models.QuizzClass
            {
                Id = quizzApi.Id,
                DateDeCreation = quizzApi.DateDeCreation,
                NbDeQuestions = quizzApi.NbDeQuestions,
                Niveau = quizzApi.Niveau,
                Note = quizzApi.Note,
                QuizzQuestions = quizzApi.Questions.Select(q => new FilRouge.DAL.Models.QuizzQuestion { QuestionId = q.Id, QuizzId = quizzApi.Id }).ToList()
            };

            await quizzAccessLayer.UpdateAsync(quizzToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var quizzToDelete = quizzAccessLayer.Get(id);

            if (quizzToDelete == null)
            {
                return this.NotFound();
            }

            await quizzAccessLayer.DeleteAsync(quizzToDelete.Id);
            return this.Ok("Delete");
        }

    }
}
