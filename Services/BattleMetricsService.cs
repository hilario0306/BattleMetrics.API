using BattleMetrics.API.Contracts;
using BattleMetrics.API.Models.DTOs;
using BattleMetrics.API.Responses;
using System.Text.Json;

namespace BattleMetrics.API.Services
{
    public class BattleMetricsService(IHttpClientFactory httpClientFactory) : IBattleMetricsService
    {
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<Response<List<GetServersWithDetailsByGameIdDTO>>> GetServersWithDetailsByGameId(string game, int page)
        {
            try
            {
                var servers = new List<GetServersWithDetailsByGameIdDTO>();
                using (var httpClient = _httpClientFactory.CreateClient())
                {
                    var baseUri = $"https://api.battlemetrics.com/servers?filter[game]={game}&fields[server]=name%2Crank%2Cstatus%2Cip%2Cport%2Cplayers%2CmaxPlayers&page[size]=10";
                    var pagesToTarget = page;
                    var apiResponse = new ResponseDTO();
                    do
                    {
                        pagesToTarget -= 1;
                        var clientReturn = await httpClient.GetAsync(baseUri);
                        var jsonString = await clientReturn.Content.ReadAsStringAsync();
                        apiResponse = JsonSerializer.Deserialize<ResponseDTO>(jsonString);
                        baseUri = apiResponse!.links.next;
                    }
                    while (pagesToTarget > 0);
                    
                    foreach(var element in apiResponse!.data)
                    {
                        servers.Add(element.attributes);
                    }
                }

                return new Response<List<GetServersWithDetailsByGameIdDTO>>(data: servers);
            }
            catch
            {
                return new Response<List<GetServersWithDetailsByGameIdDTO>>(statusCode: 500, data: []);
            }
        }
    }
}
