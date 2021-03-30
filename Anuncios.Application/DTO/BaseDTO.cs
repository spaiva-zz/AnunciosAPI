using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace Anuncios.Application.DTO
{
    public class BaseDTO
    {
        [JsonIgnore]
        public int Id { get; set; }
        public bool IsAtivo { get; set; }
    }
}