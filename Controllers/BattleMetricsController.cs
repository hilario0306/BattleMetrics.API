using BattleMetrics.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace BattleMetrics.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleMetricsController(IBattleMetricsService _battleMetricsService) : ControllerBase
    {
        [HttpGet(Name = "GetServerInfoByGameId")]
        public async Task<IActionResult> GetServersWithDetailsByGameId(string game, int page = 1)
        {
            var result = await _battleMetricsService.GetServersWithDetailsByGameId(game, page);            

            return result.IsSuccess
            ? Ok(result)
            : BadRequest(result);
        }
    }
}
