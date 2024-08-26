namespace BattleMetrics.API.Models.DTOs
{    
    public class Data
    {
        public GetServersWithDetailsByGameIdDTO attributes { get; set; }
    }
    public class Links
    {
        public string? prev { get; set; }
        public string? next { get; set; }
    }
    public class ResponseDTO
    {
        public List<Data> data { get; set; }
        public Links links { get; set; }
    }
}
