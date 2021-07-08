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
    public class RecruteurService
    {
        private HttpClient httpClient;

        public RecruteurService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44383");
        }

        public async Task<IList<Recruteur>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Recruteur");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var recruteurs = JsonConvert.DeserializeObject<List<Recruteur>>(responseBody);

                return recruteurs;
            }

            return new List<Recruteur>();
        }

        public async Task<Recruteur> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Recruteur/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var recruteur = JsonConvert.DeserializeObject<Recruteur>(responseBody);

                return recruteur;
            }

            return null;

        }

        public async Task<bool> Create(Recruteur recruteur)
        {
            var content = new StringContent(JsonConvert.SerializeObject(recruteur), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Recruteur", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Recruteur recruteur)
        {
            var content = new StringContent(JsonConvert.SerializeObject(recruteur), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Recruteur/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Recruteur/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}