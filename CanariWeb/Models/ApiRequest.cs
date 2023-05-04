using Microsoft.AspNetCore.Mvc;
using static Canaria_Utility.SD;

namespace CanariWeb.Models
{
    public class ApiRequest
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
