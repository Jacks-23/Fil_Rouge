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

    public class QuizService
    {
        private HttpClient httpClient;

        public QuizService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44383");
        }

        public async Task<IList<Quiz>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Quizz");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quizzs = JsonConvert.DeserializeObject<List<Quiz>>(responseBody);

                return quizzs;
            }

            return new List<Quiz>();
        }

        public async Task<Quiz> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Quizz/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var quizz = JsonConvert.DeserializeObject<Quiz>(responseBody);

                return quizz;
            }

            return null;

        }

        public async Task<bool> Create(Quiz quiz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Quizz", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Quiz quiz)
        {
            var content = new StringContent(JsonConvert.SerializeObject(quiz), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Quizz/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Quizz/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }


    }   
}