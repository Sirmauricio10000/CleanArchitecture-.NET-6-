using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities
{
    public class ProviderEntity
    {
        [BsonId]
        public string Nit { get; set; } = string.Empty;
        public string BusinessName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Active { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
    }
}