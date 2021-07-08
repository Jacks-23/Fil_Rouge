using FilRouge.DAL.AccessLayers;
using QuizzApiData.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;


namespace QuizzApiData.Controllers
{
    public class QuestionController : ApiController
    {
        private readonly QuestionAccessLayer questionAccessLayer = new QuestionAccessLayer();

        // GET: api/questions
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = questionAccessLayer.GetAll().Select(q => new Question
            {
                Id = q.Id,
                Difficulte = q.Difficulte,
                Reponse = q.Reponse,

            });

            return this.Ok(result);
        }

        // GET api/quizzs/id
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var fromDb = questionAccessLayer.Get(id);
            if (fromDb == null)
                return this.NotFound();

            var result = new Question
            {
                Id = fromDb.Id,
                Difficulte = fromDb.Difficulte,
                Reponse = fromDb.Reponse
            };

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create([FromBody] Question question)
        {
            var questionToAdd = new FilRouge.DAL.Models.Question
            {
                Difficulte = question.Difficulte,
                Reponse = question.Reponse
            };

            await questionAccessLayer.AddAsync(questionToAdd);
            return this.Ok("created");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(int id, [FromBody] Question question)
        {
            var questionToUpdate = new FilRouge.DAL.Models.Question
            {
                Id = question.Id,
                Difficulte = question.Difficulte,
                Reponse = question.Reponse,
                Quizzs = question.QuizzApis.Select(q => new FilRouge.DAL.Models.QuizzQuestion { QuizzId = q.Id, QuestionId = question.Id }).ToList()
            };

            await questionAccessLayer.UpdateAssync(questionToUpdate);

            return this.Ok("updated");
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var questionToDelete = questionAccessLayer.Get(id);

            if (questionToDelete == null)
            {
                return this.NotFound();
            }

            await questionAccessLayer.DeleteAsync(questionToDelete.Id);
            return this.Ok("Delete");
        }
    }
    
}