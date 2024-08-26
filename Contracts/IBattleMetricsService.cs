using BattleMetrics.API.Models.DTOs;
using BattleMetrics.API.Responses;

namespace BattleMetrics.API.Contracts
{
    public interface IBattleMetricsService
    {
        public Task<Response<List<GetServersWithDetailsByGameIdDTO>>> GetServersWithDetailsByGameId(string game, int page);
    }
}
