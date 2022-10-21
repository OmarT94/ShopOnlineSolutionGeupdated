using ShopOnline.Models.Dtos;
using ShopOnline.Web.Services.Contracts;
using System.Net.Http.Json;

namespace ShopOnline.Web.Services
{
    public class BestellungsService : IBestellungsService
    {
        private readonly HttpClient httpClient;
        public BestellungsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<BestellDetailsDto>>GetAlleBestellungen()
        {
            try
            {
                var response = await this.httpClient.GetAsync($"api/Bestellung");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<BestellDetailsDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<BestellDetailsDto>>();
                }
                else
                {
                    var message=await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public async Task<BestellDetailsDto> GetBestelllung(int id)
        {
            try
            {
                var response = await httpClient.GetAsync($"api/Bestellung/{id}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(BestellDetailsDto);
                    }
                    return await response.Content.ReadFromJsonAsync<BestellDetailsDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
