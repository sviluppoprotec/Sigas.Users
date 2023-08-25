﻿using DevExpress.Xpo;
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
        private readonly IConfiguration configuration;

        public StepEmailHandler(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string email)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
            $"{configuration["Configuration:ApiUrl"]}Utenti/SetToken/{System.Net.WebUtility.UrlEncode(email)}");

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