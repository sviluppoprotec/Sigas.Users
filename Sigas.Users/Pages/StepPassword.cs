using Newtonsoft.Json;
using Sigas.Api.Models;

namespace Sigas.User.Pages
{
    public partial class StepPassword
    {
        public async Task<bool> SavePassword(string password, string token) {
            var request = new HttpRequestMessage(HttpMethod.Post,
            $"http://api-sigas-update.protecsrl.biz/api/Utenti/CheckToken/");

            var data = new Sigas.Api.Models.Responses.ChengePasswordRequest() {
                 NewPassword = password,
                 Token = token
            };

            request.Content = JsonContent.Create(data);

            var client = ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string responseJson = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<Sigas.Users.Classes.DataResponse<Utente>>(responseJson);
                if (res.Data != null) return true;
                return false;
            }
            else
            {
                return false;
            }
        }
    }
}
