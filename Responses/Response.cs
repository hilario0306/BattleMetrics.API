using System.Text.Json.Serialization;

namespace BattleMetrics.API.Responses
{
    public class Response<TData>
    {
        public int StatusCode { get; set; } = StatusCodes.Status200OK;
        public TData? Data { get; set; }

        [JsonConstructor]
        public Response()
        => StatusCode = StatusCodes.Status200OK;

        public Response(TData? data, int statusCode = StatusCodes.Status200OK)
        {
            this.StatusCode = statusCode;
            Data = data;
        }

        [JsonIgnore]
        public bool IsSuccess => StatusCode >= 200 && StatusCode <= 299;

    }
}
