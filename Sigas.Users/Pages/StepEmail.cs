using DevExpress.Xpo;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using Sigas.Api.Models;

namespace Sigas.Users.Pages
{
    public partial class StepEmailHandler
    {
        private readonly IHttpClientFactory clientFactory;

        public StepEmailHandler(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<bool> SendEmail2(string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://api-sigas-update.protecsrl.biz/api/Utenti/{email}");

            var client = clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Sigas.Users.Classes.DataResponse<Utente>>(responseJson);
                if(res.Data != null) return true;
                return false;
            }
            else
            {
                return false;
            }

        }
    }
}