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
    public class CandidatService
    {
        private HttpClient httpClient;

        public CandidatService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44383");
        }

        public async Task<IList<Candidat>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Candidat");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var candidats = JsonConvert.DeserializeObject<List<Candidat>>(responseBody);

                return candidats;
            }

            return new List<Candidat>();
        }

        public async Task<Candidat> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Candidat/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var candidat = JsonConvert.DeserializeObject<Candidat>(responseBody);

                return candidat;
            }

            return null;

        }

        public async Task<bool> Create(Candidat candidat)
        {
            var content = new StringContent(JsonConvert.SerializeObject(candidat), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Candidat", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Candidat candidat)
        {
            var content = new StringContent(JsonConvert.SerializeObject(candidat), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Candidat/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Candidat/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}