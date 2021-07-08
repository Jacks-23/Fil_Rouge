using Newtonsoft.Json;
using Quizz.Mvc.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Quizz.Mvc.Web.Services
{
    public class QuestionService
    {
        private HttpClient httpClient;

        public QuestionService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44383");
        }

        public async Task<IList<Question>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Question");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var questions = JsonConvert.DeserializeObject<List<Question>>(responseBody);

                return questions;
            }

            return new List<Question>();
        }

        public async Task<Question> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Question/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var question = JsonConvert.DeserializeObject<Question>(responseBody);

                return question;
            }

            return null;

        }

        public async Task<bool> Create(Question question)
        {
            var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Question", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Question question)
        {
            var content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Question/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Question/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}