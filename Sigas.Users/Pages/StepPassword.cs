using Newtonsoft.Json;
using Sigas.Api.Models;
using Sigas.User.Models;

namespace Sigas.User.Pages
{
    public partial class StepPassword
    {
        public async Task<Response> SavePassword(string password, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post,
                        $"{configuration["Configuration:ApiUrl"]}Utenti/CheckToken/");

            var data = new Sigas.Api.Models.Responses.ChengePasswordRequest()
            {
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
                if (res.Error != null) return new Response()
                {
                    IsSuccess = false,
                    Message = res.Error.UserMessage
                };
                return new Response()
                {
                    IsSuccess = true
                };
            }
            else
            {
                return new Response()
                {
                    IsSuccess = true,
                    Message = "Errore nell'operazione. Contattare l'assistenza tecnica"
                };
            }
        }
    }
}
