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
    public class AdministrateurService
    {
        private HttpClient httpClient;

        public AdministrateurService()
        {
            this.httpClient = new HttpClient();
            this.httpClient.BaseAddress = new Uri("https://localhost:44383");
        }

        public async Task<IList<Administrateur>> GetAll()
        {
            var response = await this.httpClient.GetAsync("/api/Administrateur");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var administrateurs = JsonConvert.DeserializeObject<List<Administrateur>>(responseBody);

                return administrateurs;
            }

            return new List<Administrateur>();
        }

        public async Task<Administrateur> Get(int id)
        {
            var response = await this.httpClient.GetAsync($"/api/Administrateur/{id}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var administrateurs = JsonConvert.DeserializeObject<Administrateur>(responseBody);

                return administrateurs;
            }

            return null;

        }

        public async Task<bool> Create(Administrateur administrateur)
        {
            var content = new StringContent(JsonConvert.SerializeObject(administrateur), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PostAsync($"/api/Administrateur", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Update(int id, Administrateur administrateur)
        {
            var content = new StringContent(JsonConvert.SerializeObject(administrateur), Encoding.UTF8, "application/json");
            var response = await this.httpClient.PutAsync($"/api/Administrateur/{id}", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await this.httpClient.DeleteAsync($"/api/Administrateur/{id}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }
}