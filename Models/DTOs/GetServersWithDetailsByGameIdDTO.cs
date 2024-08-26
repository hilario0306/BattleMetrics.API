namespace BattleMetrics.API.Models.DTOs
{
    public class GetServersWithDetailsByGameIdDTO
    {
        public string name { get; set; }       
        public int rank { get; set; }
        public string status { get; set; }
        public string ip { get; set; }
        public int port { get; set; }
        public int players { get; set; }
        public int maxPlayers { get; set; }
    }
}

